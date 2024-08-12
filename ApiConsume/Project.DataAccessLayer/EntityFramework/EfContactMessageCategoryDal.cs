using Project.DataAccessLayer.Abstract;
using Project.DataAccessLayer.Concrete;
using Project.DataAccessLayer.Repositories;
using Project.EntityLayer.Concrete;

namespace Project.DataAccessLayer.EntityFramework
{
    public class EfContactMessageCategoryDal : GenericRepository<ContactMessageCategory>, IContactMessageCategoryDal
    {
        public EfContactMessageCategoryDal(Context context) : base(context)
        {
        }
    }
}
