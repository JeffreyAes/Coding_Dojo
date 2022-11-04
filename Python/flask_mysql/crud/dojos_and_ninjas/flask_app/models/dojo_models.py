from flask_app.config.mysqlconnections import connectToMySQL
from flask_app import DATABASE
from flask_app.models import ninja_models


class Dojo:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']

    @classmethod
    def get_all(cls):
        query = "SELECT * FROM dojos;"

        results = connectToMySQL(DATABASE).query_db(query)

        dojos = []

        for dojo in results:
            dojos.append(cls(dojo))
        return dojos

    @classmethod
    def get_one(cls, data):
        query = """
        SELECT * FROM dojos LEFT JOIN ninjas
        ON dojos.id = ninjas.dojo_id 
        WHERE dojos.id = %(id)s;
        """
        results = connectToMySQL(DATABASE).query_db(query, data)
        if results:
            this_dojo = cls(results[0])
            these_ninjas = []
            for row in results:
                ninja_data = {
                    "id": row['ninjas.id'],
                    "first_name": row['first_name'],
                    "last_name": row['last_name'],
                    "age": row['age'],
                    "created_at": row['ninjas.created_at'],
                    "updated_at": row['ninjas.updated_at'],
                    "dojo_id": row["dojo_id"]
                }
                this_ninja = ninja_models.Ninja(ninja_data)
                these_ninjas.append(this_ninja)
            this_dojo.ninjas = these_ninjas
            return this_dojo

        return False

    @classmethod
    def save(cls, data):
        query = """
        INSERT INTO dojos (name) VALUES ( %(name)s )
        """
        results = connectToMySQL(DATABASE).query_db(query, data)
        return results