using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aoc2021_3
{
    class Program
    {
        static int Gyakorisag(IEnumerable<string> t, int i, char c) => t.Count(x => x[i] == c);
        static char Gyakoribb(IEnumerable<string> t, int i) => Gyakorisag(t, i, '1') >= Gyakorisag(t, i, '0') ? '1' : '0';
        static IEnumerable<string> O_szűrő(IEnumerable<string> t, int i)
        {
            char gyakoribb = Gyakoribb(t, i);
            return t.Where(x => x[i] == gyakoribb);
        }
        static IEnumerable<string> CO2_szűrő(IEnumerable<string> t, int i)
        {
            char ritkább = Gyakoribb(t, i)=='1'?'0':'1';
            return t.Where(x => x[i] == ritkább);
        }
        static IEnumerable<string> Megold(IEnumerable<string> t, Func<IEnumerable<string>, int, IEnumerable<string>> szűrő,int i = 0) => t.Count() <= 1 ? t : Megold(szűrő(t, i), szűrő, i + 1);

        static void Main(string[] args)
        {
            /** /
            string[] tomb = File.ReadAllLines("teszt.txt");
            /*/
            string[] tomb = File.ReadAllLines("input.txt");
            /**/
            ;

            Console.WriteLine(Convert.ToInt32(Megold(tomb, O_szűrő).First(), 2)* Convert.ToInt32(Megold(tomb, CO2_szűrő).First(), 2));
            Console.ReadKey();
        }
    }
}
