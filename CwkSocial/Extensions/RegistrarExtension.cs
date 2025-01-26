using CwkSocial.Api.Registrars;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CwkSocial.Api.Extensions
{
    public static class RegistrarExtension
    {
        public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType) 
        {
            var registrars = scanningType.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IWebApplicationBuilderRegistrar)) && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IWebApplicationBuilderRegistrar>()
                ;
            foreach (var registrar in registrars)
            {
                registrar.RegisterServices(builder);
            }

        }

        public static void RegisterPipelineComponents(this WebApplication app, Type scanningType) 
        {
            var registrars = scanningType.Assembly.GetTypes()
               .Where(t => t.IsAssignableTo(typeof(IWebApplicationRegister)) && !t.IsInterface && !t.IsAbstract)
               .Select(Activator.CreateInstance)
               .Cast<IWebApplicationRegister>()
               ;
            foreach (var registrar in registrars)
            {
                registrar.RegisterPipeLineComponents(app);
            }
        }
    }
}
