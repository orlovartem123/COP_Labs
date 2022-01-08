using Exam_My_Example.Database.Models;
using Exam_My_Example.Database.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Exam_My_Example.Database.Storages
{
    internal class Document1Storage
    {
        /// <summary>
        /// Добавляет новый документ в базу данных
        /// </summary>
        /// <param name="spravochnik"></param>
        public static void Add(Document1 document)
        {
            using (var db = new ExamDbContext())
            {
                db.Document1s.Add(document);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет документ из базы данных по Id документа
        /// </summary>
        /// <param name="spravochnikId"></param>
        public static void Delete(int docId)
        {
            using (var db = new ExamDbContext())
            {
                var obj = db.Document1s.FirstOrDefault(rec => rec.Id == docId);

                if (obj != null)
                {
                    db.Document1s.Remove(obj);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Редактирование документа
        /// </summary>
        /// <param name="spravochnikId"></param>
        public static void Update(Document1 document)
        {
            using (var db = new ExamDbContext())
            {
                var obj = db.Document1s.FirstOrDefault(rec => rec.Id == document.Id);

                if (obj != null)
                {
                    obj.Date = document.Date;
                    obj.TypePriema = document.TypePriema;
                    obj.Spravochnik1Id = document.Spravochnik1Id;
                    obj.Spravochnik2Id = document.Spravochnik2Id;
                    obj.Jalobi = document.Jalobi;
                    obj.Diagnoz = document.Diagnoz;
                    obj.Naznachenia = document.Naznachenia;
                    obj.DateVizdorovlenia = document.DateVizdorovlenia;

                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получает документ по Id документа
        /// </summary>
        /// <param name="spravochnikId"></param>
        /// <returns></returns>
        public static Document1 Get(int docId)
        {
            using (var db = new ExamDbContext())
            {
                return db.Document1s.Include(rec => rec.Spravochnik1).Include(rec => rec.Spravochnik2).FirstOrDefault(rec => rec.Id == docId);
            }
        }

        /// <summary>
        /// Получение всего списка документов из базы данных
        /// </summary>
        /// <returns></returns>
        public static List<Document1ViewModel> GetAll()
        {
            using (var db = new ExamDbContext())
            {
                return db.Document1s.Include(rec => rec.Spravochnik1).Include(rec => rec.Spravochnik2).Select(CreateModel).ToList();
            }
        }

        private static Document1ViewModel CreateModel(Document1 doc)
        {
            return new Document1ViewModel
            {
                Id = doc.Id,
                Date = doc.Date,
                TypePriema = doc.TypePriema,
                Spravochnik2Name = doc.Spravochnik2.Fio,
                Spravochnik1Name = doc.Spravochnik1.Fio,
                Jalobi = doc.Jalobi,
                Diagnoz = doc.Diagnoz,
                Naznachenia = doc.Naznachenia,
                DateVizdorovlenia = doc.DateVizdorovlenia
            };
        }
    }
}
