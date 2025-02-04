
using CwkSocial.Application.UserProfiles.Querries;
using MediatR;
using AutoMapper;



namespace CwkSocial.Api.Registrars
{
    public class BogardRegister : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(new[] { typeof(Program), typeof(GetAllUserProfileQuery) });
            builder.Services.AddMediatR(typeof(GetAllUserProfileQuery));
        }
    }
}
