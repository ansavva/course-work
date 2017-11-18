using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GoogleSearchSeo
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyInThisApplication()
                .InNamespace("GoogleSearchSeo.Core.Logic.Concrete")
                .WithServiceAllInterfaces());

            container.Register(
                Classes.FromAssemblyInThisApplication()
                .InNamespace("GoogleSearchSeo.Data.Concrete")
                .WithServiceAllInterfaces());

            container.Register(
                Classes.FromAssemblyInThisApplication()
                .InNamespace("GoogleSearchSeo.Logic.Concrete")
                .WithServiceAllInterfaces());

            container.Register(
                Classes.FromThisAssembly()
                .InNamespace("GoogleSearchSeo.Logic.Concrete")
                .WithServiceAllInterfaces());

            container.Register(AllTypes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Controller"))
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestylePerWebRequest());
        }
    }
}