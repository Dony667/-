from abc import ABC, abstractmethod


class IPayment(ABC):
    @abstractmethod
    def process_payment(self, amount):
        pass


class IDelivery(ABC):
    @abstractmethod
    def calculate_delivery_cost(self):
        pass


class INotification(ABC):
    @abstractmethod
    def send(self, message):
        pass


class CreditCardPayment(IPayment):
    def process_payment(self, amount):
        print(f"оплата каспи: {amount} тг.")


class PayPalPayment(IPayment):
    def process_payment(self, amount):
        print(f"оплата через халык: {amount} тг.")


class CourierDelivery(IDelivery):
    def calculate_delivery_cost(self):
        return 500


class PostDelivery(IDelivery):
    def calculate_delivery_cost(self):
        return 300


class EmailNotification(INotification):
    def send(self, message):
        print(f"эмайл: {message}")


class SmsNotification(INotification):
    def send(self, message):
        print(f"смс: {message}")


class DiscountCalculator:
    def apply_discount(self, total, percent):
        return total - (total * (percent / 100))


class Order:
    def __init__(self):
        self._total_amount = 0
        self._payment_method = None
        self._delivery_method = None
        self._notification_method = None
        self._discount_calculator = DiscountCalculator()

    def add_item(self, price):
        self._total_amount += price

    def set_payment_method(self, payment_method):
        self._payment_method = payment_method

    def set_delivery_method(self, delivery_method):
        self._delivery_method = delivery_method

    def set_notification_method(self, notification_method):
        self._notification_method = notification_method

    def calculate_total_cost(self):
        return self._total_amount + self._delivery_method.calculate_delivery_cost()

    def apply_discount(self, percent):
        self._total_amount = self._discount_calculator.apply_discount(
            self._total_amount, percent
        )

    def complete_order(self):
        total_cost = self.calculate_total_cost()
        self._payment_method.process_payment(total_cost)
        self._notification_method.send("заказ оформлен!")


def main():
    order = Order()
    order.add_item(99999)
    order.add_item(999)

    order.set_payment_method(CreditCardPayment())
    order.set_delivery_method(CourierDelivery())
    order.apply_discount(10)
    order.set_notification_method(EmailNotification())

    order.complete_order()


if __name__ == "__main__":
    main()
