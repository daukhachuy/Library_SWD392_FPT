using LibraryBussiness;
using LibraryDataAccess;
using System.Collections.Generic;

namespace LibraryRepositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        public List<BorrowRecord> GetAll() => BorrowRecordDao.GetAllBorrowRecords();

        public List<BorrowRecord> GetByUserId(int userId) => BorrowRecordDao.GetByUserId(userId);

        public BorrowRecord? GetById(int id) => BorrowRecordDao.GetById(id);

        public void Add(BorrowRecord record) => BorrowRecordDao.AddBorrowRecord(record);

        public void Return(int recordId, DateOnly returnDate) => BorrowRecordDao.ReturnBook(recordId, returnDate);
        public void Update(BorrowRecord record) => BorrowRecordDao.UpdateBorrowRecord(record);

        //public void SubmitReview(int borrowRecordId, int rating, string comment)
        //=> BorrowRecordDao.SubmitReview(borrowRecordId, rating, comment);
    }
}
