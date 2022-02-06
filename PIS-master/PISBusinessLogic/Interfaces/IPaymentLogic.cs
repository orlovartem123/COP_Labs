using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PISBusinessLogic.Interfaces
{
    public interface IPaymentLogic
    {
        void CreateOrUpdate(PaymentBindingModel model);
        void Delete(PaymentBindingModel model);
        List<PaymentViewModel> Read(PaymentBindingModel model);
    }
}
