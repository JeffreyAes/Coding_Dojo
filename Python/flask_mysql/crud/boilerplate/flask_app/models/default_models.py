from flask_app.config.mysqlconnections import connectToMySQL
DATABASE = "default"


class Default:
    def __init__(self, data):
        self.id = data['id']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']

    @classmethod
    def get_all(cls):
        query = "SELECT * FROM users;"

        results = connectToMySQL(DATABASE).query_db(query)

        defaults = []

        for default in results:
            defaults.append(cls(default))
        return defaults

    @classmethod
    def get_one(cls, data):
        query = """
        SELECT * FROM default WHERE id = %(id)s;
        """
        results = connectToMySQL(DATABASE).query_db(query, data)
        if results:
            return cls(results[0])
        return False

    @classmethod
    def save(cls, data):
        query = "INSERT INTO default (default) VALUES (%(default)s);"
        result = connectToMySQL(DATABASE).query_db(query, data)
        return result

    @classmethod
    def delete(cls, data):
        query = """
            DELETE FROM default WHERE id = %(id)s;
        """
        result = connectToMySQL(DATABASE).query_db(query, data)
        return result

    @classmethod
    def update(cls, data):
        query = """
        UPDATE default SET default = %(default)s
        WHERE id = %(id)s;
        """
        result = connectToMySQL(DATABASE).query_db(query, data)
        return result
