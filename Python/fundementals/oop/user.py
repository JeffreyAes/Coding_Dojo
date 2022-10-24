class user:
    def __init__(self, first, last, email, age):
        self.first_name = first
        self.last_name = last
        self.email = email
        self.age = age
        self.is_rewards_member = False
        self.got_card_points = 0
    
    def display_info(self):
        print(self.first_name)
        print(self.last_name)
        print(self.email)
        print(self.is_rewards_member)
        print(self.got_card_points)
    
    def enroll(self):
        if self.is_rewards_member == False:
            self.is_rewards_member = True
            self.got_card_points += 200
        else: print("User is already a member.")
    
    def spend_points(self, amount):
        if self.got_card_points > amount:
            self.got_card_points -= amount
        else: print("not enough funds")

userName = user("jeff", "aes", "email@email.com", 21)
userName.display_info()
userName2 = user("harold", "smittington", "email2@email.com", 68)
userName3 = user("caroline", "thimberson", "aaaaaaaaaa@email.com", 43)
userName3.spend_points(50)
userName2.enroll()
userName2.spend_points(80)
userName.display_info()
userName2.display_info()
userName3.display_info()
userName.enroll()
userName.enroll()
userName3.spend_points(40)