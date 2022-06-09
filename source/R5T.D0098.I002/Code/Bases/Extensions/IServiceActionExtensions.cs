using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0098.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SimpleTextJsonSerializationHandler"/> implementation of <see cref="IMachineMessageTypeJsonSerializationHandler"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineMessageTypeJsonSerializationHandler> AddSimpleTextJsonSerializationHandlerAction(this IServiceAction _)
        {
            var serviceAction = _.New<IMachineMessageTypeJsonSerializationHandler>(services => services.AddSimpleTextJsonSerializationHandler());
            return serviceAction;
        }
    }
}
