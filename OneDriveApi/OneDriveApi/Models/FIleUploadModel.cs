using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneDriveDeneme_23_02_2018.Models
{
    public class FIleUploadModel
    {
        [DataType(DataType.Upload)]
        public string file { get; set; }

    }
}