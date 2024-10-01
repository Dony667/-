class Transport:
    def drive(self):
        print(f"{self.__class__.__name__} едет.")
    
    def refuel(self):
        print(f"{self.__class__.__name__} заправляется.")

class Car(Transport):
    def __init__(self, brand, model):
        self.brand = brand
        self.model = model

class Motorcycle(Transport):
    def __init__(self, engine_capacity):
        self.engine_capacity = engine_capacity

class Truck(Transport):
    def __init__(self, load_capacity):
        self.load_capacity = load_capacity

class TransportFactory:
    def create_transport(self, transport_type, *args):
        if transport_type == "авто":
            return Car(*args)
        elif transport_type == "мото":
            return Motorcycle(*args)
        elif transport_type == "грузовик":
            return Truck(*args)
        else:
            print("Неизвестный тип транспорта.")
            return None

factory = TransportFactory()

transport_type = input("Введите тип транспорта (авто, мото, грузовик): ")

if transport_type == "авто":
    brand = input("Введите марку авто: ")
    model = input("Введите модель авто: ")
    transport = factory.create_transport(transport_type, brand, model)
elif transport_type == "мото":
    engine_capacity = input("Введите объем двигателя: ")
    transport = factory.create_transport(transport_type, engine_capacity)
elif transport_type == "грузовик":
    load_capacity = input("Введите грузоподъемность: ")
    transport = factory.create_transport(transport_type, load_capacity)

if transport:
    transport.drive()
    transport.refuel()
