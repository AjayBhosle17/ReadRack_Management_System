using BAL;
using DAL;
using Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BOOK_API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ReadRackDbContext>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IBookRepository, BookRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}