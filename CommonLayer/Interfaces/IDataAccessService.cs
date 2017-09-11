using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public interface IDataAccessService
    {

        CategoryModel FetchCategory(long id);
        CategoryModel FetchCategory(string codeValue);
        List<CategoryModel> FetchAllCategory();
        void DeleteCategory(long id);
        void UpdateCategory(CategoryModel model);
        void AddCategory(CategoryModel model);



        //CategoryModel FetchCategory(long id);
        //CategoryModel FetchCategory(string codeValue);
        //IEnumerable<CategoryModel> FetchAllCategory();
        //void DeleteCategory(long id);
        //void UpdateCategory(CategoryModel model);
        //void AddCategory(CategoryModel model);
    }
}
