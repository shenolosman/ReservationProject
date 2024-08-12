using Project.BusinessLayer.Abstract;
using Project.DataAccessLayer.Abstract;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Concrete
{
    public class ContactMessageCategoryManager : IContactMessageCategoryService
    {
        private readonly IContactMessageCategoryDal _contactMessageCategory;

        public ContactMessageCategoryManager(IContactMessageCategoryDal contactMessageCategory)
        {
            _contactMessageCategory = contactMessageCategory;
        }
        public void TDelete(ContactMessageCategory t)
        {
            _contactMessageCategory.Delete(t);
        }

        public ContactMessageCategory TGetById(int id)
        {
            return _contactMessageCategory.GetById(id);
        }

        public List<ContactMessageCategory> TGetList()
        {
            return _contactMessageCategory.GetList();
        }

        public void TInsert(ContactMessageCategory t)
        {
            _contactMessageCategory.Insert(t);
        }

        public void TUpdate(ContactMessageCategory t)
        {
            _contactMessageCategory.Update(t);
        }
    }
}
