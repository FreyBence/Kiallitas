using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    class TobbNaposKiallitas : IKiallitas
    {
        public TobbNaposKiallitas(int[] napok, string megnevezes, bool eloadas, Ismeretseg ismeretseg)
        {
            Megnevezes = megnevezes;
            Eloadas = eloadas;
            Ismeretseg = ismeretseg;
            this.Napok = napok;
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
                for (int j = 0; j < Napok.Length; j++)
                {
                    if (kiallitas.Napok[i] == Napok[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void IdopontValtoztatas(int innen, int ide)
        {
            if (Tartalmaz(Napok,ide))
            {
                throw new VanIlyenException();
            }
            else if (!Tartalmaz(Napok, innen))
            {
                throw new NincsIlyenElemException();
            }
            else
            {
                for (int i = 0; i < Napok.Length; i++)
                {
                    if (Napok[i]== innen)
                    {
                        Napok[i] = ide;
                        Valtozas();
                    }
                }
            }
        }

        public bool VaneAznap(int nap)
        {
            for (int i = 0; i < Napok.Length; i++)
            {
                if (Napok[i] == nap)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Tartalmaz(int[] tomb, int elem)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] == elem)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
