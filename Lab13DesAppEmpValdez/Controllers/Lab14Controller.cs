using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab13DesAppEmpValdez.Models;
using Lab13DesAppEmpValdez.Models.Request;
using Microsoft.EntityFrameworkCore;



namespace Lab13DesAppEmpValdez.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Lab14Controller : ControllerBase
    {
        private readonly StudentContext _context;
        public Lab14Controller(StudentContext context)
        {
            _context = context;
        }

        //Primer Ejercicio
        [HttpPost(Name = "InsertCourse")]

        public void PostCourse1(CourseRequest1 request)
        {
            _context.Courses.Add(new Course
            {
                Name = request.Name,
                Credit = request.Credit
            });
            _context.SaveChanges();
        }
        //Segundo Ejercicio

        [HttpPut(Name = "DeleteCourse")]

        public void DeleteCourse2(CourseRequest2 request)
        {
            var res = _context.Courses.Find(request.CourseId);

            res.IsActive = false;

            _context.Entry(res).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Tercer Ejercicio
        [HttpPost(Name = "InsertGrade")]

        public void PostGrade3(GradeRequest3 request)
        {
            _context.Grades.Add(new Grade
            {
                Name = request.Name,
                Description = request.Description
            });
            _context.SaveChanges();
        }
        //Cuarto Ejercicio

        [HttpPut(Name = "DeleteGrade")]

        public void DeleteGrade4(GradeRequest4 request)
        {
            var res = _context.Grades.Find(request.GradeId);

            res.IsActive = false;

            _context.Entry(res).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Quinto ejercicio

        [HttpPost(Name = "InsertStudent")]

        public void PostStudent5(StudentRequest5 request)
        {
            _context.Students.Add(new Student
            {
                GradeId = request.GradeId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email
            }) ;
            _context.SaveChanges();
        }
        //Sexto Ejercicio

        [HttpPut(Name = "Update Contact")]

        public void UpdateStudent6(ContactoRequest6 request)
        {
            var student = _context.Students.Find(request.StudentId);

            student.Phone = request.Phone;
            student.Email = request.Email;

            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Septimo ejercicio

        [HttpPut(Name = "UpdateStudent")]

        public void UpdateStudent7(PersonalRequest7 request)
        {
            var student = _context.Students.Find(request.StudentId);

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;

            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Octavo ejercicio

        [HttpPost(Name = "InsertStudentByGrade")]

        public void PostStudent8(StudentRequest8 request)
        {
            var student = request.Students.Select(x => new Student
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                Email = x.Email,
                GradeId = request.GradeId
            }).ToList();

            _context.Students.AddRange(student);
            _context.SaveChanges();
        }

        // NovenoEjercicio

        [HttpPut(Name = "DeleteListCourses")]

        public void DeleteCourse9(CourseRequest9 request)
        {
            var course = request.Courses.Select(x => x.CourseId).ToList();

            var coursesToUpdate = _context.Courses
            .Where(c => course.Contains(c.CourseId))
            .ToList();

            coursesToUpdate.ForEach(c => c.IsActive = false);

            _context.Courses.UpdateRange(coursesToUpdate);
            _context.SaveChanges();
        }

        // Decimo Ejercicio
        [HttpPut(Name = "InsertEnrollmenList")]

        public void InsertEnrollment10(EnrollmentRequest request)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == request.StudentID);

            var courseIDs = request.Courses.Select(c => c.CourseId).ToList();

            var existingCourses = _context.Courses.Where(c => courseIDs.Contains(c.CourseId)).ToList();

            var enrollments = existingCourses.Select(course => new Enrollment
            {
                Student = student,
                Course = course,
                Date = DateTime.Now

            }).ToList();

            _context.Enrollments.AddRange(enrollments);
            _context.SaveChanges();
        }




    }
}
