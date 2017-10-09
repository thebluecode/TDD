using Microsoft.Practices.Unity;
using System.Web.Http;
using UnitTestSample;
using Unity.WebApi;

namespace WebApp.Unity
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IEnrollmentBo, EnrollmentBo>();
            container.RegisterType<IEnrollmentDao, EnrollmentDao>();
            container.RegisterType<IUtilityBo, UtilityBo>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}