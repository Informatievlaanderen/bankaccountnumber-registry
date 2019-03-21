namespace Dns.Tests
{
    using AutoFixture;
    using BankAccountNumberRegistry;
    using BankAccountNumberRegistry.Organisation.Commands;
    using BankAccountNumberRegistry.Organisation.Events;
    using BankAccountNumberRegistry.Tests.Infrastructure;
    using Be.Vlaanderen.Basisregisters.AggregateSource.Testing;
    using SqlStreamStore.Streams;
    using Xunit;
    using Xunit.Abstractions;

    public class RegisterOrganisationTests : BankAccountNumberRegistryTest
    {
        public Fixture Fixture { get; }

        public RegisterOrganisationTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            Fixture = new Fixture();
            Fixture.CustomizeOvoNumber();
        }

        [Fact]
        public void organisation_should_have_been_registered()
        {
            var registerOrganisationCommand = Fixture.Create<RegisterOrganisation>();

            Assert(new Scenario()
                .GivenNone()
                .When(registerOrganisationCommand)
                .Then(registerOrganisationCommand.OvoNumber,
                    new OrganisationWasRegistered(registerOrganisationCommand.OvoNumber)));
        }

        [Fact]
        public void organisation_should_not_be_duplicated()
        {
            var ovoNumber = Fixture.Create<OvoNumber>();
            var registerOrganisationCommand = new RegisterOrganisation(ovoNumber);

            Assert(new Scenario()
                .Given(ovoNumber,
                    new OrganisationWasRegistered(ovoNumber))
                .When(registerOrganisationCommand)
                .Throws(new WrongExpectedVersionException($"Append failed due to WrongExpectedVersion.Stream: {ovoNumber}, Expected version: -1")));
        }
    }
}
