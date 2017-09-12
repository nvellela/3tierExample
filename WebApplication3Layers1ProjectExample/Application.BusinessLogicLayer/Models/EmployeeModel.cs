using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public bool IsRetired { get; set; }

        public double SalarySuper {
            get { return Salary % 9.5; }
        }
    }
}