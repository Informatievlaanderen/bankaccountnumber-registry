namespace BankAccountNumberRegistry.Api.Organisation.Responses
{
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.Serialization;
    using Infrastructure.Responses;
    using Projections.Api.OrganisationBankAccountNumberList;
    using Swashbuckle.AspNetCore.Filters;

    [DataContract(Name = "OrganisationBankAccountNumbers", Namespace = "")]
    public class OrganisationBankAccountNumberListResponse
    {
        /// <summary>
        /// Alle bankrekeningnummers van een organisatie.
        /// </summary>
        [DataMember(Name = "OrganisationBankAccountNumbers", Order = 1)]
        public List<OrganisationBankAccountNumberListItemResponse> OrganisationBankAccountNumbers { get; set; }

        /// <summary>
        /// Hypermedia links
        /// </summary>
        [DataMember(Name = "Links", Order = 2)]
        public List<Link> Links { get; set; }

        public OrganisationBankAccountNumberListResponse()
        {
            Links = new List<Link>
            {
                new Link("/", Link.Relations.Home, WebRequestMethods.Http.Get),
                new Link("/organisations", Link.Relations.Organisations, WebRequestMethods.Http.Post),
                //new Link($"/organisations/{}", Link.Relations.Organisation, WebRequestMethods.Http.Post)
            };
        }
    }

    [DataContract(Name = "OrganisationBankAccountNumber", Namespace = "")]
    public class OrganisationBankAccountNumberListItemResponse
    {
        /// <summary>
        /// OVO nummer van de organisatie
        /// </summary>
        [DataMember(Name = "OvoNummer", Order = 1)]
        public string OvoNumber { get; set; }

        /// <summary>
        /// Hypermedia links
        /// </summary>
        [DataMember(Name = "Links", Order = 2)]
        public List<Link> Links { get; set; }

        public OrganisationBankAccountNumberListItemResponse(
            OrganisationBankAccountNumberList organisationBankAccountNumberList)
        {
            //OvoNumber = organisationBankAccountNumberList.OvoNumber;

            //Links = new List<Link>
            //{
            //    new Link($"/organisations/{organisationList.OvoNumber}", Link.Relations.Organisation, WebRequestMethods.Http.Get),
            //    new Link($"/organisations/{organisationList.OvoNumber}/bankaccountnumbers", Link.Relations.BankAccountNumbers, WebRequestMethods.Http.Get)
            //};
        }
    }

    public class OrganisationBankAccountNumberListResponseExamples : IExamplesProvider
    {
        public object GetExamples()
            => new OrganisationBankAccountNumberListResponse
            {
                OrganisationBankAccountNumbers = new List<OrganisationBankAccountNumberListItemResponse>
                {
                    new OrganisationBankAccountNumberListItemResponse(
                        new OrganisationBankAccountNumberList { OvoNumber = "OVO003347" }),
                    new OrganisationBankAccountNumberListItemResponse(
                        new OrganisationBankAccountNumberList { OvoNumber = "OVO003348" }),
                }
            };
    }
}
