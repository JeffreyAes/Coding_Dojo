from flask import flash
from flask_app.config.mysqlconnections import connectToMySQL
from flask_app import DATABASE  
from flask_app.models import user_model


class Recipe:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.under = data['under']
        self.description = data['description']
        self.instruction = data['instruction']
        self.date = data['date']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
        self.user_id = data['user_id']

    @classmethod
    def create(cls, data):
        query = """
        INSERT INTO recipes (name, under, description, instruction, date, user_id)
        VALUES (%(name)s, %(under)s, %(description)s, %(instruction)s, %(date)s, %(user_id)s);
        """

        return connectToMySQL(DATABASE).query_db(query, data)
        #^inserting into the database
    @classmethod
    def get_all(cls):
        query = """
        SELECT * FROM recipes JOIN users ON recipes.user_id = users.id;
        """
        results = connectToMySQL(DATABASE).query_db(query)
        #^selects the joined table of recipes and users
        all_recipes = []
        if results:
            for row in results:
                this_recipe = cls(row)
                user_data = {
                    **row,
                    'id': row['users.id'],
                    'created_at': row['users.created_at'],
                    'updated_at': row['users.updated_at']
                }
                this_user = user_model.User(user_data)
                this_recipe.creator = this_user
                all_recipes.append(this_recipe)
        return (all_recipes)
        #^fills the recipe information in the joined table, and returns ALL of the recipes
    @classmethod
    def get_by_id(cls, data):
        query = """
        SELECT * FROM recipes JOIN users ON recipes.user_id = users.id
        WHERE recipes.id = %(id)s;
        """
        results = connectToMySQL(DATABASE).query_db(query, data)
        if results:
            this_recipe = cls(results[0])
            row = results[0]
            user_data = {
                **row,
                'id': row['users.id'],
                'created_at': row['users.created_at'],
                'updated_at': row['users.updated_at']
            }
            this_user = user_model.User(user_data)
            this_recipe.creator = this_user
            return this_recipe
        return False
        #^grabs a specified user, fills them with their recipes, and returns the users recieps
    @classmethod
    def update(cls,data):
        query = """
        UPDATE recipes SET name = %(name)s, under = %(under)s, description = %(description)s, 
        instruction = %(instruction)s, date = %(date)s
        WHERE id = %(id)s;
        """
        return connectToMySQL(DATABASE).query_db(query,data)
        #updates specific recipes
    @classmethod
    def delete(cls,data):
        query = """
        DELETE FROM recipes WHERE id = %(id)s;
        """
        return connectToMySQL(DATABASE).query_db(query,data)
        #deletes specific recipes

    @staticmethod
    def validator(form_data):
        is_valid = True
        if len(form_data['name']) < 3:
            flash("Name MUST be at least 3 characters long!")
            is_valid = False
        if len(form_data['description']) < 3:
            flash("Description MUST be at least 3 characters long!")
            is_valid = False
        if len(form_data['date']) < 1:
            flash("date is required!")
            is_valid = False
        if len(form_data['instruction']) < 3:
            flash("Instructions MUST be at least 3 characters long!")
            is_valid = False
        if "under" not in form_data:
            flash("Cook time is REQUIRED!")
            is_valid = False
        return is_valid
        #checks if the recipe creation form is filled out.