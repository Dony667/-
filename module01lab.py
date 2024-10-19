class Employee:
    def __init__(self, name, employee_id, position):
        self.name = name
        self.employee_id = employee_id
        self.position = position

    def calculate_salary(self):
        pass

    def __str__(self):
        return f"{self.name} ({self.position})"


class Worker(Employee):
    def __init__(self, name, employee_id, hourly_rate, hours_worked):
        super().__init__(name, employee_id, "Worker")
        self.hourly_rate = hourly_rate
        self.hours_worked = hours_worked

    def calculate_salary(self):
        return self.hourly_rate * self.hours_worked


class Manager(Employee):
    def __init__(self, name, employee_id, fixed_salary, bonus):
        super().__init__(name, employee_id, "Manager")
        self.fixed_salary = fixed_salary
        self.bonus = bonus

    def calculate_salary(self):
        return self.fixed_salary + self.bonus


def main():
    employees = [
        Worker("сотрудник1", 101, 500, 160),
        Worker("сотрудник2", 102, 600, 140),
        Manager("сотрудник3", 201, 100000, 20000),
    ]

    for employee in employees:
        print(f"{employee}: зарплата {employee.calculate_salary()} тг.")


if __name__ == "__main__":
    main()
