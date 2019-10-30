### Read More - [https://medium.com/@EmperorRXF/evaluating-performance-of-rest-vs-grpc](https://medium.com/@EmperorRXF/evaluating-performance-of-rest-vs-grpc-1b8bdf0b22da?source=https://github.com/EmperorRXF/RESTvsGRPC)

# RESTvsGRPC
Evaluating Performance of REST vs. gRPC

## dotnet run -p RestAPI -c Release
Starts the ASP.NET MVC Core REST API

## dotnet run -p GrpcAPI -c Release
Starts the GRPC Service

## dotnet run -p RESTvsGRPC -c Release
Runs the benchmark on the above services

`
BenchmarkDotNet=v0.12.0, OS=macOS 10.15 (19A602) [Darwin 19.0.0]
Intel Core i5-5257U CPU 2.70GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT


|                         Method | IterationCount |         Mean |      Error |       StdDev |       Median |
|------------------------------- |--------------- |-------------:|-----------:|-------------:|-------------:|
|       RestGetSmallPayloadAsync |            100 |     40.16 ms |   0.644 ms |     0.503 ms |     40.14 ms |
|       RestGetLargePayloadAsync |            100 |  1,590.55 ms |  18.170 ms |    16.996 ms |  1,587.82 ms |
|      RestPostLargePayloadAsync |            100 |  2,203.04 ms |  25.782 ms |    21.529 ms |  2,202.28 ms |
|       GrpcGetSmallPayloadAsync |            100 |     24.33 ms |   0.481 ms |     1.116 ms |     24.06 ms |
|    GrpcStreamLargePayloadAsync |            100 |  5,664.69 ms | 112.364 ms |   237.014 ms |  5,670.20 ms |
| GrpcGetLargePayloadAsListAsync |            100 |    249.31 ms |   4.863 ms |     4.994 ms |    251.80 ms |
|      GrpcPostLargePayloadAsync |            100 |    244.96 ms |   4.717 ms |     3.939 ms |    244.08 ms |
|       RestGetSmallPayloadAsync |            200 |     78.13 ms |   3.594 ms |    10.255 ms |     75.03 ms |
|       RestGetLargePayloadAsync |            200 |  2,992.83 ms |  87.739 ms |   114.085 ms |  2,958.70 ms |
|      RestPostLargePayloadAsync |            200 |  4,009.29 ms |  15.999 ms |    14.966 ms |  4,005.68 ms |
|       GrpcGetSmallPayloadAsync |            200 |     45.67 ms |   0.490 ms |     0.409 ms |     45.68 ms |
|    GrpcStreamLargePayloadAsync |            200 | 11,753.38 ms | 529.112 ms | 1,509.585 ms | 11,362.19 ms |
| GrpcGetLargePayloadAsListAsync |            200 |    517.64 ms |  30.930 ms |    88.743 ms |    477.74 ms |
|      GrpcPostLargePayloadAsync |            200 |    450.06 ms |   9.350 ms |     9.602 ms |    446.73 ms |
`

