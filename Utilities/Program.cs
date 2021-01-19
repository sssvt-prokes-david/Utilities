using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\DJTom\Downloads\students-marks_v03.csv";
            var school = new SchoolReport();
            school.GradeReport(path);
        }
    }
}
