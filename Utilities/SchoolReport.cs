using System;
using System.IO;
using System.Collections.Generic;

namespace Utilities
{
    class SchoolReport
    {
        public int[] ToIntArray(string[] stringArray)
        {
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = Convert.ToInt32(stringArray[i]);
            }
            return intArray;
        }

        public string[] Unduplicator(List<string> column)
        {
            string[] dupeTemp = new string[128];
            foreach (var name in column)
            {
                var temp = 0;
                while (temp < dupeTemp.Length)
                {
                    if (name == dupeTemp[temp])
                    {
                        break;
                    }
                    else if (dupeTemp[temp] == null)
                    {
                        dupeTemp[temp] = name;
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                }
            }
            var count = 0;
            for (int i = 0; i < dupeTemp.Length; i++)
            {
                count++;
                if (dupeTemp[i] == null)
                {
                    count -= 1;
                    break;
                }
            }
            string[] somethingFinal = new string[count];
            for (int i = 0; i < count; i++)
            {
                somethingFinal[i] = dupeTemp[i];
            }
            count = 0;
            return somethingFinal;
        }

        public string verbalGrading(double grade)
        {
            var verbalGrade = "";

            if (grade == 1)
            {
                verbalGrade = "výborný";
            }
            if (grade == 2)
            {
                verbalGrade = "chvalitebný";
            }
            if (grade == 3)
            {
                verbalGrade = "dobrý";
            }
            if (grade == 4)
            {
                verbalGrade = "dostatečný";
            }
            if (grade == 5)
            {
                verbalGrade = "nedostatečný";
            }
            return verbalGrade;
        }

        public void TotalGrading(string[] columnArray1, string[] names, string[] columnArray2, string[] schoolSubjects, int[] columnArray3)
        {
            SchoolReport tempReport = new SchoolReport();
            var grade = 0.0;
            var nameTemp = 0;
            var subjectTemp = 0;
            var temporary = 0;
            var divisor = 0;
            var gradeAvg = 0.0;
            var evaluation = "";
            while (nameTemp < names.Length)
            {
                if (columnArray1[temporary] == names[nameTemp] && columnArray2[temporary] == schoolSubjects[subjectTemp])
                {
                    divisor++;
                    grade += columnArray3[temporary];
                }


                if (temporary == columnArray3.Length - 1)
                {
                    grade = Math.Round((grade / divisor));
                    if (grade == 5)
                    {
                        evaluation = "Neprospěl";
                    }
                    if (grade == 3 && evaluation != "Neprospěl")
                    {
                        evaluation = "Prospěl";
                    }

                    var verbalGrade = tempReport.verbalGrading(grade);

                    Console.WriteLine($"{names[nameTemp]} - {schoolSubjects[subjectTemp]}: {verbalGrade}");
                    gradeAvg += grade;
                    temporary = 0;
                    grade = 0;
                    divisor = 0;
                    subjectTemp++;

                }

                if (subjectTemp == schoolSubjects.Length)
                {
                    gradeAvg = Math.Round(gradeAvg / 6, 2);
                    if (gradeAvg <= 1.5 && evaluation != "Neprospěl" && evaluation != "Prospěl")
                    {
                        evaluation = "Prospěl s vyznamenáním";
                    }
                    Console.WriteLine($"{names[nameTemp]} - Celkový průměr: {gradeAvg} ({evaluation})");
                    Console.WriteLine();
                    nameTemp++;
                    gradeAvg = 0;
                    subjectTemp = 0;
                    evaluation = null;
                }
                temporary++;
            }
        }

        public List<string> ColumnSplitter (int n, string path) 
        {
            List<string> column = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var splits = reader.ReadLine().Split(',');
                    column.Add(splits[n]);
                }
            }
            return column;
        }

        public void GradeReport(string path)
        {
            SchoolReport school = new SchoolReport();

            // Rozdělení sloupců
            var column1 = school.ColumnSplitter(0, path);
            var column2 = school.ColumnSplitter(1, path);
            var column4 = school.ColumnSplitter(3, path);

            // Smazání duplicitních jmen a předmětů, přidělení správné velikosti arrayům
            string[] names = school.Unduplicator(column1);
            string[] schoolSubjects = school.Unduplicator(column2);
            
            // Konverze listů na arraye
            string[] columnArray1 = column1.ToArray();
            string[] columnArray2 = column2.ToArray();
            int[] columnArray3 = school.ToIntArray(column4.ToArray());
            
            // Finální oznámkování a výpis známek
            school.TotalGrading(columnArray1, names, columnArray2, schoolSubjects, columnArray3);
            
            Console.ReadKey();
        }
    }
}
