﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PISBusinessLogic.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public double Price { get; set; }
        public string Year { get; set; }
        public string PublishingHouse { get; set; }
        public Status Status { get; set; }
    }
}