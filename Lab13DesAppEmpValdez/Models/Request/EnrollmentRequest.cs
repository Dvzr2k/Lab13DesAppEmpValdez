namespace Lab13DesAppEmpValdez.Models.Request
{
    public class EnrollmentRequest
    {
        public int StudentID { get; set; }
        public List<Course> Courses { get; set; }
    }
}
