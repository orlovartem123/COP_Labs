using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PISBusinessLogic.Interfaces
{
    public interface IPaymentLogic
    {
        void CreateOrUpdate(PaymentBindingModel model);
        void Delete(PaymentBindingModel model);
        List<PaymentViewModel> Read(PaymentBindingModel model);
    }
}
