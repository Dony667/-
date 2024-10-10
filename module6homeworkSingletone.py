class ConfigurationManager:
    __instance = None
    def __new__(cls):
        if cls.__instance is None:
            cls.__instance = super().__new__(cls)
            cls.__instance.__config = {}
        return cls.__instance
    def load_settings(self, settings):
        self.__config.update(settings)
    def get_setting(self, key):
        return self.__config.get(key)
    def set_setting(self, key, value):
        self.__config[key] = value

config1 = ConfigurationManager()
config2 = ConfigurationManager()
config1.load_settings({"database": "mysql", "host": "localhost"})
config2.set_setting("port", "3306")

print(config1.get_setting("database"))  
print(config2.get_setting("host"))     
print(config1.get_setting("port"))  
print(config1 is config2) 