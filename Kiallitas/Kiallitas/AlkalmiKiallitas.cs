using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    class AlkalmiKiallitas : IKiallitas
    {        
        public AlkalmiKiallitas(int nap, string megnevezes, bool eloadas, Ismeretseg ismeretseg)
        {
            Megnevezes = megnevezes;
            Eloadas = eloadas;
            Ismeretseg = ismeretseg;
            Napok = new int[] {nap};
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
                if (kiallitas.Napok[i] == Napok[0])
                {
                    return true;
                }
            }
            return false;
        }

        public void IdopontValtoztatas(int innen, int ide)
        {
            if (Napok[0] == ide)
            {
                throw new VanIlyenException();
            }
            else
            {
                Napok[0] = ide;
                Valtozas();
            }
            
        }

        public bool VaneAznap(int nap)
        {
            return nap == Napok[0];
        }
    }
}
