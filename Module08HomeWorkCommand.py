class Command:
    def execute(self):
        pass

    def otmena(self):
        pass

class Svet:
    def On(self):
        print("свет вкл")

    def Off(self):
        print("свет выкл")

class CommandOnSvet(Command):
    def __init__(self, svet):
        self.svet = svet

    def execute(self):
        self.svet.On()

    def otmena(self):
        self.svet.Off()

class Door:
    def open(self):
        print("дверь открыта")

    def closed(self):
        print("дверь закрыта")

class CommandOpenDoor(Command):
    def __init__(self, Door):
        self.Door = Door

    def execute(self):
        self.Door.open()

    def otmena(self):
        self.Door.closed()

class Termostat:
    def up_temp(self):
        print("темп увеличена")

    def down_temp(self):
        print("темп уменьшена")

class CommandUpTemp(Command):
    def __init__(self, termostat):
        self.termostat = termostat

    def execute(self):
        self.termostat.up_temp()

    def otmena(self):
        self.termostat.down_temp()

class Invoker:
    def __init__(self):
        self.this_Command = None
        self.history_command = []

    def install_command(self, Command):
        self.this_Command = Command

    def execute_command(self):
        if self.this_Command:
            self.this_Command.execute()
            self.history_command.append(self.this_Command)

    def otmena_command(self):
        if self.history_command:
            poslednyaya_Command = self.history_command.pop()
            poslednyaya_Command.otmena()
        else:
            print("не чего отменять")

svet = Svet()
Door = Door()
termostat = Termostat()

Command_svet = CommandOnSvet(svet)
Command_Door = CommandOpenDoor(Door)
Command_termostat = CommandUpTemp(termostat)

invoker = Invoker()

invoker.install_command(Command_svet)
invoker.execute_command()
invoker.otmena_command()

invoker.install_command(Command_Door)
invoker.execute_command()
invoker.otmena_command()

invoker.install_command(Command_termostat)
invoker.execute_command()
invoker.otmena_command()