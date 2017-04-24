using LightInject;
using StandardBank.IdValidation.Core.Services;
using StandardBank.IdValidation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StandardBank.IdValidation.Api
{
    public partial class Startup
    {
        public static void ContainerConfig()
        {
            var container = new ServiceContainer();
            container.Register<IIdentificationService, IdentificationService>(new PerScopeLifetime());
            container.RegisterApiControllers();
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}