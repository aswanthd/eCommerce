//-----------------------------------------------------------------------
// <copyright file = "ContainerConfig.cs" company = "MSC Technology">
//   Mediterranean Shipping Company SA. OneVision Project.
// </copyright>
// <summary> Declare the Class ContainerConfig. </summary>
//-----------------------------------------------------------------------

namespace eCommerceService.Read
{
    using System.Web.Http;
    using eCommerceService.Business.Contracts;
    using eCommerceService.BusinessLayer;
    using eCommerceService.DataAccessLayer;
    using eCommerceService.DataAceess.Contracts;
    using LightInject;

    /// <summary>
    /// Container Config class.
    /// </summary>
    public static class ContainerConfig
    {
        #region Constructors and private fields

        /// <summary>
        /// Read Only ContainerLock.
        /// </summary>
        private static readonly object ContainerLock = new object();

        /// <summary>
        /// Service Container.
        /// </summary>
        private static ServiceContainer servicecontainer;

        #endregion Constructors and private fields

        #region Public and protected properties

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static ServiceContainer Current
        {
            get
            {
                if (servicecontainer == null)
                {
                    lock (ContainerLock)
                    {
                        if (servicecontainer == null)
                        {
                            var container = new ServiceContainer();
                            container.LoadConfiguration();
                            servicecontainer = container;
                        }
                    }
                }

                return servicecontainer;
            }
        }

        #endregion Public and protected properties

        #region Private helpers

        /// <summary>
        /// ContainerConfig Initialize.
        /// </summary>
        public static void Initialize()
        {
            Current.RegisterApiControllers();
            Current.EnableWebApi(GlobalConfiguration.Configuration);
        }

        /// <summary>
        /// Load Configuration.
        /// </summary>
        /// <param name="container">Service Container.</param>
        public static void LoadConfiguration(this ServiceContainer container)
        {
            container.Register<IECommerceReader, ECommerceReader>();
            container.Register<IECommerceDataReader, ECommerceDataReader>();
        }

        #endregion Private helpers
    }
}