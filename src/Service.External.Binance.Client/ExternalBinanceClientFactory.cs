using System;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using JetBrains.Annotations;
using MyJetWallet.Domain.ExternalMarketApi;
using MyJetWallet.Sdk.GrpcMetrics;
using ProtoBuf.Grpc.Client;

namespace Service.External.Binance.Client
{
    [UsedImplicitly]
    public class ExternalBinanceClientFactory
    {
        private readonly CallInvoker _channel;

        public ExternalBinanceClientFactory(string assetsDictionaryGrpcServiceUrl)
        {
            _channel = ClientFactoryHelper.CreateCallInvoker(assetsDictionaryGrpcServiceUrl);
        }

        public IOrderBookSource GetOrderBookSource() => _channel.CreateGrpcService<IOrderBookSource>();
        public IExternalMarket GetExternalMarket() => _channel.CreateGrpcService<IExternalMarket>();
    }
}
