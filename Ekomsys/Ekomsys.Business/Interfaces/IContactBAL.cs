using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;

namespace Ekomsys.Business.Interfaces
{
    public interface IContactBAL
    {
        usp_getOfficeDetails_Result GetContactDetail();
    }
}
