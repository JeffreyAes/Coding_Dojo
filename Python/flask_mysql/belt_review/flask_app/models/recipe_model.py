from flask_app.config.mysqlconnections import connectToMySQL
from flask_app import DATABASE
from flask_app.models import user_model

class Recipe:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.under = data['under']
        self.description = data["description"]
        self.instruction = data['instruction']
        self.date = data['date']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
        self.user_id = data['user_id']
        self.user = None


    @classmethod
    def get_recipes(cls):
        query = """
        SELECT * FROM recipes JOIN users
        ON users.id = recipes.user_id;
        """
        results = connectToMySQL(DATABASE).query_db(query)
        if results:
            recipe = []
            # recipes = cls(result)
            # ^ this is how u normally do it
            for row in results:
                recipes = cls(row)
                # ^ this combines the id and user_id cls(row)
                data = {
                    **row,
                    'id': row['users.id'],
                    'created_at': row['users.created_at'],
                    'updated_at': row['users.updated_at']
                }
                #     {
                #     'id': row['id'],
                #     'first_name': row['first_name'],
                #     'last_name': row['last_name'],
                #     'email': row['email'],
                #     'password': row['password'],
                #     'created_at': row['created_at'],
                #     'updated_at': row['updated_at']
                # }]
                this_user = user_model.User(data)
                recipes.user = this_user
                recipe.append(recipes)
                # recipes.user.append(User(data[1]))
                # user_recipe.append(recipe_model.Recipe(recipe_data))
                # user_recipe.append(User(user_data))
            return recipe

        return False

    @classmethod
    def recipeSave(cls, data):
        query = """
        INSERT INTO recipes (name, description, instruction, date, user_id)
        VALUES ( %(name)s, %(description)s, %(instruction)s, %(date)s, %(user_id)s)
        """

        results = connectToMySQL(DATABASE).query_db(query, data)
        return results