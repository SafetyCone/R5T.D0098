using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;

using R5T.Magyar;

using R5T.D0096;
using R5T.D0097.I001;
using R5T.T0064;
using R5T.T0091;


namespace R5T.D0098.I001
{
    [ServiceImplementationMarker]
    public class MachineMessageJsonReserializer : IMachineMessageJsonReserializer, IServiceImplementation
    {
        private ILogger Logger { get; }

        private IHumanOutput HumanOutput { get; }

        private TypeBasedJsonReserializer<IMachineMessage> JsonReserializer { get; }


        public MachineMessageJsonReserializer(
            ILogger<MachineMessageJsonReserializer> logger,
            IHumanOutput humanOutput,
            IEnumerable<IMachineMessageTypeJsonSerializationHandler> machineMessageTypeJsonSerializationHandlers)
        {
            this.Logger = logger;

            this.HumanOutput = humanOutput;

            this.JsonReserializer = new TypeBasedJsonReserializer<IMachineMessage>(
                machineMessageTypeJsonSerializationHandlers);
        }

        public WasSuccessful<IMachineMessage> Deserialize(JObject json)
        {
            var machineMessageDeserialization = this.JsonReserializer.Deserialize(json);

            // If unsuccesful, tell someone.
            if (!machineMessageDeserialization.Success)
            {
                // TODO: expand on error reporting to note the reason for failure.
                var errorMessage = $"Unable to deserialize JSON object to {typeof(IMachineMessage)}.";

                // Tell a human.
                this.HumanOutput.Write(errorMessage);

                // Log as an error.
                this.Logger.LogError(errorMessage);
            }

            // In any case, return the result.
            return machineMessageDeserialization;
        }

        public WasSuccessful<JObject> Serialize(IMachineMessage message)
        {
            var jsonSerialization = this.JsonReserializer.Serialize(message);

            // If unsuccessful, let someone know.
            if (!jsonSerialization.Success)
            {
                // TODO: expand on error reporting to note the reason for failure.
                var errorMessage = $"Unable to serialize {typeof(IMachineMessage)} to JSON object.";

                // Tell a human.
                this.HumanOutput.Write(errorMessage);

                // Log as an error.
                this.Logger.LogError(errorMessage);

                return WasSuccessful.Unsuccessful<JObject>();
            }

            return jsonSerialization;
        }
    }
}