using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Intefaces;
using CommonLayer;
using DataAccessLayer;
using DataAccessLayer.Services;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDataAccessService _dataAccessService;

        public CategoryService()
        {
            _dataAccessService = new DataAccessService();
        }

        public CategoryModel FetchById(long id)
        {
            var result = new CategoryModel();
            try
            {
                result = _dataAccessService.FetchCategory(id);

            }
            catch (Exception e)
            {
                //
            }

            return result;
        }

        public CategoryModel FetchByCode(string codeValue)
        {
            var result = new CategoryModel();
            try
            {
                result = _dataAccessService.FetchCategory(codeValue);
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public List<CategoryModel> FetchAll()
        {
            var result = new List<CategoryModel>();
            try
            {
                result = _dataAccessService.FetchAllCategory(); //.OrderBy(x => x.Sequence);
            }
            catch (Exception e)
            {
                //result.Errors.Add(e.BuildExceptionMessage());
            }
            return result;
        }

        public void Update(CategoryModel model)
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
                _dataAccessService.UpdateCategory(model);
                //}
            }
            catch (Exception e)
            {
                // result.Errors.Add(e.BuildExceptionMessage());
            }

        }

        public void Add(CategoryModel model)
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
                _dataAccessService.AddCategory(model);

                //}
            }
            catch (Exception e)
            {
                //result.Errors.Add(e.BuildExceptionMessage());
            }

        }

        public void Delete(long id)
        {
            _dataAccessService.DeleteCategory(id);
        }

        private List<string> CheckForDuplicates(CategoryModel model)
        {
            var errors = new List<string>();
            var duplicateModel = _dataAccessService.FetchAllCategory()
                .FirstOrDefault(x => (x.CategoryName.Equals(model.CategoryName,
                                         StringComparison.CurrentCultureIgnoreCase)) &&
                                     x.CategoryId != model.CategoryId);
            if (duplicateModel != null)
            {
                errors.Add(duplicateModel.CategoryName.Equals(model.CategoryName, StringComparison.OrdinalIgnoreCase)
                    ? "Errors.CategoryNameExists"
                    : "Errors.CategoryCodeExists");

            }
            return errors;
        }

    }
}
