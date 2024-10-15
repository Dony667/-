# Strategy Pattern - Payment Methods
class i_plata_strategy:
    def plata(self, summa):
        pass

class karta_plata(i_plata_strategy):
    def plata(self, summa):
        return f"Paid {summa} with karta."

class paypal_plata(i_plata_strategy):
    def plata(self, summa):
        return f"Paid {summa} with paypal."

class kripto_plata(i_plata_strategy):
    def plata(self, summa):
        return f"Paid {summa} with kripto."

class plata_context:
    def __init__(self, strategy):
        self._strategy = strategy

    def set_plata_strategy(self, strategy):
        self._strategy = strategy

    def plata(self, summa):
        return self._strategy.plata(summa)

kontekst = plata_context(karta_plata())
print(kontekst.plata(100))
kontekst.set_plata_strategy(paypal_plata())
print(kontekst.plata(200))
kontekst.set_plata_strategy(kripto_plata())
print(kontekst.plata(300))


# Observer Pattern - Currency Exchange
class i_nablyudatel:
    def obnovit(self, kurs):
        pass

class bank_nablyudatel(i_nablyudatel):
    def obnovit(self, kurs):
        print(f"Bank obnovil kurs: {kurs}")

class trader_nablyudatel(i_nablyudatel):
    def obnovit(self, kurs):
        print(f"Trader obnovil kurs: {kurs}")

class investor_nablyudatel(i_nablyudatel):
    def obnovit(self, kurs):
        print(f"Investor obnovil kurs: {kurs}")

class valyutnyy_obmen:
    def __init__(self):
        self._nablyudateli = []
        self._kurs = None

    def dobavit_nablyudatel(self, nablyudatel):
        self._nablyudateli.append(nablyudatel)

    def ubrat_nablyudatel(self, nablyudatel):
        self._nablyudateli.remove(nablyudatel)

    def uvedomit_nablyudateley(self):
        for nablyudatel in self._nablyudateli:
            nablyudatel.obnovit(self._kurs)

    def ustanovit_kurs(self, kurs):
        self._kurs = kurs
        self.uvedomit_nablyudateley()

obmen = valyutnyy_obmen()
bank = bank_nablyudatel()
trader = trader_nablyudatel()
investor = investor_nablyudatel()

obmen.dobavit_nablyudatel(bank)
obmen.dobavit_nablyudatel(trader)
obmen.ustanovit_kurs(1.15)

obmen.dobavit_nablyudatel(investor)
obmen.ustanovit_kurs(1.20)

obmen.ubrat_nablyudatel(trader)
obmen.ustanovit_kurs(1.25)
