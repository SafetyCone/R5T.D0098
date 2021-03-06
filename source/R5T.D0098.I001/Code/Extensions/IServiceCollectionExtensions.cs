using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0096;
using R5T.L0017.D001;
using R5T.T0063;


namespace R5T.D0098.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineMessageJsonReserializer"/> implementation of <see cref="IMachineMessageJsonReserializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMachineMessageJsonReserializer(this IServiceCollection services,
            IServiceAction<ILoggerUnbound> loggerUnboundAction,
            IServiceAction<IHumanOutput> humanOutputAction,
            IEnumerable<IServiceAction<IMachineMessageTypeJsonSerializationHandler>> machineMessageTypeJsonSerializationHandlerActions)
        {
            services
                .Run(loggerUnboundAction)
                .Run(humanOutputAction)
                .Run(machineMessageTypeJsonSerializationHandlerActions)
                .AddSingleton<IMachineMessageJsonReserializer, MachineMessageJsonReserializer>();

            return services;
        }
    }
}