from abc import ABC, abstractmethod


class Beverage(ABC):
    @abstractmethod
    def cost(self):
        pass

    @abstractmethod
    def description(self):
        pass


class Espresso(Beverage):
    def cost(self):
        return 100

    def description(self):
        return "Espresso"


class Tea(Beverage):
    def cost(self):
        return 50

    def description(self):
        return "Tea"


class BeverageDecorator(Beverage):
    def __init__(self, beverage):
        self._beverage = beverage

    @abstractmethod
    def cost(self):
        pass

    @abstractmethod
    def description(self):
        pass


class Milk(BeverageDecorator):
    def cost(self):
        return self._beverage.cost() + 20

    def description(self):
        return self._beverage.description() + " + Milk"


class Sugar(BeverageDecorator):
    def cost(self):
        return self._beverage.cost() + 5

    def description(self):
        return self._beverage.description() + " + Sugar"


class WhippedCream(BeverageDecorator):
    def cost(self):
        return self._beverage.cost() + 30

    def description(self):
        return self._beverage.description() + " + Whipped Cream"


if __name__ == "__main__":
    my_drink = Espresso()
    print(f"{my_drink.description()} : {my_drink.cost()} тенге")

    my_drink = Milk(my_drink)
    print(f"{my_drink.description()} : {my_drink.cost()} тенге")

    my_drink = Sugar(my_drink)
    print(f"{my_drink.description()} : {my_drink.cost()} тенге")

    my_drink = WhippedCream(my_drink)
    print(f"{my_drink.description()} : {my_drink.cost()} тенге")
