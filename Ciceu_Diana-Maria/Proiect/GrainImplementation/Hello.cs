using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Streams;
using System;
using System.Threading.Tasks;

namespace GrainImplementation
{
    public class Hello : Orleans.Grain, IHello
    {
        private readonly ILogger logger;

        public Hello(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
        }

        async Task<string> IHello.SayHello(string greeting)
        {
            IAsyncStream<string> stream = this.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "chat");
            await stream.OnNextAsync($"{this.GetPrimaryKeyString()} - {greeting}");


            logger.LogInformation($"\n SayHello message received: greeting = '{greeting}'");
            return ($"\n Client said: '{greeting}', so HelloGrain says: E-mail sent!");
        }
    }
}