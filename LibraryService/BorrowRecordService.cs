using LibraryBussiness;
using LibraryRepositories;
using System;
using System.Collections.Generic;

namespace LibraryService
{
    public class BorrowRecordService : IBorrowRecordService
    {
        private readonly IBorrowRecordRepository _borrowRepo;
        private readonly IBookRepositories _bookRepo;

        public BorrowRecordService(IBorrowRecordRepository borrowRepo, IBookRepositories bookRepo)
        {
            _borrowRepo = borrowRepo;
            _bookRepo = bookRepo;
        }

        public List<BorrowRecord> GetAll() => _borrowRepo.GetAll();

        public List<BorrowRecord> GetByUserId(int userId) => _borrowRepo.GetByUserId(userId);

        public BorrowRecord? GetById(int id) => _borrowRepo.GetById(id);

        public void BorrowBook(int userId, int bookId)
        {
            var book = _bookRepo.GetBookById(bookId);
            if (book == null || book.Quantity <= 0 || book.Availability == false)
                throw new InvalidOperationException("Book is not available.");

            var record = new BorrowRecord
            {
                UserId = userId,
                BookId = bookId,
                BorrowDate = DateOnly.FromDateTime(DateTime.Now),
                DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                Status = "Borrowed"
            };

            _borrowRepo.Add(record);
            book.Quantity -= 1;
            if (book.Quantity == 0) book.Availability = false;
            _bookRepo.UpdateBook(book);
        }

        public void ReturnBook(int recordId, DateOnly returnDate)
        {
            var record = _borrowRepo.GetById(recordId);
            if (record == null || record.Status == "Returned") return;

            _borrowRepo.Return(recordId, returnDate);

            var book = record.Book;
            if (book != null)
            {
                book.Quantity += 1;
                book.Availability = true;
                _bookRepo.UpdateBook(book);
            }
        }

        public void CreateBorrowRecord(BorrowRecord record)
        {
            _borrowRepo.Add(record);
        }

        public void MarkAsReturned(int recordId)
        {
            var record = _borrowRepo.GetById(recordId);
            if (record != null && record.Status != "Returned")
            {
                record.Status = "Returned";
                record.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
                _borrowRepo.Update(record);

                var book = record.Book;
                if (book != null)
                {
                    book.Quantity += 1;
                    book.Availability = true;
                    _bookRepo.UpdateBook(book);
                }
            }
        }

        public List<BorrowRecord> GetUnreturnedRecordsByUser(int userId)
        {
            return _borrowRepo.GetByUserId(userId)
                .Where(r => r.Status != "Returned")
                .ToList();
        }

    }


        //public void SubmitReview(int borrowRecordId, int rating, string comment)
        //{
        //    if (rating < 1 || rating > 5)
        //    {
        //        throw new Exception("Rating phải từ 1 đến 5.");
        //    }

        //    _borrowRepo.SubmitReview(borrowRecordId, rating, comment);
        //}
}