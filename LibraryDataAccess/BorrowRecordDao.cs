using LibraryBussiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryDataAccess
{
    public class BorrowRecordDao
    {
        public static List<BorrowRecord> GetAllBorrowRecords()
        {
            using var context = new Swd392Group2Context();
            return context.BorrowRecords
                          .Include(br => br.Book)
                          .Include(br => br.User)
                          .ToList();
        }

        public static List<BorrowRecord> GetByUserId(int userId)
        {
            using var context = new Swd392Group2Context();
            return context.BorrowRecords
                          .Include(br => br.Book)
                          .Where(br => br.UserId == userId)
                          .ToList();
        }

        public static BorrowRecord? GetById(int id)
        {
            using var context = new Swd392Group2Context();
            return context.BorrowRecords
                          .Include(br => br.Book)
                          .FirstOrDefault(br => br.Id == id);
        }

        public static void AddBorrowRecord(BorrowRecord record)
        {
            using var context = new Swd392Group2Context();
            context.BorrowRecords.Add(record);
            context.SaveChanges();
        }

        public static void ReturnBook(int recordId, DateOnly returnDate)
        {
            using var context = new Swd392Group2Context();
            var record = context.BorrowRecords
                                .Include(br => br.Book)
                                .FirstOrDefault(b => b.Id == recordId);

            if (record == null)
                throw new Exception("Không tìm thấy bản ghi mượn sách.");

            if (record.Status == "Returned")
                throw new Exception("Sách này đã được trả rồi.");

            // Cập nhật trạng thái trả
            record.ReturnDate = returnDate;
            record.Status = "Returned";

            // Tăng lại số lượng sách trong kho
            if (record.Book != null)
            {
                record.Book.Quantity += 1;
            }

            context.SaveChanges();
        }


        public static void UpdateBorrowRecord(BorrowRecord record)
        {
            using var context = new Swd392Group2Context();
            var existing = context.BorrowRecords.Find(record.Id);
            if (existing != null)
            {
                existing.ReturnDate = record.ReturnDate;
                existing.Status = record.Status; // 👈 thêm dòng này!
                context.SaveChanges();
            }
        }


        //public static void SubmitReview(int borrowRecordId, int rating, string comment)
        //{
        //    using var context = new Swd392Group2Context();
        //    var record = context.BorrowRecords.FirstOrDefault(x => x.Id == borrowRecordId);

        //    if (record == null || record.ReturnDate == null)
        //    {
        //        throw new Exception("Chỉ có thể đánh giá sau khi đã trả sách.");
        //    }

        //    // Kiểm tra đã đánh giá chưa
        //    if (record.Rating != null)
        //    {
        //        throw new Exception("Đã đánh giá rồi.");
        //    }

        //    record.Rating = rating;
        //    record.ReviewComment = comment;
        //    context.SaveChanges();
        //}
    }
}
