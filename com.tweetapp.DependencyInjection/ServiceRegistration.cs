using AutoMapper;
using com.tweeetapp.Service.Mapping;
using com.tweeetapp.Service.Services;
using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Dal.Infrastructure.Interfaces;
using com.tweetapp.Dal.Interface;
using com.tweetapp.Dal.Repositories;
using com.tweetapp.Dal.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.tweetapp.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static void AutoMapper(this IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfiguration.Initialize();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
        }

        public static void AddUserRegistrationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRegistrationService,UserregistrationService>();
            services.AddTransient<IUserRegistrationRepository, UserRegistrationRepository>();
        }

        public static void AddUserLoginServices(this IServiceCollection services)
        {
            services.AddTransient<IUserLoginService, UserLoginService>();
            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
        }
        
        public static void AddUserMenuServices(this IServiceCollection services)
        {
            services.AddTransient<ILoggedInUserService, LoggedInUserService>();
            services.AddTransient<ILoggedInUserRepository,LoggedInUserRepository>();
        }
    }
}
