using LibraryBussiness;
using System.Collections.Generic;

namespace LibraryService
{
    public interface IBorrowRecordService
    {
        List<BorrowRecord> GetAll();
        List<BorrowRecord> GetByUserId(int userId);
        BorrowRecord? GetById(int id);
        void BorrowBook(int userId, int bookId);
        void ReturnBook(int recordId);
        void CreateBorrowRecord(BorrowRecord record);
        void MarkAsReturned(int recordId);
        List<BorrowRecord> GetUnreturnedRecordsByUser(int userId);

        //void SubmitReview(int borrowRecordId, int rating, string comment);

    }
}
