using System.Collections.Generic;

namespace DMDB.Models
{
    public class Employee
    {
        
        public int employeeID { get; set; }
        
        public string employeeFName { get; set; }

        public string employeeLName { get; set; }
        
        public string employeeEmail { get; set; }
        
        public string employeePassword { get; set; }

        public string employeeType { get; set; }

        public Location location { get; set; }
    }
}