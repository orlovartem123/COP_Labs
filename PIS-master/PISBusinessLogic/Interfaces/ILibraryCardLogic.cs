using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PISBusinessLogic.Interfaces
{
    public interface ILibraryCardLogic
    {
        void CreateOrUpdate(LibraryCardBindingModel model);
        void Delete(LibraryCardBindingModel model);
        List<LibraryCardViewModel> Read(LibraryCardBindingModel model);
    }
}
