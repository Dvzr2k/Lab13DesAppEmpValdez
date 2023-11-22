namespace Lab13DesAppEmpValdez.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course  Course { get; set; }
        public DateTime Date { get; set;}
    }
}
