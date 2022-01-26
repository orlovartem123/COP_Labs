using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PISBusinessLogic.Interfaces
{
    public interface IContractLogic
    {
        void CreateOrUpdate(ContractBindingModel model);
        void Delete(ContractBindingModel model);
        List<ContractViewModel> Read(ContractBindingModel model);
    }
}
