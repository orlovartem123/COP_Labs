using Exam_My_Example.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_My_Example.Database
{
    /// <summary>
    /// Класс для соединения с базой данных
    /// </summary>
    internal class ExamDbContext : DbContext
    {
        const string DataSource = @"(localdb)\MSSQLLocalDB";

        //Если работает с первой строкой подключения то можно не менять UserId и Password
        const string UserId = "sa";

        const string Password = "MTsample1";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Data Source={DataSource};Initial Catalog=VLizaExamDb;Integrated Security=True;MultipleActiveResultSets=True;");

                //строка если не работает та что выше
                //optionsBuilder.UseSqlServer($@"Data Source={DataSource};Initial Catalog=VLizaExamDb;Persist Security Info=False;User ID={UserId};Password={Password};MultipleActiveResultSets=True;TrustServerCertificate=True;Connection Timeout=30;");

                //строка если надо подключиться к postgres (нужно поменять UserId и Password)
                //optionsBuilder.UseNpgsql($"Server=localhost;Port=5432;Database=VLizaExamDb;Username={UserId};Password={Password}");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Spravochnik1> Spravochnik1s { get; set; }

        public virtual DbSet<Spravochnik2> Spravochnik2s { get; set; }

        public virtual DbSet<Document1> Document1s { get; set; }
    }
}
