using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    public enum Ismeretseg { Helyi , Országos , Nemzetközi};
    public delegate void ValtozasEventHandler();
    interface IKiallitas
    {
        public event ValtozasEventHandler Valtozas;
        public string Megnevezes { get; set; }
        public bool Eloadas { get; set; }
        public Ismeretseg Ismeretseg { get; set; }

        public int[] Napok { get; set; }

        public bool VaneAznap(int nap);
        public bool Atfedi(IKiallitas kiallitas);

        public void IdopontValtoztatas(int innen, int ide);
    }
}
