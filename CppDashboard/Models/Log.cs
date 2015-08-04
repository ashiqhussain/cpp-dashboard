using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CppDashboard.Models
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public string Data { get; set; }

        public string CslIp { get; set; }
    }
}