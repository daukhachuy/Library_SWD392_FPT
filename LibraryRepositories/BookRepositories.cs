using LibraryBussiness;
using LibraryDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRepositories
{
    public interface BookRepositories : IBookRepositories
    {
        public List<Book> GetAllBooks() => BookDao.GetAllBooks();
        public Book? GetBookById(int id) => BookDao.GetBookById(id);
        public void AddBook(Book book) => BookDao.AddBook(book);

        public void UpdateBook(Book book) => BookDao.UpdateBook(book);

        public void DeleteBook(Book book) => BookDao.DeleteBook(book);
    }
}
