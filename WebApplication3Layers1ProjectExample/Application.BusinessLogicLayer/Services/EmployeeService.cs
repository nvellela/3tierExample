using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Interfaces;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Models;
using WebApplication3Layers1ProjectExample.Application.DataAccessLayer.Interfaces;
using WebApplication3Layers1ProjectExample.Application.DataAccessLayer.Services;

namespace WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataAccessService _dataAccessService;

        public EmployeeService()
        {
            _dataAccessService = new DataAccessService();
        }

        public EmployeeModel FetchById(long id)
        {
            var result = new EmployeeModel();
            //try
            //{
            //    result = _dataAccessService.f.FetchEmployee(id);

            //}
            //catch (Exception e)
            //{
            //    //
            //}

            return result;
        }

      
        public List<EmployeeModel> FetchAll()
        {
            var result = new List<EmployeeModel>();
            try
            {
                result = _dataAccessService.FetchAllEmployee(); //.OrderBy(x => x.Sequence);
                result = result.Where(x => x.IsRetired == false).ToList();
            }
            catch (Exception e)
            {
                //result.Errors.Add(e.BuildExceptionMessage());
            }
            return result;
        }

        public void Update(EmployeeModel model)
        {
            try
            {
                //var checkResults = CheckForDuplicates(model);
                //if (checkResults.Any())
                //{
                //    result.Errors = checkResults;
                //}
                //else
                //{
                _dataAccessService.UpdateEmployee(model);
                //}
            }
            catch (Exception e)
            {
                // result.Errors.Add(e.BuildExceptionMessage());
            }

        }

        public void Add(EmployeeModel model)
        {

            try
            {
                //var checkResults = CheckForDuplicates(model);
                //if (checkResults.Any())
                //{
                //    result.Errors = checkResults;
                //}
                //else
                //{
                _dataAccessService.AddEmployee(model);

                //}
            }
            catch (Exception e)
            {
                //result.Errors.Add(e.BuildExceptionMessage());
            }

        }

        public void Delete(long id)
        {
            _dataAccessService.DeleteEmployee(id);
        }

        private List<string> CheckForDuplicates(EmployeeModel model)
        {
            var errors = new List<string>();
            var duplicateModel = _dataAccessService.FetchAllEmployee()
                .FirstOrDefault(x => (x.Name.Equals(model.Name,
                                         StringComparison.CurrentCultureIgnoreCase)) &&
                                     x.Id != model.Id);
            if (duplicateModel != null)
            {
                errors.Add(duplicateModel.Name.Equals(model.Name, StringComparison.OrdinalIgnoreCase)
                    ? "Errors.EmployeeNameExists"
                    : "Errors.EmployeeCodeExists");

            }
            return errors;
        }

    }
}
