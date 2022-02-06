﻿using PISBusinessLogic.BindingModels;
using PISBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PISBusinessLogic.Interfaces
{
    public interface IBookLogic
    {
        void CreateOrUpdate(BookBindingModel model);
        void Delete(BookBindingModel model);
        void UpdateInteres(int bookId);
        List<BookViewModel> Read(BookBindingModel model);  
        List<BookViewModel> GetTop10Books();
    }
}
