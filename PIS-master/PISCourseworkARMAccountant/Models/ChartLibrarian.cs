using System.ComponentModel;

namespace PISCourseworkARMAccountant.Models
{
    public class ChartLibrarian
    {
        public string UserFIO { get; set; }
        [DisplayName("Библиотекарь")]
        public int Sum { get; set; }
    }
}
