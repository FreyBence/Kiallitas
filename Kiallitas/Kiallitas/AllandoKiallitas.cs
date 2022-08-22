using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    class AllandoKiallitas : IKiallitas
    {
        public AllandoKiallitas(string megnevezes, bool eloadas, Ismeretseg ismeretseg)
        {
            Megnevezes = megnevezes;
            Eloadas = eloadas;
            Ismeretseg = ismeretseg;
            Napok = new int[365/7];
            for (int i = 0; i < Napok.Length; i++)
            {
                Napok[i] = i * 7 - 1;
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
                if (kiallitas.Napok[i]%7 == 6)
                {
                    return true;
                }
            }
            return false;
        }

        public void IdopontValtoztatas(int inne , int ide)
        {
            throw new NemValtoztathatoException();
        }

        public bool VaneAznap(int nap)
        {
            return nap%7 == 6;
        }
    }
}
