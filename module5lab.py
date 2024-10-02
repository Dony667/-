from abc import ABC, abstractmethod

class Vehicle(ABC):

    def move(self):
        pass

    def refuel(self):
        pass

class Car(Vehicle):
    def move(self):
        return "авто едет по дороге"

    def refuel(self):
        return "авто заправляется бензином"

class Motorcycle(Vehicle):
    def move(self):
        return "мотик мчит по трассе."

    def refuel(self):
        return "мотик заправляется бензином"

class Airplane(Vehicle):
    def move(self):
        return "самолет взлетает в небо"

    def refuel(self):
        return "самолет заправляется авиационным топливом"

class Bicycle(Vehicle):
    def move(self):
        return "велик катится по тропинке"

    def refuel(self):
        return "велик не требует топлива"

class VehicleFactory(ABC):
    @abstractmethod
    def create_vehicle(self):
        pass

class CarFactory(VehicleFactory):
    def create_vehicle(self):
        return Car()

class MotorcycleFactory(VehicleFactory):
    def create_vehicle(self):
        return Motorcycle()

class AirplaneFactory(VehicleFactory):
    def create_vehicle(self):
        return Airplane()

class BicycleFactory(VehicleFactory):
    def create_vehicle(self):
        return Bicycle()

def main():
    vehicle_type = input("введите тип тс (авто, мотик, самолет, велик): ").strip().lower()
    
    factory_map = {
        'авто': CarFactory(),
        'мотик': MotorcycleFactory(),
        'самолет': AirplaneFactory(),
        'велик': BicycleFactory()
    }
    
    factory = factory_map.get(vehicle_type)
    if factory:
        vehicle = factory.create_vehicle()
        model = input("введите модель: ")
        speed = input("введите скорость: ")
        
        print(vehicle.move())
        print(vehicle.refuel())
        print(f"модель: {model}, скорость: {speed} км/ч")
    else:
        print("неправильный тип тс")

if __name__ == "__main__":
    main()
