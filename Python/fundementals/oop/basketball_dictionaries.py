kevin = {
    "name": "Kevin Durant",
    "age": 34,
    "position": "small forward",
    "team": "Brooklyn Nets"
}
jason = {
    "name": "Jason Tatum",
    "age": 24,
    "position": "small forward",
    "team": "Boston Celtics"
}
kyrie = {
    "name": "Kyrie Irving",
    "age": 32,
    "position": "Point Guard",
    "team": "Brooklyn Nets"
}

# Create your Player instances here!
# player_jason = ???


class Player:
    def __init__(self, players):
        self.name = players["name"]
        self.age = players["age"]
        self.position = players["position"]
        self.team = players["team"]

        @classmethod
        def add_players(cls, players):
            player_objects = []
            for dict in players:
                player_objects.append(cls(dict))
            return player_objects
    
    def __repr__(self):
        display = f"Player: {self.name}, {self.age} years:, position: {self.position}, team: {self.team}"
        return display


player_jason = Player(jason)
player_kevin = Player(kevin)
player_kyrie = Player(kyrie)
print(player_jason)
print(player_kevin)
print(player_kyrie)
print(player_kevin.position)