using PISBusinessLogic.Enums;
using PISBusinessLogic.HelperModels;
using PISBusinessLogic.Interfaces;
using PISBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PISBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IUserLogic _user;
        private readonly IBookLogic _book;
        private readonly IContractLogic _contract;
        public ReportLogic(IUserLogic user, IBookLogic book, IContractLogic contract)
        {
            this._user = user;
            _book = book;
            _contract = contract;
        }
        public void SaveBookToWordFile(string fileName, BookViewModel model)
        {
            string title = "Справка о наличии книги № " + model.Id;
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                book = model,
                libraryCard = null

            });
        }
        public void SaveListToWordFile(string fileName)
        {
            string title = "Список библиотекарей ";
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                UserFIO = GetUsers()
            });
        }
        public void SaveLibraryCardToWordFile(string fileName, LibraryCardViewModel model)
        {
            string title = "Читательский билет №" + model.Id;
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                libraryCard = model,
                book = null

            });
        }

        public void SaveContractReaderToWordFile(string fileName, ContractViewModel model)
        {
            string title = "Договор №  " + model.Id;
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                contract = model
            });
        }
        public void SaveContractToWordFile(string fileName, UserViewModel model)
        {
            string title = "Контракт с  " + model.FIO;
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                user = model

            });
        }
        public List<UserViewModel> GetUsers()
        {
            var list = new List<UserViewModel>();
            var users = _user.Read(null);
            foreach (var us in users)
            {
                if (us.Role == Roles.Библиотекарь)
                {
                    list.Add(us);
                }
            }
            return list;
        }

        public string GetGisto()
        {
            string path = $"D:\\Gisto{Guid.NewGuid()}.pdf";
            string title = "Sootnoshenie zabronirovannih knig k svobodnim";
            string Test3GistName = "Gisto";
            var legend = LocationLegend.BottomCenter;

            var bookedBooksCount = _book.Read(null).Where(rec => rec.Status == Status.Забронирована || rec.Status == Status.Выдана).Count();
            var freeBooksCount = _book.Read(null).Where(rec => rec.Status == Status.Свободна).Count();

            var gistogramInfo = new GistInfo();
            Dictionary<string, float[]> data = new Dictionary<string, float[]>();
            data.Add("Svobodnie", new float[] { freeBooksCount });
            data.Add("Zabronirovanie", new float[] { bookedBooksCount });
            gistogramInfo.Data = data;

            SaveToPdf.CreateGist(path, title, Test3GistName, legend, gistogramInfo);

            return path;
        }

        public string GetPerekTable(int? year = null)
        {
            if (year == null)
                year = DateTime.Now.Year;

            var path = $"D:\\Perek{Guid.NewGuid()}.pdf";

            var tableData = new List<TableReport>();
            var books = _book.Read(null);
            var contracts = _contract.Read(null).Where(rec => rec.Date.Year == year).ToList();
            foreach (var book in books)
            {
                var rowTableData = new TableReport();
                rowTableData.Book = $"{book.Name} {book.Author}";
                rowTableData.January = contracts.Where(rec => rec.Date.Month == 1 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.February = contracts.Where(rec => rec.Date.Month == 2 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.March = contracts.Where(rec => rec.Date.Month == 3 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.April = contracts.Where(rec => rec.Date.Month == 4 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.May = contracts.Where(rec => rec.Date.Month == 5 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.June = contracts.Where(rec => rec.Date.Month == 6 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.July = contracts.Where(rec => rec.Date.Month == 7 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.August = contracts.Where(rec => rec.Date.Month == 8 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.September = contracts.Where(rec => rec.Date.Month == 9 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.October = contracts.Where(rec => rec.Date.Month == 10 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.November = contracts.Where(rec => rec.Date.Month == 11 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                rowTableData.December = contracts.Where(rec => rec.Date.Month == 12 && rec.ContractBooks.FirstOrDefault(cb => cb.BookId == book.Id) != null).ToList().Count();
                tableData.Add(rowTableData);
            }

            tableData.Add(new TableReport
            {
                Book = "Total",
                January = tableData.Sum(rec => rec.January),
                February = tableData.Sum(rec => rec.February),
                March = tableData.Sum(rec => rec.March),
                April = tableData.Sum(rec => rec.April),
                May = tableData.Sum(rec => rec.May),
                June = tableData.Sum(rec => rec.June),
                July = tableData.Sum(rec => rec.July),
                August = tableData.Sum(rec => rec.August),
                September = tableData.Sum(rec => rec.September),
                October = tableData.Sum(rec => rec.October),
                November = tableData.Sum(rec => rec.November),
                December = tableData.Sum(rec => rec.December)
            });

            SaveToPdf.SaveTable(path, $"Perek Year {year}", tableData);

            return path;
        }
    }
}
