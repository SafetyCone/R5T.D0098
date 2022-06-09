using System;
using System.Collections.Generic;

using R5T.D0096;
using R5T.L0017.D001;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0098.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineMessageJsonReserializer"/> implementation of <see cref="IMachineMessageJsonReserializer"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineMessageJsonReserializer> AddMachineMessageJsonReserializerAction(this IServiceAction _,
            IServiceAction<ILoggerUnbound> loggerUnboundAction,
            IServiceAction<IHumanOutput> humanOutputAction,
            IEnumerable<IServiceAction<IMachineMessageTypeJsonSerializationHandler>> machineMessageTypeJsonSerializationHandlerActions)
        {
            var serviceAction = _.New<IMachineMessageJsonReserializer>(services => services.AddMachineMessageJsonReserializer(
                loggerUnboundAction,
                humanOutputAction,
                machineMessageTypeJsonSerializationHandlerActions));

            return serviceAction;
        }
    }
}
