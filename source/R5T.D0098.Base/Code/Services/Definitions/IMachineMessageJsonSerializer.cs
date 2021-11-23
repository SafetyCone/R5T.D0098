using System;

using R5T.D0097;
using R5T.T0064;
using R5T.T0091;


namespace R5T.D0098
{
    [ServiceDefinitionMarker]
    public interface IMachineMessageJsonSerializer : ITypeBasedJsonSerializer<IMachineMessage>
    {
    }
}
