using LibraryBussiness;
using LibraryDataAccess;
using LibraryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryService
{
    public class Bookservice : IBookService
    {
        private readonly IBookRepositories _bookRepositories;

        private readonly Swd392Group2Context _context;
        public Bookservice(IBookRepositories bookRepositories)
        {
            _bookRepositories = bookRepositories;
        }
        public List<Book> GetAllBooks() => _bookRepositories.GetAllBooks();
        public Book? GetBookById(int id) => _bookRepositories.GetBookById(id);
        public void AddBook(Book book) => _bookRepositories.AddBook(book);

        public void UpdateBook(Book book) => _bookRepositories.UpdateBook(book);

        public bool DeleteBook(Book book)
        {
            var books = _bookRepositories.GetAllBooks().ToList();
            var borrowrecord = _context.BorrowRecords.FirstOrDefault(b => b.BookId == book.Id);
            if (borrowrecord == null )
            {
                _bookRepositories.DeleteBook(book);
                return  true;
            }
            else
            {
                return false;
            }

                
        }
        public bool IsBookAvailable(int bookId)
        {
            var book = _bookRepositories.GetBookById(bookId);
            return book != null && book.Availability == true && book.Quantity > 0;
        }

        public void DecreaseQuantity(int bookId)
        {
            var book = _bookRepositories.GetBookById(bookId);
            if (book != null && book.Quantity > 0)
            {
                book.Quantity--;
                if (book.Quantity == 0) book.Availability = false;
                _bookRepositories.UpdateBook(book);
            }
        }

        public void IncreaseQuantity(int bookId)
        {
            var book = _bookRepositories.GetBookById(bookId);
            if (book != null)
            {
                book.Quantity++;
                book.Availability = true;
                _bookRepositories.UpdateBook(book);
            }
        }

        public List<Book> GetAvailableBooks()
        {
            return _bookRepositories.GetAllBooks()
                .Where(b => b.Availability == true && b.Quantity > 0)
                .ToList();
        }

    }
}
