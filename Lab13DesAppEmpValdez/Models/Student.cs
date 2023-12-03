namespace Lab13DesAppEmpValdez.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public virtual Grade Grade { get; set; }
        public int GradeId { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Phone { get; set; }
        public string Email { get; set;}
       
    }
}
