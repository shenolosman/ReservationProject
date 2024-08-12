using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EntityLayer.Concrete
{
    public class ContactMessageCategory
    {
        public int ContactMessageCategoryId { get; set; }
        public string SubjectField { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
