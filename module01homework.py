class Book:
    def __init__(self, title, author, isbn, copies):
        self.title, self.author, self.isbn, self.copies = title, author, isbn, copies


class Reader:
    def __init__(self, name, reader_id):
        self.name, self.reader_id, self.borrowed_books = name, reader_id, []


class Library:
    def __init__(self):
        self.books, self.readers = [], []

    def add_book(self, book):
        self.books.append(book)

    def remove_book(self, isbn):
        self.books = [b for b in self.books if b.isbn != isbn]

    def register_reader(self, reader):
        self.readers.append(reader)

    def remove_reader(self, reader_id):
        self.readers = [r for r in self.readers if r.reader_id != reader_id]

    def lend_book(self, isbn, reader_id):
        reader, book = self._find_reader(reader_id), self._find_book(isbn)
        if book and reader and book.copies > 0:
            book.copies -= 1
            reader.borrowed_books.append(book)

    def return_book(self, isbn, reader_id):
        reader = self._find_reader(reader_id)
        if reader:
            book = self._find_borrowed_book(isbn, reader)
            if book:
                book.copies += 1
                reader.borrowed_books.remove(book)

    def _find_reader(self, reader_id):
        return next((r for r in self.readers if r.reader_id == reader_id), None)

    def _find_book(self, isbn):
        return next((b for b in self.books if b.isbn == isbn), None)

    def _find_borrowed_book(self, isbn, reader):
        return next((b for b in reader.borrowed_books if b.isbn == isbn), None)


def main():
    lib = Library()
    lib.add_book(Book("1", "patrik", "123", 5))
    lib.register_reader(Reader("spongbek", 1))

    lib.lend_book("123", 1)
    lib.return_book("123", 1)
    lib.remove_book("123")


if __name__ == "__main__":
    main()
