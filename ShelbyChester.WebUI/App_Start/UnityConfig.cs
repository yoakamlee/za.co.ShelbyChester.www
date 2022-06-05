using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.DataAccess.InMemory;
using ShelbyChester.DataAccess.SQL;
using ShelbyChester.Services;
using System;

using Unity;

namespace ShelbyChester.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepo<ClientPreAdvice>, SQLRepo<ClientPreAdvice>>();
            container.RegisterType<IRepo<ContainerCategory>, SQLRepo<ContainerCategory>>();
            container.RegisterType<IRepo<FreightQuotation>, SQLRepo<FreightQuotation>>();
            container.RegisterType<IRepo<WarehouseStorage>, SQLRepo<WarehouseStorage>>();
            container.RegisterType<IRepo<Basket>, SQLRepo<Basket>>();
            container.RegisterType<IRepo<ContainerRent>, SQLRepo<ContainerRent>>();
            container.RegisterType<IRepo<Customer>, SQLRepo<Customer>>();
            container.RegisterType<IRepo<Employee>, SQLRepo<Employee>>();
            container.RegisterType<IRepo<Driver>, SQLRepo<Driver>>();
            container.RegisterType<IBasketService, BasketService>();
        }
    }
}