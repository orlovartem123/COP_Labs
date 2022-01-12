using Microsoft.EntityFrameworkCore;
using PISBusinessLogic.HelperModels;
using PISDatabaseimplements.Models;
using PISDatabaseImplements;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PISDatabaseImplement.Implements
{
    public class ArchiveLogic
    {
        string exportDirectory = Directory.GetCurrentDirectory() + "\\wwwroot\\Export";
        string exportDirectory2 = Directory.GetCurrentDirectory() + "\\wwwroot\\Export2";
        public ArchiveLogic()
        {
        }

        private Book CreateBook(Book dbBook)
        {
            return new Book
            {
                Id = dbBook.Id,
                Name = dbBook.Name,
                Author = dbBook.Author,
                PublishingHouse = dbBook.PublishingHouse,
                Year = dbBook.Year,
                Status = dbBook.Status,
                GenreId = dbBook.GenreId,
                Genre = dbBook.Genre,
            };
        }

        private Payment CreatePayment(Payment payment)
        {
            return new Payment
            {
                Id = payment.Id,
                Sum = payment.Sum,
                Date = payment.Date,
                UserId = payment.UserId,
                Librarian = payment.Librarian
            };
        }

        private LibraryCard CreateLibraryCard(LibraryCard dbLc)
        {
            return new LibraryCard
            {
                Id = dbLc.Id,
                Year = dbLc.Year,
                PlaceOfWork = dbLc.PlaceOfWork,
                DateOfBirth = dbLc.DateOfBirth,
                Extension = dbLc.Extension,
                UserId = dbLc.UserId,
                Reader = dbLc.Reader
            };
        }
        public string ArchiveOutdated(int role)
        {
            DateTime curTime = DateTime.Now;

            string folderName = "";
            string fileName = "";
            if (role == 1)
            {
                folderName = exportDirectory + "\\Archive" + curTime.Day.ToString() + curTime.Month.ToString() + curTime.Year.ToString();
                fileName = $"{folderName}.zip";
            }
            if (role == 2)
            {
                folderName = exportDirectory2 + "\\Archive" + curTime.Day.ToString() + curTime.Month.ToString() + curTime.Year.ToString();
                fileName = $"{folderName}.zip";
            }

            Directory.CreateDirectory(folderName);
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderName);
                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                if (role == 1)
                {
                    var books = new List<Book>();
                    using (var db = new DatabaseContext())
                    {
                        books = db.Books.Include(x => x.Genre).Where(x => Convert.ToInt32(x.Year) < (DateTime.Now.Year - 10)).Select(CreateBook).ToList();
                    }

                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                    using (FileStream fs = new FileStream(string.Format("{0}/Books.json", folderName), FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, books);
                    }
                    var cards = new List<LibraryCard>();
                    using (var db = new DatabaseContext())
                    {
                        cards = db.LibraryCards.Include(x => x.Reader).Where(x => Convert.ToInt32(x.Year) < (DateTime.Now.Year - 5)).Select(CreateLibraryCard).ToList();
                    }
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<LibraryCard>));
                    using (FileStream fs = new FileStream(string.Format("{0}/LibraryCards.json", folderName), FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, cards);
                    }

                }
                if (role == 2)
                {
                    var payments = new List<Payment>();
                    using (var db = new DatabaseContext())
                    {
                        payments = db.Payments.Include(x => x.Librarian).Where(x => Convert.ToInt32(x.Date.Year) < (DateTime.Now.Year)).Select(CreatePayment).ToList();
                    }

                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Payment>));
                    using (FileStream fs = new FileStream(string.Format("{0}/Payments.json", folderName), FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, payments);
                    }
                }
                ZipFile.CreateFromDirectory(folderName, fileName);
                dirInfo.Delete(true);
            }
            catch (Exception ex)
            {
                throw;
            }
            return fileName;
        }
    }
}