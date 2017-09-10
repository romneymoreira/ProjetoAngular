﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoApi.Models
{
    public class ContaViewModel
    {
        public int IdConta { get; set; }
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        public string Situacao { get; set; }
    }
}