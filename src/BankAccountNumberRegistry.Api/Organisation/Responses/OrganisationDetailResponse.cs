namespace BankAccountNumberRegistry.Api.Organisation.Responses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using Infrastructure.Responses;
    using Projections.Api.OrganisationDetail;
    using Swashbuckle.AspNetCore.Filters;

    [DataContract(Name = "Organisation", Namespace = "")]
    public class OrganisationDetailResponse
    {
        /// <summary>
        /// OVO nummer van de organisatie.
        /// </summary>
        [DataMember(Name = "OvoNumber", Order = 1)]
        public string OvoNumber { get; set; }

        /// <summary>
        /// Bankrekeningnummers van de organisatie.
        /// </summary>
        [DataMember(Name = "BankAccountNumbers", Order = 2)]
        public List<OrganisationDetailBankAccountNumberResponse> BankAccountNumbers { get; set; }

        /// <summary>
        /// Hypermedia links
        /// </summary>
        [DataMember(Name = "Links", Order = 3)]
        public List<Link> Links { get; set; }

        public OrganisationDetailResponse(
            OrganisationDetail organisationDetail)
        {
            OvoNumber = organisationDetail.OvoNumber;

            //BankAccountNumbers = organisationDetail
            //    .BankAccountNumbers
            //    .Select(x => new OrganisationDetailBankAccountNumberResponse(organisationDetail.OvoNumber, x.ServiceId, x.Type, x.Label))
            //    .ToList();

            Links = new List<Link>
            {
                new Link("/", Link.Relations.Home, WebRequestMethods.Http.Get),
                new Link("/organisations", Link.Relations.Organisations, WebRequestMethods.Http.Get),
                new Link($"/organisations/{organisationDetail.OvoNumber}/bankaccountnumbers", Link.Relations.BankAccountNumbers, WebRequestMethods.Http.Get),
                new Link($"/organisations/{organisationDetail.OvoNumber}/bankaccountnumbers", Link.Relations.BankAccountNumbers, WebRequestMethods.Http.Post),
            };
        }
    }

    [DataContract(Name = "OrganisationBankAccountNumber", Namespace = "")]
    public class OrganisationDetailBankAccountNumberResponse
    {
        /// <summary>
        /// Hypermedia links
        /// </summary>
        [DataMember(Name = "Links", Order = 4)]
        public List<Link> Links { get; set; }

        public OrganisationDetailBankAccountNumberResponse(
            string ovoNumber)
        {
            Links = new List<Link>
            {
                //new Link($"/organisations/{ovoNumber}/bankaccountnumbers/{id}", Link.Relations.BankAccountNumber, WebRequestMethods.Http.Get),
            };
        }
    }

    public class OrganisationResponseExamples : IExamplesProvider
    {
        private static readonly Random Random = new Random();

        public object GetExamples() =>
            new OrganisationDetailResponse(
                new OrganisationDetail
                {
                    OvoNumber = "OVO003347",
                    //BankAccountNumbers = new[]
                    //{
                    //    new OrganisationDetail.OrganisationDetailBankAccountNumber(...),
                    //}
                });
    }
}
