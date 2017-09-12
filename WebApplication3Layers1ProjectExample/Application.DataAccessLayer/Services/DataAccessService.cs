using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Models;
using WebApplication3Layers1ProjectExample.Application.DataAccessLayer.DataContextModels;
using WebApplication3Layers1ProjectExample.Application.DataAccessLayer.Interfaces;

namespace WebApplication3Layers1ProjectExample.Application.DataAccessLayer.Services
{
    public class DataAccessService : IDataAccessService
    {
        private readonly testDBEntities context; 

        public DataAccessService()
        {
            this.context = new testDBEntities();
        }

        public CategoryModel FetchCategory(long id)
        {
            var efModel = context.Categories.Find(id);
            var returnObject = new CategoryModel()
            {
                CategoryDescription = efModel.CategoryDescription,
                CategoryName = efModel.CategoryName,
                CategoryId = efModel.CategoryId
            };

            return returnObject;
        }

        public CategoryModel FetchCategory(string codeValue)
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> FetchAllCategory()
        {
            var efModel = context.Categories.ToList();
            var returnObject = new List<CategoryModel>();

            foreach (var item in efModel)
            {
                returnObject.Add(new CategoryModel()
                        {
                            CategoryDescription = item.CategoryDescription,
                            CategoryName = item.CategoryName,
                            CategoryId = item.CategoryId
                        });
            }

            return returnObject;
        }

        public void DeleteCategory(long id)
        {
            var efModel = context.Categories.Find(id);
            context.Categories.Remove(efModel);
            context.SaveChanges();
        }

        public void UpdateCategory(CategoryModel model)
        {
            var efModel = context.Categories.Find(model.CategoryId);
            efModel.CategoryDescription = model.CategoryDescription;
            efModel.CategoryName = model.CategoryName;
            context.SaveChanges();
        }

        public void AddCategory(CategoryModel model)
        {
            var efModel = new Category()
            {
                CategoryDescription = model.CategoryDescription,
                CategoryName = model.CategoryName,
                CategoryId = model.CategoryId
            };
            context.Categories.Add(efModel);
            context.SaveChanges();
        }

        public List<EmployeeModel> FetchAllEmployee()
        {
            var efModel = context.Employees.ToList();
            var returnObject = new List<EmployeeModel>();

            foreach (var item in efModel)
            {
                returnObject.Add(new EmployeeModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Salary = item.Salary,
                    IsRetired = item.IsRetired
                });
            }

            return returnObject;
        }

        public void DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(EmployeeModel model)
        {
            throw new NotImplementedException();
        }
    }

  
}
