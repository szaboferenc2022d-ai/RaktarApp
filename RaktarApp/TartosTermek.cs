using System;
using System.Collections.Generic;
using System.Text;

namespace RaktarApp
{
    public class TartosTermek : Termek
    {
        int GaranciaEvek { get; set; }

        public TartosTermek(int garanciaevek, string cikkszam, int alapar) : base(cikkszam, alapar)
            {
            GaranciaEvek = garanciaevek;
            }

        public override int ErtekSzamitas(int darabszam)
        {
            return base.ErtekSzamitas(darabszam)+ (GaranciaEvek * 500 * darabszam);
        }

        public override string ToString()
        {
            return base.ToString() + $"| Garancia: {GaranciaEvek} év";
        } 
    }
}
