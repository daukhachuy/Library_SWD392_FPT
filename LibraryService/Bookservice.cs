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



    }
}
