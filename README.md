# SampleArchitecture

## Table of Contents

A sample architecture using a domain centric approach for onion/hexagonal architecture.

* [Introduction to Sample Architecture](#introdution-to-sample-architecture)
* [Core](#core)
* [Services](#services)
* [Command Pattern](#command-pattern)
* [Decorator Pattern](#decorator-pattern)
* [Footnotes](#footnotes)

## Introdution to Sample Architecture

The code in this repository is an example of an onion/hexagonal architecture[^1].

* Core
* Services
* Ports

The ports are the entry points that connect our application to the outside world. In this example, we use a web api to define a user interface that allows clients to connect to our application. The core is the layer that the defines our domain. Here we define our domain models as well as the interfaces for our domain logic. The services implement the domain logic.

The direction of dependencies are towards the center (inversion of control). Any of the layers only knows about the core. By removing any leaky abstractions through indirection, external dependencies are removed from the domain logic.

## Core

In the center is our domain model. This contains all of our entities, value objects, guards, domain events, interfaces, etc... The namespaces are broken down by separation of concern as well as organization for the domain services.

## Services

The domain services implement our domain logic as well as abstract away our external dependencies from our domain logic. Various domain services can interact with each other through inversion of control since they only have a dependency on the core. In our example, the repository layer is implemented in to different manners(CosmosDB or SQL) to illustrate how the services abstract away the underlying external dependencies from our domain model. This allows a service to more easily be swapped out with another without affecting our domain model.

## Command Pattern

The command pattern is utilized for Command Query Responsibility Segregation [^2]. This approach allows action to be isolated from each other as well as also allowing more of a veritial slice architecture[^3]. Commands can interact with whatever domain logic is sees fit without impacting other commands and not having to also follow rigid patterns of typical top down architecture approaches.  

In our example, we can define a command handler.

```csharp
public interface ICommandHandler<in TCommand, TResult>
        where TCommand : class
    {
        ValueTask<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
```

Commands are then invoked by having only a dependency on the command processor and firing off the appropriate command.

```csharp
public interface ICommandProcessor
    {
        ValueTask<TResult> HandleAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken)
            where TCommand : class;
    }
```

## Decorator Pattern

The architecture sample also uses the decorator pattern[^4] to alter or extend the behavior of a command handler without having to modify or pollute an exisiting command handler.

```csharp
public static IServiceCollection Decorate<TInterface, TDecorator>(this IServiceCollection services)
```

## Footnotes

[^1]: [DDD, Hexagonal, Onion, Clean, CQRS, … How I put it all together](https://medium.com/the-software-architecture-chronicles/ddd-hexagonal-onion-clean-cqrs-how-i-put-it-all-together-f2590c0aa7f6)
[^2]. [CQRS](https://martinfowler.com/bliki/CQRS.html)
[^3]: [Verical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/)
[^4]. [Decorator](https://en.wikipedia.org/wiki/Decorator_pattern)
