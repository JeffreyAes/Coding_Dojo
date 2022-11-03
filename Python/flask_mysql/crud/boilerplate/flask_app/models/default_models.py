from flask_app.config.mysqlconnections import connectToMySQL
DATABASE = "default"


class Default:
    def __init__(self, data):
        self.id = data['id']
        self.id = ['name']
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
