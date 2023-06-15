using System.Text.RegularExpressions;
using Zadanie3.Models;

namespace Zadanie3.CSVOrganizer
{
    public class CSVWriter
    {
        public const string dataPath = "data/data.csv";
        public const int recordNotFound = -1;

        //Method that validates sNumber passed as parameter
        public bool CheckValidationOfSNumber(string sNumber)
        {
            return Regex.IsMatch(sNumber, @"^s\d+$");
        }

        //Method which returns index of row in listOfData that corresponds to row in CSV file
        //if -1 is returned then there is no row that contains specified sNumber
        public int IndexFinder(List<string> listOfData, string sNumber)
        {
            var indexOfRowInCSV = recordNotFound;
            for (int i = 0; i < listOfData.Count; i++)
            {
                var rows = listOfData[i].Split(',');
                if (rows.Length == 9)
                {
                    if (rows[4].Equals(sNumber.Remove(0, 1)))
                    {
                        indexOfRowInCSV = i;
                        break;
                    }
                }
            }
            return indexOfRowInCSV;
        }
        //Method that writes to CSV file rows specified inside listOfData passed as argument
        public void WriteToCsv(List<string> listOfData)
        {
            using (StreamWriter writer = new StreamWriter(dataPath, false))
            {
                foreach (string line in listOfData)
                {
                    writer.WriteLine(line);
                }
            }
        }
        //Method that updates data of student with specified sNumber and content provided
        //in the form of Student object
        public bool UpdateStudentData(string sNumber, Student student)
        {
            var csv = new CSVReader();
            var listOfData = csv.ReadAllLines();
            var indexOfRowInCSV = IndexFinder(listOfData, sNumber);
            var sNumberIsValid = CheckValidationOfSNumber(sNumber);
            if (indexOfRowInCSV == recordNotFound || !sNumberIsValid)
            {
                return false;
            }
            else
            {
                var values = listOfData[indexOfRowInCSV].Split(',');
                values[0] = student.Name;
                values[1] = student.Surname;
                values[2] = student.Studies.Name;
                values[3] = student.Studies.Mode;
                values[5] = student.BirthDate;
                values[6] = student.Email;
                values[7] = student.MothersName;
                values[8] = student.FathersName;
                listOfData[indexOfRowInCSV] = String.Join(",", values);
                WriteToCsv(listOfData);
                return true;
            }
        }
        //Method that adds new student data to CSV file
        public bool AddNewStudentData(Student student)
        {
            var csv = new CSVReader();
            var indexOfDuplicate = csv.FindAllStudents().FindIndex(it => it.Index.Equals(student.Index));
            var sNumberIsValid = CheckValidationOfSNumber(student.Index);
            if (indexOfDuplicate != recordNotFound || !sNumberIsValid)
            {
                return false;
            }
            else
            {
                var data = String.Join(",", student.Name, student.Surname, student.Studies.Name,
                                                    student.Studies.Mode, student.Index.Remove(0, 1),
                                                    student.BirthDate, student.Email,
                                                    student.MothersName, student.FathersName);

                File.AppendAllText(dataPath, "\n" + data);
                return true;
            }
        }
        
        //Method that deletes student data with specified as argument sNumber from CSV file 
        public bool DeleteStudentData(string sNumber)
        {
            var csv = new CSVReader();
            var listOfData = csv.ReadAllLines();
            var indexOfRowInCSV = IndexFinder(listOfData, sNumber);
            var sNumberIsValid = CheckValidationOfSNumber(sNumber);
            if (indexOfRowInCSV == recordNotFound || !sNumberIsValid)
            {
                return false;
            }
            else
            {
                listOfData.RemoveAt(indexOfRowInCSV);
                WriteToCsv(listOfData);
                return true;
            }
        }
    }
}
