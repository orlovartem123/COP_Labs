using System.ComponentModel;

namespace PISCoursework.Models
{
    public class Chart
    {
        public string GenreName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
