﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.ViewModels
{
    public class EditSelectViewModel
    {
        [Required]
        public String NewElement1 { get; set; }
        public Dictionary<string, string> TheDictionary { get; set; }
    }
}
