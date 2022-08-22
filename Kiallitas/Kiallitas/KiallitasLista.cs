namespace Kiallitas
{
    class KiallitasLista
    {
        class ListaElem
        {
            public IKiallitas Tartalom { get; set; }
            public ListaElem Kovetkezo { get; set; }
        }
        public delegate void MuveletHandler();
        public delegate bool FeltetelVizsgalo(IKiallitas kiallitas);
        public event MuveletHandler SikeresSzures;
        ListaElem fej;
        FeltetelVizsgalo SzuresTarhely = null;
        FeltetelVizsgalo IdealisSzuresTarhely = null;

        public void Beszuras(IKiallitas tartalom)
        {
            tartalom.Valtozas += Ujratervezes;
            ListaElem e = null;
            ListaElem p = fej;
            ListaElem uj = new ListaElem();
            uj.Tartalom = tartalom;
            while (p != null && string.Compare(p.Tartalom.Megnevezes, tartalom.Megnevezes) < 0)
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (e == null)
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else
            {
                uj.Kovetkezo = p;
                e.Kovetkezo = uj;
            }
        }

        public bool Tartalmaz(IKiallitas tartalom)
        {
            ListaElem p = fej;
            while (p != null)
            {
                if (p.Tartalom.Megnevezes == tartalom.Megnevezes
                    && p.Tartalom.Napok == tartalom.Napok)
                {
                    return true;
                }
                p = p.Kovetkezo;
            }
            return false;
        }

        public IKiallitas Kereses(string megnevezes)
        {
            ListaElem p = new ListaElem();
            while (p != null)
            {
                if (p.Tartalom.Megnevezes == megnevezes)
                {
                    return p.Tartalom;
                }
                p = p.Kovetkezo;
            }
            throw new NincsIlyenElemException();
        }

        public void Torles(FeltetelVizsgalo feltetel)
        {
            ListaElem e = null;
            ListaElem p = fej;

            while (p != null)
            {
                if (feltetel(p.Tartalom))
                {
                    if (e == null)
                    {
                        fej = p.Kovetkezo;
                    }
                    else
                    {
                        e.Kovetkezo = p.Kovetkezo;
                    }
                }
                e = p;
                p = p.Kovetkezo;
            }
        }

        public KiallitasLista Szures(FeltetelVizsgalo feltetel)
        {
            KiallitasLista reszLista = new KiallitasLista();
            ListaElem p = fej;
            while (p != null)
            {
                if (feltetel(p.Tartalom))
                {
                    reszLista.Beszuras(p.Tartalom);
                }
                p = p.Kovetkezo;
            }
            SzuresTarhely = feltetel;
            SikeresSzures();
            return reszLista;
        }


        public KiallitasLista IdealisSzures(FeltetelVizsgalo feltetel)
        {
            KiallitasLista eredmeny = new KiallitasLista();
            KiallitasLista legjobb = new KiallitasLista();
            BackTrack(fej, eredmeny, ref legjobb, feltetel);
            IdealisSzuresTarhely = feltetel;
            SikeresSzures();
            return legjobb;
        }
        private void BackTrack(ListaElem szint, KiallitasLista eredmeny,
            ref KiallitasLista legjobb, FeltetelVizsgalo feltetel)
        {
            ListaElem p = fej;
            while (p != null)
            {
                if (feltetel(p.Tartalom))
                {
                    if (Ft(p.Tartalom, eredmeny))
                    {
                        eredmeny.Beszuras(p.Tartalom);
                        if (szint != null)
                        {
                            if (legjobb.NapokSzama() < eredmeny.NapokSzama())
                            {
                                legjobb = eredmeny;
                            }
                            BackTrack(szint.Kovetkezo, eredmeny, ref legjobb, feltetel);
                        }
                    }
                }
                p = p.Kovetkezo;
            }
        }
        private int NapokSzama()
        {
            int n = 0;
            ListaElem p = fej;
            while (p != null)
            {
                n += p.Tartalom.Napok.Length;
                p = p.Kovetkezo;
            }
            return n;
        }

        private bool Ft(IKiallitas kiallitas, KiallitasLista eredmeny)
        {
            ListaElem p = eredmeny.fej;
            while (p != null)
            {
                if (p.Tartalom.Atfedi(kiallitas))
                {
                    return false;
                }
                p = p.Kovetkezo;
            }
            return true;            
        }
        public void Ujratervezes()
        {
            if (SzuresTarhely != null)
            {
                Szures(SzuresTarhely);
            }
            if (IdealisSzuresTarhely != null)
            {
                IdealisSzures(IdealisSzuresTarhely);
            }
        }
    }
}
