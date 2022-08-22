using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    class IdoszakosKiallitas : IKiallitas
    {
        int ettol;
        int eddig;

        public IdoszakosKiallitas(int innen, int eddig, string megnevezes, bool eloadas, Ismeretseg ismeretseg)
        {
            this.ettol = innen;
            this.eddig = eddig;
            Megnevezes = megnevezes;
            Eloadas = eloadas;
            Ismeretseg = ismeretseg;
            Napok = new int[eddig - innen];
            for (int i = 0; i < Napok.Length; i++)
            {
                Napok[i] = i +1 + innen;
            }
        }

        public string Megnevezes { get; set; }
        public bool Eloadas { get; set; }
        public Ismeretseg Ismeretseg { get; set; }
        public int[] Napok { get; set; }

        public event ValtozasEventHandler Valtozas;

        public bool Atfedi(IKiallitas kiallitas)
        {
            for (int i = 0; i < kiallitas.Napok.Length; i++)
            {
                if (kiallitas.Napok[i] >= ettol && kiallitas.Napok[i] <= eddig)
                {
                    return true;
                }
            }
            return false;
        }

        public void IdopontValtoztatas(int innen, int ide)
        {
            ettol = innen;
            eddig = ide;
         
            Napok = new int[eddig - innen];
            for (int i = 0; i < Napok.Length; i++)
            {
                Napok[i] = i + 1 + innen;
            }
            Valtozas();
        }

        public bool VaneAznap(int nap)
        {
            return ettol <= nap && eddig >= nap;
        }
    }
}
