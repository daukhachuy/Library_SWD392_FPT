using LibraryBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRepositories
{
    public interface IBookRepositories
    {

          List<Book> GetAllBooks();
          Book? GetBookById(int id);
          void AddBook(Book book);

          void UpdateBook(Book book);

          void DeleteBook(Book book);
    }
}
