using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Ekomsys.Web.Helpers
{
    using Ekomsys.Business.Interfaces;
    using Ekomsys.Business.Classes;
    using StructureMap.Configuration.DSL;
    using Ekomsys.Common.Logger;
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController
            GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        {
            try
            {
                if ((requestContext == null) || (controllerType == null))
                    return null;

                return (Controller)ObjectFactory.GetInstance(controllerType);
            }
            catch (StructureMapException)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw new Exception(ObjectFactory.WhatDoIHave());
            }
        }
    }

    public static class StructureMapper
    {
        public static void Run()
        {
            ControllerBuilder.Current
                .SetControllerFactory(new StructureMapControllerFactory());

            ObjectFactory.Initialize(action =>
            {
                //action.AddRegistry(new RepositoryRegistry());
                action.AddRegistry(new BusinessLogicRegistry());
            });
        }
    }

    public class BusinessLogicRegistry : Registry
    {
        public BusinessLogicRegistry()
        {
            //For<IMenuBAL>().Use<MenuBAL>();
            For<INewsBAL>().Use<NewsBAL>();
            For<IUserManagementBAL>().Use<UserManagementBAL>();
        }
    }
}