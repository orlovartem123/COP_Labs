using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PISBusinessLogic.Interfaces
{
    public interface IBookingLogic
    {
        void CreateOrUpdate(BookingBindingModel model);
        void Delete(BookingBindingModel model);
        List<BookingViewModel> Read(BookingBindingModel model);        
    }
}
