using System.Collections.Generic;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Models;

namespace WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeModel FetchById(long id);
        List<EmployeeModel> FetchAll();
        void Update(EmployeeModel model);
        void Add(EmployeeModel model);
        void Delete(long id);
    }
}
