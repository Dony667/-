class Product:
    def __init__(self, name, price, quantity):
        self.name = name
        self.price = price
        self.quantity = quantity
    def clone(self):
        return Product(self.name, self.price, self.quantity)
    def __str__(self):
        return f"{self.name}: {self.quantity} шт. по {self.price} тенге."

class Order:
    def __init__(self, products=None, delivery_cost=0, payment_method=""):
        self.products = products or []
        self.delivery_cost = delivery_cost
        self.payment_method = payment_method
    def add_product(self, product):
        self.products.append(product)
    def clone(self):
        cloned_products = [product.clone() for product in self.products]
        return Order(cloned_products, self.delivery_cost, self.payment_method)
    def __str__(self):
        products_str = "\n".join([str(product) for product in self.products])
        return f"товары:\n{products_str}\nдоставка: {self.delivery_cost} тенге.\nОплата: {self.payment_method}"


product1 = Product("книга", 500, 2)
product2 = Product("айфон", 1000000, 1)

order1 = Order([product1, product2], delivery_cost=300, payment_method="каспи")
print("ориг заказ:")
print(order1)

order2 = order1.clone()
order2.add_product(Product("пк", 1000000, 1))
order2.payment_method = "нал"

print("\nклон заказ:")
print(order2)
