using System;

namespace Kiallitas
{
    class Program
    {
        static void Write()
        {
            Console.WriteLine("Szűrés elvégezve");
        }
        static void Main(string[] args)
        {
            AlkalmiKiallitas kiallitas1 = new AlkalmiKiallitas(63, "Ernő", true, Ismeretseg.Helyi);
            IdoszakosKiallitas kiallitas2 = new IdoszakosKiallitas(23, 200, "Dante", true, Ismeretseg.Helyi);
            AlkalmiKiallitas kiallitas3 = new AlkalmiKiallitas(23, "Robi", true, Ismeretseg.Országos);
            AlkalmiKiallitas kiallitas4 = new AlkalmiKiallitas(63, "Géza", true, Ismeretseg.Helyi);
            TobbNaposKiallitas kiallitas5 = new TobbNaposKiallitas(new int[]{2, 3, 4, 5, 16, 70, 170, 300, 365} ,"Laci",false,Ismeretseg.Helyi);
            TobbNaposKiallitas kiallitas6 = new TobbNaposKiallitas(new int[] {63, 41 },"Fecó",true,Ismeretseg.Helyi);
            TobbNaposKiallitas kiallitas7 = new TobbNaposKiallitas(new int[] {300,123,10 },"Aranka",true,Ismeretseg.Nemzetközi);
            AllandoKiallitas kiallitas8 = new AllandoKiallitas("Reni",true,Ismeretseg.Helyi);
            IdoszakosKiallitas kiallitas9 = new IdoszakosKiallitas(63, 64,"Bonaventúra",true,Ismeretseg.Helyi);
            AlkalmiKiallitas kiallitas10 = new AlkalmiKiallitas(320,"Gizi",true,Ismeretseg.Helyi);
            IdoszakosKiallitas kiallitas11 = new IdoszakosKiallitas(10,12,"Lajos",false,Ismeretseg.Országos);
            IdoszakosKiallitas kiallitas12 = new IdoszakosKiallitas(80,123,"Árpi",true,Ismeretseg.Helyi);
            AlkalmiKiallitas kiallitas13 = new AlkalmiKiallitas(63,"Erika",true,Ismeretseg.Helyi);
            AlkalmiKiallitas kiallitas14 = new AlkalmiKiallitas(100,"Fanni",false,Ismeretseg.Helyi);
            AlkalmiKiallitas kiallitas15 = new AlkalmiKiallitas(300,"Jani",false,Ismeretseg.Nemzetközi);
            AlkalmiKiallitas kiallitas16 = new AlkalmiKiallitas(50,"Erzsi",false,Ismeretseg.Helyi);
            AlkalmiKiallitas kiallitas17 = new AlkalmiKiallitas(80,"Luca",true,Ismeretseg.Helyi);

            KiallitasLista lista = new KiallitasLista();
            lista.SikeresSzures += Write;
            lista.Beszuras(kiallitas1);
            lista.Beszuras(kiallitas2);
            lista.Beszuras(kiallitas3);
            lista.Beszuras(kiallitas4);
            lista.Beszuras(kiallitas5);
            lista.Beszuras(kiallitas6);
            lista.Beszuras(kiallitas7);
            lista.Beszuras(kiallitas8);
            lista.Beszuras(kiallitas9);
            lista.Beszuras(kiallitas10);
            lista.Beszuras(kiallitas11);
            lista.Beszuras(kiallitas12);
            lista.Beszuras(kiallitas13);
            lista.Beszuras(kiallitas14);
            lista.Beszuras(kiallitas15);
            lista.Beszuras(kiallitas16);
            lista.Beszuras(kiallitas17);

            lista.Torles(Feltetel("Luca",null,null));
            lista.Torles(Feltetel("Jani",null,null));
            lista.Torles(Feltetel("Erzsi",null,null));
            KiallitasLista szurt = lista.Szures(Feltetel(null,false,null));
            KiallitasLista extraszurt = lista.IdealisSzures(Feltetel(null,null,Ismeretseg.Helyi));
            ;
            kiallitas1.IdopontValtoztatas(1, 2);
        }

        static KiallitasLista.FeltetelVizsgalo Feltetel(string megnevezes, bool? eloadas, Ismeretseg? ismeretseg)
        {
            bool Metodus1(IKiallitas kiallitas) { return kiallitas.Megnevezes.Contains(megnevezes); }
            bool Metodus2(IKiallitas kiallitas) { return kiallitas.Eloadas == eloadas; }
            bool Metodus3(IKiallitas kiallitas) { return kiallitas.Ismeretseg == ismeretseg; }
            bool Metodus4(IKiallitas kiallitas) { return kiallitas.Megnevezes.Contains(megnevezes) && kiallitas.Eloadas == eloadas; }
            bool Metodus5(IKiallitas kiallitas) { return kiallitas.Megnevezes.Contains(megnevezes) && kiallitas.Ismeretseg == ismeretseg; }
            bool Metodus6(IKiallitas kiallitas) { return kiallitas.Eloadas == eloadas && kiallitas.Ismeretseg == ismeretseg; }
            bool Metodus7(IKiallitas kiallitas) { return kiallitas.Megnevezes.Contains(megnevezes) && kiallitas.Eloadas == eloadas && kiallitas.Ismeretseg == ismeretseg; }
            if (megnevezes != null && eloadas == null && ismeretseg == null) { return Metodus1; }
            else if (megnevezes == null && eloadas != null && ismeretseg == null) { return Metodus2; }
            else if (megnevezes == null && eloadas == null && ismeretseg != null) { return Metodus3; }
            else if (megnevezes != null && eloadas != null && ismeretseg == null) { return Metodus4; }
            else if (megnevezes != null && eloadas == null && ismeretseg != null) { return Metodus5; }
            else if (megnevezes == null && eloadas != null && ismeretseg != null) { return Metodus6; }
            else { return Metodus7; }
            
        }
    }
}
