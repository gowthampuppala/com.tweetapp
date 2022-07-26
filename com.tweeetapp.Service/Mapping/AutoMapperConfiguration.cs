using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.tweeetapp.Service.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Initialize()
        {
            var configuration = new MapperConfiguration(
                config =>
                {
                    config.AddMaps(typeof(EntitiesProfile));
                }      
                );
            return configuration;
        }
    }
}
