using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vysvedceni
{
    class Program
    {
        static void Main(string[] args)
        {
            HodnoceniTyp readingCsvTest = new HodnoceniTyp();
            Hodnoceni report = new Hodnoceni(readingCsvTest.MakeMark(@"X:\Programování_Třeťák\Utilities\Vysvedceni\Vysvedceni\students-marks_v03.csv"));
            Console.ReadKey();
        }
    }
}
