﻿using System;
using System.Collections.Generic;

namespace EFCore.WebAPi.Models
{
    public class Batalha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<HeroiBatalha> HeroiBatalhas { get; set; }
    }
}
