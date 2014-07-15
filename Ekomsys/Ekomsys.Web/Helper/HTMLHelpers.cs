using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Ekomsys.Business.Classes;
using Ekomsys.Business.Interfaces;
using Ekomsys.Common;
using Ekomsys.Common.Enums;
using Ekomsys.Entities;
using Ekomsys.Web.Models;
//using Ekomsys.Helper;
//using Ekomsys.Models;
//using USAGreenCard.Poco;
//using USAGreenCard.Web.Helpers;


namespace Ekomsys.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static string DropDownList(this HtmlHelper helper, String name, String defaultOptionText, Dictionary<string, object> htmlAttributes, Ekomsys.Common.Enums.Enumurations.DropdownType dropdownType, string selectedValue = "-1", string code = "", String optionName = "")
        {
            StringBuilder drpSecurityQuestion = new StringBuilder();
            var builder = new TagBuilder("select");
            //Setting the additional attributes of dropdown like Id, Class, etc.
            if (htmlAttributes != null)
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            //Name of dropdown.
            builder.MergeAttribute("id", name);
            if (!string.IsNullOrEmpty(optionName))
                builder.MergeAttribute("name", optionName);
            else
                builder.MergeAttribute("name", name);
            StringBuilder selectOptions = new StringBuilder();
            //Default item of Dropdown. The value and text for the default item is set from parameters

            if (!string.IsNullOrEmpty(defaultOptionText))
                selectOptions.AppendFormat("<option value='{0}' {1}>{2}</option>", "", "selected", defaultOptionText);

            switch (dropdownType)
            {

                case Ekomsys.Common.Enums.Enumurations.DropdownType.UserType:

                    //Business.Classes.CountryBAL obj = new CountryBAL();
                    UserTypeBAL obj = new UserTypeBAL();
                    //IList<CountryLanguageVariant> countryList = obj.GetAllCountries(SessionVariables.LanguageId.Value);
                    IList<tb_UserType> userTypeDBList = obj.GetAllUserType();

                    AutoMapper.Mapper.CreateMap<tb_UserType, UserTypeModel>();
                    IList<UserTypeModel> userTypeList=new List<UserTypeModel>();
                    userTypeList = AutoMapper.Mapper.Map(userTypeDBList, userTypeList);

                    foreach (var option in userTypeList)
                    {
                        selectOptions.AppendFormat("<option");
                        if (selectedValue == option.UserType_Id.ToString())
                            selectOptions.AppendFormat(" selected='selected' ");
                       
                        else
                            selectOptions.AppendFormat(" NonEligible='false' ");
                        selectOptions.AppendFormat(" value='" + option.UserType_Id + "'>");
                        selectOptions.AppendFormat(option.Name);
                        selectOptions.AppendFormat("</option>");
                    }
                    break;
                
            }
            //Setting the entire <option> to <select>
            builder.InnerHtml = selectOptions.ToString();
            return builder.ToString(TagRenderMode.Normal);
        }

        public static string CurrentTabClass(string selectedClass,
            string psvActionName,
            string controllerName)
        {
            string currentAction = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");
            string currentController = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller");
            string[] actionNames = psvActionName.ToLower().Split('|');
            if (actionNames.Contains(currentAction.ToLower()) && string.Compare(controllerName, currentController, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return "active";
            }
            return string.Empty;
            //return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

    }

}