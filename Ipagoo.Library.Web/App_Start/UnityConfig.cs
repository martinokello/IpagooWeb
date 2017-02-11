using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Ipagoo.Library.Services.Interfaces;
using Ipagoo.Library.Services.Concretes;
using Ipagoo.Library.Domain.Models;
using System.Reflection;

namespace Ipagoo.Library.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var t in types) {
                if (t.IsAssignableFrom(typeof(System.Web.Mvc.IController)))
                {
                    container.RegisterType(t);
                }
            }
            container.RegisterType<IRepository<Book>,BookRepository>();
            container.RegisterType<IRepository<User>,UserRepository>();
            container.RegisterType<IRepository<Domain.Models.Library>,LibraryRepository>();
            container.RegisterType<IRepository<Loan>, LoanRepository>();
            container.RegisterType<IRepository<LoanComment>,LoanCommentRepository>();
        }
    }
}
