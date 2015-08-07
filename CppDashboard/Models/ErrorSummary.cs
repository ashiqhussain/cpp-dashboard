namespace CppDashboard.Models
{
    public class ErrorSummary
    {
        public string Service { get; set; }
        public int ErrorCount { get; set; }
        public string LastError { get; set; }
    }
}