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
    public class MailSubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public MailSubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }
        public void TDelete(MailSubscribe t)
        {
            _subscribeDal.Delete(t);
        }

        public MailSubscribe TGetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public List<MailSubscribe> TGetList()
        {
            return _subscribeDal.GetList();
        }

        public void TInsert(MailSubscribe t)
        {
            _subscribeDal.Insert(t);
        }

        public void TUpdate(MailSubscribe t)
        {
            _subscribeDal.Update(t);
        }
    }
}
