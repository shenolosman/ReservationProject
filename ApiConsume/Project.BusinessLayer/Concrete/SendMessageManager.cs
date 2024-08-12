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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessage;

        public SendMessageManager(ISendMessageDal sendMessage)
        {
            _sendMessage = sendMessage;
        }
        public void TDelete(SendMessage t)
        {
            _sendMessage.Delete(t);
        }

        public SendMessage TGetById(int id)
        {
            return _sendMessage.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendMessage.GetList();
        }

        public int TGetSendMessageCount()
        {
           return _sendMessage.GetSendMessageCount();
        }

        public void TInsert(SendMessage t)
        {
            _sendMessage.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            _sendMessage.Update(t);
        }
    }
}
