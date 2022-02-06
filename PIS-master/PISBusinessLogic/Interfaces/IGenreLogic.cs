using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PISBusinessLogic.Interfaces
{
    public interface IGenreLogic
    {
        void CreateOrUpdate(GenreBindingModel model);
        void Delete(GenreBindingModel model);
        List<GenreViewModel> Read(GenreBindingModel model);
    }
}
