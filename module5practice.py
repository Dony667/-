from abc import ABC, abstractmethod

class Document(ABC):
    def open(self):
        pass

class Report(Document):
    def open(self):
        return "открытие отчета"

class Resume(Document):
    def open(self):
        return "открытие резюме"

class Letter(Document):
    def open(self):
        return "открытие письма"

class Invoice(Document):
    def open(self):
        return "открытие счета"

class DocumentFactory(ABC):
    def create_document(self):
        pass

class ReportFactory(DocumentFactory):
    def create_document(self):
        return Report()

class ResumeFactory(DocumentFactory):
    def create_document(self):
        return Resume()

class LetterFactory(DocumentFactory):
    def create_document(self):
        return Letter()

class InvoiceFactory(DocumentFactory):
    def create_document(self):
        return Invoice()

def main():
    document_type = input("введите тип документа (отчет, резюме, письмо, счет): ").strip().lower()
    
    factory_map = {
        'отчет': ReportFactory(),
        'резюме': ResumeFactory(),
        'письмо': LetterFactory(),
        'счет': InvoiceFactory()
    }
    
    factory = factory_map.get(document_type)
    if factory:
        document = factory.create_document()
        print(document.open())
    else:
        print("неправильный тип документа")

if __name__ == "__main__":
    main()
