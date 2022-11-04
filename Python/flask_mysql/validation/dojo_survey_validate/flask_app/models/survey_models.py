from flask_app.config.mysqlconnections import connectToMySQL
DATABASE = "dojo_survey_schema"
from flask import flash

class Survey:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.location = data['location']
        self.language = data['language']
        self.comment = data['comment']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']

    @staticmethod
    def validate_survey(survey):
        is_valid = True
        if len(survey['name']) < 1:
            flash("Name is required!", "name")
            is_valid = False
        return is_valid

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
        SELECT * FROM dojos WHERE id = %(id)s;
        """
        results = connectToMySQL(DATABASE).query_db(query, data)
        if results:
            return cls(results[0])
        return False

    @classmethod
    def save(cls, data):
        query = """
        INSERT INTO dojos (name, location, language, comment)
        VALUES (%(name)s, %(location)s, %(language)s, %(comment)s );
        """
        print(data)
        print(query)
        result = connectToMySQL(DATABASE).query_db(query, data)
        return result
    
