class BankAccount:
    # don't forget to add some default values for these parameters!
    def __init__(self, int_rate=0.02, balance=0):
        # your code here! (remember, instance attributes go here)
        self.accBalance = balance
        self.accIntRate = int_rate
        # don't worry about user info here; we'll involve the User class soon

    def deposit(self, amount):
        self.accBalance += amount
        return self

    def withdraw(self, amount):
        if self.accBalance > 20:
            self.accBalance -= amount
        else:
            print("Insufficient funds: Charging a $5 fee")
            self.accBalance -= 5
        return self

    def display_account_info(self):
        print(self.accBalance)
        return self

    def yield_interest(self):
        if self.accBalance > 0:
            self.accBalance *= self.accIntRate
        return self


BankUser = BankAccount()
BankUser.deposit(500).withdraw(200).yield_interest().display_account_info()
BankUser2 = BankAccount()
BankUser2.deposit(6000).deposit(540).deposit(209).withdraw(
    750).yield_interest().display_account_info()

BankUser3 = BankAccount()
BankUser3.deposit(1_000_000).deposit(3_500_000).withdraw(250_000).withdraw(80_000).withdraw(8).withdraw(
    2_600_000).yield_interest().display_account_info()



