class IMediator:
    def send_message(self, message, user):
        pass

    def add_user(self, user):
        pass

class ChatRoom(IMediator):
    def __init__(self):
        self.users = []

    def add_user(self, user):
        self.users.append(user)
        self.notify_all(f"{user.name} присоединился")

    def send_message(self, message, sender, recipient=None):
        if sender not in self.users:
            print(f"{sender.name} не в чате")
            return

        if recipient:
            recipient.receive_message(message, sender)
        else:
            for user in self.users:
                if user != sender:
                    user.receive_message(message, sender)

    def notify_all(self, message):
        for user in self.users:
            user.receive_system_message(message)

class User:
    def __init__(self, name, mediator):
        self.name = name
        self.mediator = mediator

    def send_message(self, message, recipient=None):
        self.mediator.send_message(message, self, recipient)

    def receive_message(self, message, sender):
        print(f"{self.name} получил от {sender.name}: {message}")

    def receive_system_message(self, message):
        print(f"[системное сообщение для {self.name}]: {message}")

def main():
    chat_room = ChatRoom()

    user1 = User("саке", chat_room)
    user2 = User("баке", chat_room)

    chat_room.add_user(user1)
    chat_room.add_user(user2)

    user1.send_message("салем всем")
    user2.send_message("калайсын, баке")

if __name__ == "__main__":
    main()
