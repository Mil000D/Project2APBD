using Microsoft.AspNetCore.Mvc;
using Zadanie3.Models;
using Zadanie3.CSVOrganizer;

namespace Zadanie3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Method that returns every student found in CSV file as a response
        //or if no student was found it responds with particular message
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var csv = new CSVReader();
            var listOfStudents = csv.FindAllStudents();
            if (listOfStudents.Count == 0)
            {
                return NotFound("Couldn't find students in CSV file");
            }
            else
            {
                return Ok(csv.FindAllStudents());
            }
        }
        
        //Method that returns student with specified sNumber as a response
        //or if no student was found it reponds with particular message
        [HttpGet("{sNumber}")]
        public IActionResult GetStudentWithSNumber(string sNumber)
        {
            var csv = new CSVReader();
            Student student = csv.FindStudentWithSNumber(sNumber);
            if (student == null)
            {
                return NotFound($"Couldn't find student with specified sNumber: {sNumber}");
            }
            else
            {
                return Ok(student);
            }
        }

        //Method that updates student with specified sNumber
        //and responds with actual data associated with the enrolled student
        //or if student update wasn't possible it responds with particular message
        [HttpPut("{sNumber}")]
        public IActionResult UpdateStudent(string sNumber, Student student)
        {
            var csv = new CSVWriter();
            bool updateSucceded = csv.UpdateStudentData(sNumber, student);
            student.Index = sNumber;
            if(!updateSucceded)
            {
                return BadRequest($"Couldn't update student with specified sNumber: {sNumber}");
            }
            else
            {
                return Ok(student);
            }
            
        }

        //Method that adds new student and responds with specific messages
        //in case of success and in case of failure
        [HttpPost]
        public IActionResult AddNewStudent(Student student)
        {
            var csv = new CSVWriter();
            bool addingSucceded = csv.AddNewStudentData(student);
            if (!addingSucceded)
            {
                return BadRequest("Couldn't insert new student");
            }
            else
            {
                return Ok("Inserting new student succeded");
            }
        }

        //Method that deletes student with specified sNumber and responds with specific messages
        //in case of success and in case of failure
        [HttpDelete("{sNumber}")]
        public IActionResult DeleteStudent(string sNumber)
        {
            var csv = new CSVWriter();
            bool deletionSucceded = csv.DeleteStudentData(sNumber);
            if(!deletionSucceded)
            {
                return BadRequest($"Couldn't delete student with specified sNumber: {sNumber}");
            }
            else
            {
                return Ok($"Deleting student with sNumber: {sNumber} succeded");
            }
        }
    }
}
