using Microsoft.EntityFrameworkCore;
using PISBusinessLogic.BindingModels;
using PISBusinessLogic.Interfaces;
using PISBusinessLogic.ViewModels;
using PISDatabaseimplements.Models;
using PISDatabaseImplements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PISDatabaseImplement.Implements
{
    public class BookLogic : IBookLogic
    {
        public void CreateOrUpdate(BookBindingModel model)
        {
            using (var context = new DatabaseContext())
            {
                Book element = model.Id.HasValue ? null : new Book();
                if (model.Id.HasValue)
                {
                    element = context.Books.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Book();
                    context.Books.Add(element);
                }
                element.Name = model.Name;
                element.Author = model.Author;
                element.Year = model.Year;
                element.PublishingHouse = model.PublishingHouse;
                element.GenreId = model.GenreId;
                element.Status = model.Status;
                element.Interes = model.Interes;
                context.SaveChanges();
            }
        }
        public void Delete(BookBindingModel model)
        {
            using (var context = new DatabaseContext())
            {
                Book element = context.Books.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Books.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<BookViewModel> Read(BookBindingModel model)
        {
            using (var context = new DatabaseContext())
            {
                return context.Books
                 .Where(rec => model == null
                   || rec.Id == model.Id || (rec.Name == model.Name && rec.Status == model.Status) || (rec.GenreId == model.GenreId && rec.Status == model.Status) || (rec.Author == model.Author && rec.Status == model.Status))
               .Select(rec => new BookViewModel
               {
                   Id = rec.Id,
                   Author = rec.Author,
                   Name = rec.Name,
                   PublishingHouse = rec.PublishingHouse,
                   Year = rec.Year,
                   GenreId = rec.GenreId,
                   Status = rec.Status
               })
                .ToList();
            }
        }

        public void UpdateInteres(int bookId)
        {
            using (var context = new DatabaseContext())
            {
                var elem = context.Books.FirstOrDefault(rec => rec.Id == bookId);
                var curDate = DateTime.Now;
                if (elem.InteresUpdateDate.Year < curDate.Year || elem.InteresUpdateDate.Month < curDate.Month)
                {
                    elem.InteresUpdateDate = curDate;
                    elem.Interes = 0;
                }
                elem.Interes++;
                context.SaveChanges();
            }
        }

        private void resetBooksInteresIfNeed()
        {
            using (var db = new DatabaseContext())
            {
                var curDate = DateTime.Now;
                foreach (var elem in db.Books)
                {
                    if (elem.InteresUpdateDate.Year < curDate.Year || elem.InteresUpdateDate.Month < curDate.Month)
                    {
                        elem.InteresUpdateDate = curDate;
                        elem.Interes = 0;
                    }
                }
                db.SaveChanges();
            }
        }

        public List<BookViewModel> GetTop10Books()
        {
            resetBooksInteresIfNeed();
            using (var context = new DatabaseContext())
            {
                return context.Books.Include(rec => rec.Genre).OrderByDescending(rec => rec.Interes).Take(10).Select(rec => new BookViewModel
                {
                    Id = rec.Id,
                    Author = rec.Author,
                    Name = rec.Name,
                    PublishingHouse = rec.PublishingHouse,
                    Year = rec.Year,
                    GenreId = rec.GenreId,
                    Status = rec.Status,
                    GenreName = rec.Genre.Name,
                    Price = rec.Genre.Price
                }).ToList();
            }
        }
    }
}
