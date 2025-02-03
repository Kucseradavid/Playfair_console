namespace Playfair_console
{
    class PlayfairKodolo
    {
        char[,] kulcstabla = new char[5, 5];

        public PlayfairKodolo(string fajlnev)
        {
            //A kulcstábla fájlt ugyanabba a mappába kéri mint amiben a programfájl található
            //(ez a programfájl)
            StreamReader fajl = new StreamReader("../../../" + fajlnev);

            int i = 0;

            while (!fajl.EndOfStream)
            {
                var sor = fajl.ReadLine();

                for (int j = 0; j < 5; j++)
                {
                    kulcstabla[i, j] = sor[j];
                }

                i++;
            }

            fajl.Close();
        }

        public int SorIndex(char betu)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.kulcstabla[i, j] == betu)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int OszlopIndex(char betu)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.kulcstabla[i, j] == betu)
                    {
                        return j;
                    }
                }
            }

            return -1;
        }

        public char[] KodolBetupar(char[] betupar)
        {
            int[] elsoBetuIndex = { this.SorIndex(betupar[0]), this.OszlopIndex(betupar[0]) };
            int[] masodikBetuIndex = { this.SorIndex(betupar[1]), this.OszlopIndex(betupar[1]) };

            int[] elsoKodoltIndex = elsoBetuIndex;
            int[] masodikKodoltIndex = masodikBetuIndex;
            
            /*char[] tempo = { this.kulcstabla[masodikBetuIndexek[0], masodikBetuIndexek[1]], this.kulcstabla[elsoBetuIndexek[0], elsoBetuIndexek[1]] };*/

            //egy sorban való eltolás
            if (elsoBetuIndex[0] == masodikBetuIndex[0])
            {
                if (elsoBetuIndex[1] != 4) elsoKodoltIndex[1]++;
                else elsoKodoltIndex[1] = 0;

                if (masodikBetuIndex[1] != 4) masodikKodoltIndex[1]++;
                else masodikKodoltIndex[1] = 0;
            }

            //egy oszloopban való eltolás
            else if (elsoBetuIndex[1] == masodikBetuIndex[1])
            {
                if (elsoBetuIndex[0] != 4) elsoKodoltIndex[0]++;
                else elsoKodoltIndex[0] = 0;

                if (masodikBetuIndex[0] != 4) masodikKodoltIndex[0]++;
                else masodikKodoltIndex[0] = 0;
            }

            //téglalapos megoldás
            else
            {
                //elsoKodoltIndex[0] = elsoBetuIndex[0];
                elsoKodoltIndex[1] = masodikBetuIndex[1];
                //masodikKodoltIndex[0] = masodikBetuIndex[0];
                masodikKodoltIndex[1] = elsoBetuIndex[1];

                //Itt valami nem stimmel, az elsoBetuIndex értéket változtat bármi nélkül és emiatt
                //nem működik megfelelően a 7. feladat c része alapján
            }

            return [this.kulcstabla[elsoKodoltIndex[0], elsoKodoltIndex[1]], this.kulcstabla[masodikKodoltIndex[0], masodikKodoltIndex[1]]];
        }

        public void TestingPurposes()
        {
            //bejárás teszt
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(this.kulcstabla[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Worlh!");
            Console.WriteLine();

            PlayfairKodolo kod = new PlayfairKodolo("kulcstabla.txt");

            //kod.TestingPurposes();

            Console.WriteLine("6. feladat:");
            Console.Write("Kérek egy nagybetűt: ");
            char karakter = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"{karakter} sor: {kod.SorIndex(karakter)}, oszlop: {kod.OszlopIndex(karakter)}");
            Console.WriteLine();

            //char[] EX = { 'E', 'X' };
            //char[] MR = { 'M', 'R' };
            //char[] ED = { 'E', 'D' };
            //char[] EV = { 'E', 'V' };
            //char[] NX = { 'N', 'X' };
            //Console.WriteLine($"Tesztelés:");
            //Console.WriteLine($"soros tolás 1:  EX --> {kod.KodolBetupar(EX)[0]}{kod.KodolBetupar(EX)[1]}");
            //Console.WriteLine($"soros tolás 2:  MR --> {kod.KodolBetupar(MR)[0]}{kod.KodolBetupar(MR)[1]}");
            //Console.WriteLine($"oszlop tolás 1: ED --> {kod.KodolBetupar(ED)[0]}{kod.KodolBetupar(ED)[1]}");
            //Console.WriteLine($"oszlop tolás 2: EV --> {kod.KodolBetupar(EV)[0]}{kod.KodolBetupar(EV)[1]}");
            //Console.WriteLine($"négyszög tolás: NX --> {kod.KodolBetupar(NX)[0]}{kod.KodolBetupar(NX)[1]}");

            Console.WriteLine("8. feladat:");
            Console.Write("Kérek egy karakterpárt: ");
            string bekertSzoveg = Console.ReadLine();
            char[] nyers = { bekertSzoveg[0], bekertSzoveg[1] };
            char[] kodolt = kod.KodolBetupar(nyers);
            Console.WriteLine($"Kódolva: {kodolt[0]}{kodolt[1]}");
            Console.WriteLine();
            
            /*char[] test = { 'N', 'X' }; //testing
            Console.WriteLine(test[0] + " " + test[1]);
            char[] ford = kod.KodolBetupar(test);
            Console.WriteLine(ford[0] + " " + ford[1]);*/
        }
    }
}
