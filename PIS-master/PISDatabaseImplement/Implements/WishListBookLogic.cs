using Microsoft.EntityFrameworkCore;
using PISBusinessLogic.ViewModels;
using PISDatabaseimplements.Models;
using PISDatabaseImplements;
using System.Collections.Generic;
using System.Linq;

namespace PISDatabaseImplement.Implements
{
    public class WishListBookLogic
    {
        private static WishListBookViewModel CreateModel(WishListBook book)
        {
            return new WishListBookViewModel
            {
                BookName = book.Book.Name,
                Author = book.Book.Author,
                PublishingHouse = book.Book.PublishingHouse,
                Year = book.Book.Year,
                GenreName = book.Book.Genre.Name,
                Price = book.Book.Genre.Price
            };
        }

        public static List<WishListBookViewModel> GetWishListBookViewModels(int userId)
        {
            using (var db = new DatabaseContext())
            {
                return db.WishListBooks.Include(rec => rec.Book).ThenInclude(rec => rec.Genre).Where(rec => rec.UserId == userId).Select(CreateModel).ToList();
            }
        }

        public static void AddBookToWishList(int bookId, int userId)
        {
            using (var db = new DatabaseContext())
            {
                var model = new WishListBook
                {
                    UserId = userId,
                    BookId = bookId
                };
                db.WishListBooks.Add(model);
                db.SaveChanges();
            }
        }
    }
}
