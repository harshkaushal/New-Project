using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using Ekomsys.Entities;


//using USAGreenCard.Entities.Poco;

namespace Ekomsys.DataAccess.Classes
{

    public class CountryRepository : RepositoryBase<Banner>
    {

        //USAGreenCard.DataAccess.Edmx.usagreencardEntities db = new Edmx.usagreencardEntities();
        //public List<CountryLanguageVariant> GetAllCountries(Int32 LanguageId)
        //{
        //    var listCountry = (from c in db.Countries
        //                       join cl in db.CountryLanguageVariants on c.CountryId equals cl.CountryId
        //                       where cl.LanguageId == LanguageId
        //                       select cl).OrderBy(o => o.CountryLanguageVariant1).ToList();
        //    return listCountry;
        //}
       
    }
   
}