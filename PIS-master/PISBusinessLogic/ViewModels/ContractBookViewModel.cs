﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PISBusinessLogic.ViewModels
{
    public class ContractBookViewModel
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public string Year { get; set; }
        public int BookId { get; set; }
        public int ContractId { get; set; }
    }
}