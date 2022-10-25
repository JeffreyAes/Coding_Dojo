class BankAccount:
    # don't forget to add some default values for these parameters!
    def __init__(self, balance, int_rate=.02):
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

    def display_account_info(self, name):
        print(f"{name} balance: {self.accBalance}")
        return self

    def yield_interest(self):
        if self.accBalance > 0:
            self.accBalance *= self.accIntRate
        return self

class User:
    def __init__(self, name, email, balance):
        self.name = name
        self.email = email
        self.account = BankAccount(balance, int_rate=0)
    
    def makeDeposit(self, amount):
        self.account.deposit(amount)
        print(f"{self.name} deposited: {amount}")
        return self

    def makeWithdraw(self, amount):
        self.account.withdraw(amount)
        print(f"{self.name} withdrew: {amount}")
        return self
    def showBalance(self, name):
        self.account.display_account_info(name)
        return self

JeffsAccount = User("Jeffrey Aeschliman", "email@email.com", 800)
JeffsAccount.makeDeposit(500).makeWithdraw(200).showBalance("Jeffrey Aeschliman")