using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataAccessLayer.Abstract;
using Project.DataAccessLayer.Concrete;
using Project.DataAccessLayer.Repositories;
using Project.EntityLayer.Concrete;

namespace Project.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {

        public EfStaffDal(Context context) : base(context)
        {
        }

        public int GetStaffCount()
        {
            var context = new Context();
            return context.Staff.Count();
        }

        public List<Staff> Last4Staff()
        {
            var context = new Context();
            return context.Staff.OrderByDescending(x => x.StaffId).Take(4).ToList();
        }
    }
}
