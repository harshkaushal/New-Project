using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Business.Interfaces;
using Ekomsys.DataAccess.Classes;
using Ekomsys.Entities;

namespace Ekomsys.Business.Classes
{
    public class ContactBAL:IContactBAL
    {
        ContactRepository _repository=null;
        public usp_getOfficeDetails_Result GetContactDetail()
        {
            _repository = new ContactRepository();
            return _repository.GetOfficeDetails();
        }
    }
}
