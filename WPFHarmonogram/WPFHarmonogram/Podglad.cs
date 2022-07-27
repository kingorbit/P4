using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHarmonogram
{
    public class Podglad
    {
        public int Id { get; set; } 
        public int ZlecenieId { get; set; }
        public int EtapId { get; set; }
        public DateTime Datarozpoczecia { get; set; }
        public DateTime Datazakonczenia { get; set; }
        public DateTime Aktualizacja { get; set; }

        public Podglad(int zlecenieId, int etapId, DateTime datarozpoczecia, DateTime datazakonczenia)
        {
            ZlecenieId = zlecenieId;
            EtapId = etapId;
            Datarozpoczecia = datarozpoczecia;
            Datazakonczenia = datazakonczenia;
            Aktualizacja = DateTime.Now;
        }

        public override string ToString()
        {
            return $" {ZlecenieId} {Datarozpoczecia} {Datazakonczenia} {EtapId} {Aktualizacja}";
        }
    }
}
