
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace PISBusinessLogic.HelperModels
{
    class WordParagraphProperties
    {
        public JustificationValues JustificationValues { get; set; }
        public bool Bold { get; set; }
        public string Size { get; set; }
    }
}
