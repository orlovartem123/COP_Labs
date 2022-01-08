using Exam_My_Example.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Exam_My_Example.Database.Storages
{
    /// <summary>
    /// Класс-хранилище справочника 2
    /// </summary>
    internal class Spravochnik2Storage
    {
        /// <summary>
        /// Добавляет новый справочник в базу данных
        /// </summary>
        /// <param name="spravochnik"></param>
        public static void Add(Spravochnik2 spravochnik)
        {
            using (var db = new ExamDbContext())
            {
                db.Spravochnik2s.Add(spravochnik);
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
                var obj = db.Spravochnik2s.FirstOrDefault(rec => rec.Id == spravochnikId);

                if (obj != null)
                {
                    db.Spravochnik2s.Remove(obj);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Редактирование справочника
        /// </summary>
        /// <param name="spravochnikId"></param>
        public static void Update(Spravochnik2 spravochnik)
        {
            using (var db = new ExamDbContext())
            {
                var obj = db.Spravochnik2s.FirstOrDefault(rec => rec.Id == spravochnik.Id);

                if (obj != null)
                {
                    obj.Fio = spravochnik.Fio;
                    obj.Otdelenie = spravochnik.Otdelenie;
                    obj.Doljnost = spravochnik.Doljnost;
                    obj.Category = spravochnik.Category;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получает справочник по Id справочника
        /// </summary>
        /// <param name="spravochnikId"></param>
        /// <returns></returns>
        public static Spravochnik2 Get(int spravochnikId)
        {
            using (var db = new ExamDbContext())
            {
                var obj = db.Spravochnik2s.FirstOrDefault(rec => rec.Id == spravochnikId);

                return obj;
            }
        }

        /// <summary>
        /// Получение всего списка справочников из базы данных
        /// </summary>
        /// <returns></returns>
        public static List<Spravochnik2> GetAll()
        {
            using (var db = new ExamDbContext())
            {
                return db.Spravochnik2s.ToList();
            }
        }
    }
}
