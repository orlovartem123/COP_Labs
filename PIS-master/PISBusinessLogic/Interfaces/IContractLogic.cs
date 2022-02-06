using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PISBusinessLogic.Interfaces
{
    public interface IContractLogic
    {
        void CreateOrUpdate(ContractBindingModel model);
        void Delete(ContractBindingModel model);
        List<ContractViewModel> Read(ContractBindingModel model);
    }
}
