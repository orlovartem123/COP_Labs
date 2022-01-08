using Exam_My_Example.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Exam_My_Example.Database.Storages
{
    /// <summary>
    /// Класс-хранилище справочника 1
    /// </summary>
    internal class Spravochnik1Storage
    {
        /// <summary>
        /// Добавляет новый справочник в базу данных
        /// </summary>
        /// <param name="spravochnik"></param>
        public static void Add(Spravochnik1 spravochnik)
        {
            using (var db = new ExamDbContext())
            {
                db.Spravochnik1s.Add(spravochnik);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет справочник из базы данных по Id справочника
        /// </summary>
        /// <param name="spravochnikId"></param>
        public static void Delete(int spravochnikId)
        {
            using (var db = new ExamDbContext())
            {
                var obj = db.Spravochnik1s.FirstOrDefault(rec => rec.Id == spravochnikId);

                if (obj != null)
                {
                    db.Spravochnik1s.Remove(obj);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получает справочник по Id справочника
        /// </summary>
        /// <param name="spravochnikId"></param>
        /// <returns></returns>
        public static Spravochnik1 Get(int spravochnikId)
        {
            using (var db = new ExamDbContext())
            {
                return db.Spravochnik1s.FirstOrDefault(rec => rec.Id == spravochnikId);
            }
        }

        /// <summary>
        /// Редактирование справочника
        /// </summary>
        /// <param name="spravochnikId"></param>
        public static void Update(Spravochnik1 spravochnik)
        {
            using (var db = new ExamDbContext())
            {
                var obj = db.Spravochnik1s.FirstOrDefault(rec => rec.Id == spravochnik.Id);

                if (obj != null)
                {
                    obj.Fio = spravochnik.Fio;
                    obj.BirthDate = spravochnik.BirthDate;
                    obj.Gender = spravochnik.Gender;
                    obj.Address = spravochnik.Address;
                    obj.Contacts = spravochnik.Contacts;
                    obj.Comment = spravochnik.Comment;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получение всего списка справочников из базы данных
        /// </summary>
        /// <returns></returns>
        public static List<Spravochnik1> GetAll()
        {
            using (var db = new ExamDbContext())
            {
                return db.Spravochnik1s.ToList();
            }
        }
    }
}
