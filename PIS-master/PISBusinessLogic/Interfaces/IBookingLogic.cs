using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PISBusinessLogic.Interfaces
{
    public interface IBookingLogic
    {
        void CreateOrUpdate(BookingBindingModel model);
        void Delete(BookingBindingModel model);
        List<BookingViewModel> Read(BookingBindingModel model);        
    }
}
