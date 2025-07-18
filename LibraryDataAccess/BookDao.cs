using LibraryBussiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccess
{
    public class BookDao
    {
        public static List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                using var _context = new Swd392Group2Context();
                books = _context.Books.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get all Users : {ex.Message}");
            }
            return books;
        }
        public static Book? GetBookById(int id)
        {
            Book? books = null;
            try
            {
                using var _context = new Swd392Group2Context();
                books = _context.Books.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get book by id : {ex.Message}");
            }
            return books;
        }
        public static void AddBook(Book book)
        {
            try
            {
                using var _context = new Swd392Group2Context();
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add book : {ex.Message}");
            }
        }

        public static void UpdateBook(Book book)
        {
            try
            {
                using var _context = new Swd392Group2Context();
                var update = _context.Books.FirstOrDefault(b => b.Id == book.Id);
                if (update != null)
                {
                    update.Author = book.Author;
                    update.Title = book.Title;
                    update.Description = book.Description;
                    update.CategoryId = book.CategoryId;
                    update.Availability = book.Availability;
                    update.Quantity = book.Quantity;
                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error update book : {ex.Message}");
            }
        }


        public static void  DeleteBook(Book book)
        {
            try
            {
                using var _context = new Swd392Group2Context();
                var delete = _context.Books.FirstOrDefault(b => b.Id == book.Id);
                if (delete != null)
                {
                    _context.Books.Remove(delete);
                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error delete book  : {ex.Message}");
            }
        }


    }
}
