namespace PISBusinessLogic.BindingModels
{
    public class ContractBookBindingModel
    {
        public int Id { get; set; }
        public double Fine { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public string Year { get; set; }
        public int GenreId { get; set; }
        public int BookId { get; set; }
        public int ContractId { get; set; }
        public Status Status { get; set; }

    }
}