Note from Mark (developer): I'm currently renovating a house so I have put development of Networker on hold until Feb 2019, but I am around to view pull requests or issues.

[![Build status](https://ci.appveyor.com/api/projects/status/k2yi64f298bgjxra?svg=true)](https://ci.appveyor.com/project/MarkioE/networker)
[![NuGet](https://img.shields.io/nuget/v/networker.svg)](https://www.nuget.org/packages/Networker/)

# Networker
A simple to use TCP and UDP networking library for .NET, designed to be flexible, scalable and FAST.

## Supported Frameworks
* .NET Standard 2.0

## Features
* TCP
* UDP
* Socket Pooling
* Object Pooling
* Process thousands of requests per second
* Dependency Injection using [Service Collection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicecollection?view=aspnetcore-2.1)
* Works with [Unity Game Engine](https://unity3d.com)

## Installation
V3 is currently in pre-release. Get the latest build below.
**NuGet Package Manager**
```
Install-Package Networker -IncludePrerelease
```

**You must then install one of the following formatters**

#### ZeroFormatter 
[Networker.Formatter.ZeroFormatter](https://www.nuget.org/packages/Networker.Formatter.ZeroFormatter)
```
Install-Package Networker.Formatter.ZeroFormatter
```
#### Protobuf-net 
[Networker.Formatter.ProtoBufNet](https://www.nuget.org/packages/Networker.Formatter.ProtoBufNet)
```
Install-Package Networker.Formatter.ProtoBufNet
```

## Getting Started
Find more information about how to get started on our [Wiki](https://github.com/MarkioE/Networker/wiki) or view the Examples found inside the repository.

## Example

Creating a server is easy..

````csharp
var server = new ServerBuilder()
                .UseTcp(1000)
                .UseLogger<ConsoleLogger>()
                .SetLogLevel(LogLevel.Info)
                .UseZeroFormatter()
                .Build();
````

You can handle a packet easily using dependency injection, logging and built-in deserialisation.

````csharp
public class PingPacketHandler : PacketHandlerBase<PingPacket>
{
    private readonly ILogger logger;

    public PingPacketHandler(ILogger logger)
    {
        this.logger = logger;
    }

    public override async Task Process(PingPacket packet, ISender sender)
    {
        this.logger.Debug("Received a ping packet from " + sender.EndPoint);
    }
}
````

## Older Versions
Version 3 included a large rewrite and various breaking changes. To use V2 please see [V2 Branch](https://github.com/MarkioE/Networker/tree/features/v2.1)
