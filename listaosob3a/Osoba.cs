using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaosob3a
{
    public class Osoba : ICloneable
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime Dataur { get; set; }

        public Osoba(string imie, string nazwisko, DateTime dataur)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Dataur = dataur;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
