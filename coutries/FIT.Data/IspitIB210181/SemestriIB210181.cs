﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB210181
{
    public class SemestriIB210181
    {
        public int Id { get; set; }
        public string Oznaka { get; set; }
        public string Opis { get; set; }
        public bool Aktivan { get; set; }
        public override string ToString()
        {
            return Oznaka;
        }
    }
}
