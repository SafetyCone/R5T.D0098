using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;


namespace R5T.D0098.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SimpleTextJsonSerializationHandler"/> implementation of <see cref="IMachineMessageTypeJsonSerializationHandler"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSimpleTextJsonSerializationHandler(this IServiceCollection services)
        {
            services.AddSingleton<IMachineMessageTypeJsonSerializationHandler, SimpleTextJsonSerializationHandler>();

            return services;
        }
    }
}