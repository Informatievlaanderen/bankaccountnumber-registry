namespace BankAccountNumberRegistry.Api.Organisation.Responses
{
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.Serialization;
    using Infrastructure.Responses;
    using Projections.Api.OrganisationList;
    using Swashbuckle.AspNetCore.Filters;

    [DataContract(Name = "Organisations", Namespace = "")]
    public class OrganisationListResponse
    {
        /// <summary>
        /// Alle organisaties.
        /// </summary>
        [DataMember(Name = "Organisations", Order = 1)]
        public List<OrganisationListItemResponse> Organisations { get; set; }

        /// <summary>
        /// Hypermedia links
        /// </summary>
        [DataMember(Name = "Links", Order = 2)]
        public List<Link> Links { get; set; }

        public OrganisationListResponse()
        {
            Links = new List<Link>
            {
                new Link("/", Link.Relations.Home, WebRequestMethods.Http.Get),
                new Link("/organisations", Link.Relations.Organisations, WebRequestMethods.Http.Post)
            };
        }
    }

    [DataContract(Name = "Organisation", Namespace = "")]
    public class OrganisationListItemResponse
    {
        /// <summary>
        /// OVO nummer van de organisatie
        /// </summary>
        [DataMember(Name = "OvoNumber", Order = 1)]
        public string OvoNumber { get; set; }

        /// <summary>
        /// Hypermedia links
        /// </summary>
        [DataMember(Name = "Links", Order = 2)]
        public List<Link> Links { get; set; }

        public OrganisationListItemResponse(
            OrganisationList organisationList)
        {
            OvoNumber = organisationList.OvoNumber;

            Links = new List<Link>
            {
                new Link($"/organisations/{organisationList.OvoNumber}", Link.Relations.Organisation, WebRequestMethods.Http.Get),
                new Link($"/organisations/{organisationList.OvoNumber}/bankaccountnumbers", Link.Relations.BankAccountNumbers, WebRequestMethods.Http.Get)
            };
        }
    }

    public class OrganisationListResponseExamples : IExamplesProvider
    {
        public object GetExamples()
            => new OrganisationListResponse
            {
                Organisations = new List<OrganisationListItemResponse>
                {
                    new OrganisationListItemResponse(
                        new OrganisationList { OvoNumber = "OVO003347" }),
                    new OrganisationListItemResponse(
                        new OrganisationList { OvoNumber = "OVO003348" }),
                }
            };
    }
}
