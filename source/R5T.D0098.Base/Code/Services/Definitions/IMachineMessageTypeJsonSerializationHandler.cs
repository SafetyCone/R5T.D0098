using System;

using R5T.D0097;
using R5T.T0064;
using R5T.T0091;


namespace R5T.D0098
{
    /// <summary>
    /// Handles JSON deserialization for a machine message type (serialization to JSON is easy).
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IMachineMessageTypeJsonSerializationHandler : ITypeBasedJsonSerializationHandler<IMachineMessage>
    {
    }
}
