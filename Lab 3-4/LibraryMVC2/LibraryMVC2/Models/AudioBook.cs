﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class AudioBook : Book
    {
        [Required]
        public int ReadingTime { get; set; }

    }
}