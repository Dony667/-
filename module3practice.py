class User:
    def __init__(self, name, email, role):
        self.name = name
        self.email = email
        self.role = role


class UserManager:
    def __init__(self):
        self.users = []

    def add_user(self, user):
        self.users.append(user)

    def remove_user(self, email):
        self.users = [user for user in self.users if user.email != email]

    def update_user(self, email, name=None, role=None):
        for user in self.users:
            if user.email == email:
                if name:
                    user.name = name
                if role:
                    user.role = role


def main():
    manager = UserManager()
    user1 = User("Бека", "beka@example.com", "Admin")
    user2 = User("Серик", "serik@example.com", "User")

    manager.add_user(user1)
    manager.add_user(user2)

    manager.update_user("beka@example.com", role="Admin")
    manager.remove_user("serik@example.com")


if __name__ == "__main__":
    main()
