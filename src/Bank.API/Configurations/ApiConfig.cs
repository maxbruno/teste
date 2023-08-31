using AutoMapper;
using Bank.API.Extensions.Context;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bank.Application.AutoMapper;
using Bank.API.Filters;

namespace Bank.API.Configurations
{
    public static class ApiConfig
    {
        public static void WebApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => { options.Filters.Add<DomainNotificationFilter>(); });
            services.AddControllers(opt =>
            {
                opt.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            }).AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.RegisterContexts(configuration);
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}