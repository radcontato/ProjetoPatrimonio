using System.Collections.Generic;

namespace EFCore.WebAPi.Models.HeroiApp
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IdentidadeSecreta IdentidadeSecreta { get; set; }
        public List<Arma> Armas { get; set; }
        public List<HeroiBatalha> HeroiBatalhas { get; set; }

    }
}
