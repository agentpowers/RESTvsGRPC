using Grpc.Core;
using Grpc.Net.Client;
using ModelLibrary.GRPC;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static ModelLibrary.GRPC.MeteoriteLandingsService;

namespace RESTvsGRPC
{
    public class GRPCClientV2
    {
        private readonly GrpcChannel channel;
        private readonly MeteoriteLandingsServiceClient client;

        public GRPCClientV2()
        {
            var httpClientHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpClientHandler.ServerCertificateCustomValidationCallback = 
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var httpClient = new HttpClient(httpClientHandler);

            channel = GrpcChannel.ForAddress("https://localhost:6001", new GrpcChannelOptions { HttpClient = httpClient });
            client = new MeteoriteLandingsServiceClient(channel);
        }

        public async Task<string> GetSmallPayloadAsync()
        {
            return (await client.GetVersionAsync(new EmptyRequest())).ApiVersion;
        }

        public async Task<List<MeteoriteLanding>> StreamLargePayloadAsync()
        {
            List<MeteoriteLanding> meteoriteLandings = new List<MeteoriteLanding>();

            using (var response = client.GetLargePayload(new EmptyRequest()))
            {
                while (await response.ResponseStream.MoveNext())
                {
                    meteoriteLandings.Add(response.ResponseStream.Current);
                }
            }

            return meteoriteLandings;
        }

        public async Task<IList<MeteoriteLanding>> GetLargePayloadAsListAsync()
        {
            return (await client.GetLargePayloadAsListAsync(new EmptyRequest())).MeteoriteLandings;
        }

        public async Task<string> PostLargePayloadAsync(MeteoriteLandingList meteoriteLandings)
        {
            return (await client.PostLargePayloadAsync(meteoriteLandings)).Status;
        }
    }
}
