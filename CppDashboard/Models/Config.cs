using System;

namespace CppDashboard.Models
{
    public class Config
    {
        public int ConfigurationId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}