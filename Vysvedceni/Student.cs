using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vysvedceni
{
    public class Student
    {
        public string Jmeno;
        public string SlovniHodnoceni;
        public double Prumer;
        public List<int> ZnamkaCj;
        public List<int> ZnamkaMa;
        public List<int> ZnamkaBi;
        public List<int> ZnamkaZem;
        public List<int> ZnamkaDej;
        public List<int> ZnamkaAnj;
       
        public Student()
        {
            this.ZnamkaAnj = new List<int>();
            this.ZnamkaCj = new List<int>();
            this.ZnamkaMa = new List<int>();
            this.ZnamkaBi = new List<int>();
            this.ZnamkaZem = new List<int>();
            this.ZnamkaDej = new List<int>();
        }
    }
}
