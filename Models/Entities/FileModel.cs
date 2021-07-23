using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webtonic.Models.Entities
{
    public class FileModel
    {
        [Display(Name = "Upload File")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase uploaFile { get; set; }
        public string Destination { get; set; }
    }
}