using Chirper.Domain.Actors;
using Orleans;
using Orleans.Hosting;
using System;

namespace Chirper.Domain.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var siloBuilder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ChirpUser).Assembly).WithReferences());
            var host = siloBuilder.Build();
            var t = host.StartAsync();
            Console.WriteLine("Hello World!");
            t.Wait();
            Console.ReadLine();
            host.StopAsync();
        }
    }
}
