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
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutDal _aboutDal;

        public AboutUsManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void TDelete(AboutUs t)
        {
            _aboutDal.Delete(t);
        }

        public AboutUs TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<AboutUs> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TInsert(AboutUs t)
        {
            _aboutDal.Insert(t);
        }

        public void TUpdate(AboutUs t)
        {
            _aboutDal.Update(t);
        }
    }
}
