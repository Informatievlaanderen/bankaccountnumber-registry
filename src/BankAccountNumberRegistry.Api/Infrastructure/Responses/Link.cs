namespace BankAccountNumberRegistry.Api.Infrastructure.Responses
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Link", Namespace = "")]
    public class Link
    {
        public class Relations
        {
            public const string Home = "home";
            public const string Organisations = "organisations";
            public const string Organisation = "organisation";
            public const string BankAccountNumbers = "bankaccountnumbers";
            public const string BankAccountNumber = "bankaccountnumber";
        }

        [DataMember(Name = "Href", Order = 1)]
        public string Href { get; set; }

        [DataMember(Name = "Rel", Order = 2)]
        public string Rel { get; set; }

        [DataMember(Name = "Type", Order = 3)]
        public string Type { get; set; }

        public Link(string href, string rel, string type)
        {
            Href = href;
            Rel = rel;
            Type = type;
        }
    }
}
