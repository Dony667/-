class Vehicle:
    def __init__(self, brand, model, year):
        self.brand = brand
        self.model = model
        self.year = year

    def start_eng(self):
        print(f"{self.brand} {self.model} движок запустился.")

    def stop_eng(self):
        print(f"{self.brand} {self.model} движок потух.")


class Car(Vehicle):
    def __init__(self, brand, model, year, doors, transmission):
        super().__init__(brand, model, year)
        self.doors = doors
        self.transmission = transmission


class Moto(Vehicle):
    def __init__(self, brand, model, year, body_type, has_box):
        super().__init__(brand, model, year)
        self.body_type = body_type
        self.has_box = has_box


class Garage:
    def __init__(self):
        self.vehicles = []

    def add_vehicle(self, vehicle):
        self.vehicles.append(vehicle)

    def remove_vehicle(self, vehicle):
        self.vehicles.remove(vehicle)


class Fleet:
    def __init__(self):
        self.garages = []

    def add_garage(self, garage):
        self.garages.append(garage)

    def remove_garage(self, garage):
        self.garages.remove(garage)

    def find_vehicle(self, brand):
        for garage in self.garages:
            for vehicle in garage.vehicles:
                if vehicle.brand == brand:
                    print(f"найдено {vehicle.brand} {vehicle.model} в автопарке")


def main():
    car = Car("лексус", "додж", 2020, 4, "Automatic")
    moto = Moto("хендай", "камрюха", 2018, "крузак", True)

    garage1 = Garage()
    garage1.add_vehicle(car)

    garage2 = Garage()
    garage2.add_vehicle(moto)

    fleet = Fleet()
    fleet.add_garage(garage1)
    fleet.add_garage(garage2)

    fleet.find_vehicle("хендай")


if __name__ == "__main__":
    main()
