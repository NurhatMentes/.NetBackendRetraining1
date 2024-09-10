using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }

        public List<Category> GetAll()
        {
            return _dal.GetAll();
        }

        Category ICategoryService.GetById(int categoryId)
        {
            return _dal.Get(p => p.CategoryId == categoryId);
        }
    }
}
