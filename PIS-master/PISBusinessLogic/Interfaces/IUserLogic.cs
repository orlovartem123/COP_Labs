using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PISBusinessLogic.Interfaces
{
    public interface IUserLogic
    {
        void CreateOrUpdate(UserBindingModel model);
        void Delete(UserBindingModel model);
        List<UserViewModel> Read(UserBindingModel model);
    }
}
