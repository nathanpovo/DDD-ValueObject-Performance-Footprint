# DDD-ValueObject-Performance-Footprint

In Domain Driven Design (DDD), a Value Object is characterized by:
- No intrinsic identity
- Immutability
- Lifetime that depends on a parent Entity class

There exists several implementations of base class for representing DDD Value Object:
- Jimmy Boggard: http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html
- Vladimir Khorikov: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
- Vladimir Khorikov (better implemenation): https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
- ...

The purpose of this project is to compare these different implementations of DDD Value Object, from performance point of view.
The comparison has been made using the library BenchmarkDotNet. Advantages of using this library includes (among other):
- Automatic warmup (before running iterations)
- No need to care about choosing a number of iterations (e.g. 100? 1000? 2000000?)
- No need to wonder about the resolution of the measurment (contrary to familiar DateTime.Now or StopWatch)
