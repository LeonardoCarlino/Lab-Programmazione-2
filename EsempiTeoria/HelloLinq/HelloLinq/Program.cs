using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeri = new List<int> {1 ,2, 3, 4, 5, 6 };
            List<Studente> studenti = new List<Studente>();
            studenti.Add(new Studente("Giuseppe", 134));
            studenti.Add(new Studente("Simona", 105));

            // vogliamo estrapolare i numeri pari della lista numeri
            // ToList() trasforma l'oggetto Ienumerable in lista
            List<int> pari = numeri.Where(x => x % 2 == 0).ToList();

            var nomi = studenti.Select(x => x.Nome).ToList();

            foreach(string s in nomi)
            {
                Console.WriteLine(s);
            }
        }
    }
}
