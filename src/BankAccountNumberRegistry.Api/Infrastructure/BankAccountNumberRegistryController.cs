namespace BankAccountNumberRegistry.Api.Infrastructure
{
    using System.Collections.Generic;
    using Be.Vlaanderen.Basisregisters.Api;
    using Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware;

    public abstract class BankAccountNumberRegistryController : ApiController
    {
        protected IDictionary<string, object> GetMetadata()
        {
            var ip = User.FindFirst(AddRemoteIpAddressMiddleware.UrnBasisregistersVlaanderenIp)?.Value;
            var correlationId = User.FindFirst(AddCorrelationIdMiddleware.UrnBasisregistersVlaanderenCorrelationId)?.Value;

            return new Dictionary<string, object>
            {
                { "Ip", ip },
                { "CorrelationId", correlationId }
            };
        }
    }
}
