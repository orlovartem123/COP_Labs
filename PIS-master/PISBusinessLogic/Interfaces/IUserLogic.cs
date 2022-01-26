using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PISBusinessLogic.Interfaces
{
    public interface IUserLogic
    {
        void CreateOrUpdate(UserBindingModel model);
        void Delete(UserBindingModel model);
        List<UserViewModel> Read(UserBindingModel model);
    }
}
