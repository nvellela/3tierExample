using System.Collections.Generic;
using CommonLayer;

namespace BusinessLogicLayer.Intefaces
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
