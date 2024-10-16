class Napitok:
    def cook(self):
        self.kipyatit_water()
        self.zavarit()
        self.nalit_cup()
        if self.user_need_dobavka():
            self.add_dobavka()

    def kipyatit_water(self):
        print("кипячу воду")

    def nalit_cup(self):
        print("наливаю в чашку")

    def zavarit(self):
        pass

    def add_dobavka(self):
        pass

    def user_need_dobavka(self):
        return True

class Tea(Napitok):
    def zavarit(self):
        print("завариваю чай")

    def add_dobavka(self):
        print("добавляю лимон")

class Coffee(Napitok):
    def zavarit(self):
        print("завариваю кофе")

    def add_dobavka(self):
        print("добавляю сахар и молоко")

    def user_need_dobavka(self):
        otvet = input("хотите добавить сахар и молоко (да или нет): ").lower()
        while otvet not in ["да", "нет"]:
            otvet = input("введите 'да' или 'нет': ").lower()
        return otvet == "да"

class HotChoco(Napitok):
    def zavarit(self):
        print("развожу горячий шоколад")

    def add_dobavka(self):
        print("добавляю мармелад")

def main():
    tea = Tea()
    coffee = Coffee()
    choco = HotChoco()

    print("\nготовка чая:")
    tea.cook()

    print("\nготовка кофе:")
    coffee.cook()

    print("\nготовка хот чоко:")
    choco.cook()

if __name__ == "__main__":
    main()