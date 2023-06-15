using System.Text.RegularExpressions;
using Zadanie3.Models;

namespace Zadanie3.CSVOrganizer
{
    public class CSVReader
    {
        public const string dataPath = "data/data.csv";
        
        //Method that returns list of all students found in CSV file
        public List<Student> FindAllStudents()
        {
            var students = new List<Student>();
            using (var reader = new StreamReader(dataPath))
            {
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    bool emptyString = false;
                    if (values.Length == 9)
                    {
                        var sNumberIsValid = Regex.IsMatch(values[4], @"^\d+$");
                        foreach (var value in values)
                        {
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                emptyString = true;
                            }
                        }
                        if (!emptyString && sNumberIsValid)
                        {
                            Student student = new Student
                            {
                                Index = "s" + values[4],
                                Name = values[0],
                                Surname = values[1],
                                Email = values[6],
                                BirthDate = values[5],
                                MothersName = values[7],
                                FathersName = values[8],
                                Studies = new StudiesRecord
                                {
                                    Name = values[2],
                                    Mode = values[3]
                                }
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }

        //Method that finds and returns student with specified sNumber
        public Student FindStudentWithSNumber(string sNumber)
        {
            Student? student = FindAllStudents().Find(it => it.Index == sNumber);
            return student;
        }

        //Method that returns every line from csv file in the form of list of strings
        public List<string> ReadAllLines()
        {
            List<string> lines = new List<string>();
            using (var reader = new StreamReader(dataPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}

