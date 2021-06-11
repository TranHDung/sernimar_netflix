﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.Models
{
    public class Selectable<T>
    {
        public T Item { get; set; }
        public bool Selected { get; set; }
    }
}
