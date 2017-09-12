using System.Collections.Generic;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Models;

namespace WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Interfaces
{
    public interface ICategoryService
    {
        CategoryModel FetchById(long id);
        CategoryModel FetchByCode(string codeValue);
        List<CategoryModel> FetchAll();
        void Update(CategoryModel model);
        void Add(CategoryModel model);
        void Delete(long id);
    }
}
