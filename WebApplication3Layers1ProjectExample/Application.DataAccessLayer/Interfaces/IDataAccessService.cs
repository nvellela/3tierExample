﻿using System.Collections.Generic;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Models;

namespace WebApplication3Layers1ProjectExample.Application.DataAccessLayer.Interfaces
{
    public interface IDataAccessService
    {

        CategoryModel FetchCategory(long id);
        CategoryModel FetchCategory(string codeValue);
        List<CategoryModel> FetchAllCategory();
        void DeleteCategory(long id);
        void UpdateCategory(CategoryModel model);
        void AddCategory(CategoryModel model);


        List<EmployeeModel> FetchAllEmployee();
        void DeleteEmployee(long id);
        void UpdateEmployee(EmployeeModel model);
        void AddEmployee(EmployeeModel model);


        //CategoryModel FetchCategory(long id);
        //CategoryModel FetchCategory(string codeValue);
        //IEnumerable<CategoryModel> FetchAllCategory();
        //void DeleteCategory(long id);
        //void UpdateCategory(CategoryModel model);
        //void AddCategory(CategoryModel model);
    }
}
