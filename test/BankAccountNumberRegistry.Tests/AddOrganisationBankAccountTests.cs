namespace BankAccountNumberRegistry.Tests
{
    using AutoFixture;
    using BankAccountNumberRegistry;
    using Organisation.Commands;
    using Organisation.Events;
    using Infrastructure;
    using Be.Vlaanderen.Basisregisters.AggregateSource.Testing;
    using SqlStreamStore.Streams;
    using Xunit;
    using Xunit.Abstractions;

    public class AddOrganisationBankAccountTests : BankAccountNumberRegistryTest
    {
        public Fixture Fixture { get; }

        public AddOrganisationBankAccountTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            Fixture = new Fixture();
            Fixture.CustomizeOvoNumber();
        }

        [Fact]
        public void bank_account_should_have_been_added()
        {
            //var addOrganisationBankAccountCommand = Fixture.Create<AddOrganisationBankAccount>();

            //Assert(new Scenario()
            //    .GivenNone()
            //    .When(addOrganisationBankAccountCommand)
            //    .Then(addOrganisationBankAccountCommand.OvoNumber,
            //        new OrganisationBankAccountWasAdded(addOrganisationBankAccountCommand.OvoNumber)));
        }
    }
}
