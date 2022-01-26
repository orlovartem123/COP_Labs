using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PISBusinessLogic.Interfaces
{
    public interface IGenreLogic
    {
        void CreateOrUpdate(GenreBindingModel model);
        void Delete(GenreBindingModel model);
        List<GenreViewModel> Read(GenreBindingModel model);
    }
}
