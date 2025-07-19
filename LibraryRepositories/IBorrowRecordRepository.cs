using LibraryBussiness;
using System.Collections.Generic;

namespace LibraryRepositories
{
    public interface IBorrowRecordRepository
    {
        List<BorrowRecord> GetAll();
        List<BorrowRecord> GetByUserId(int userId);
        BorrowRecord? GetById(int id);
        void Add(BorrowRecord record);
        void Return(int recordId, DateOnly returnDate);
        void Update(BorrowRecord record);
        //void SubmitReview(int borrowRecordId, int rating, string comment);


    }
}
