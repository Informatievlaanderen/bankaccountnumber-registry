namespace BankAccountNumberRegistry.Api.Tests
{
    using System.Threading.Tasks;
    using BankAccountNumberRegistry.Organisation.Commands;
    using Organisation.Requests;
    using FluentValidation.TestHelper;
    using Infrastructure;
    using Xunit;
    using Xunit.Abstractions;

    public class RegisterOrganisationTests : ApiTest
    {
        public RegisterOrganisationTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void should_validate_request()
        {
            var validator = new RegisterOrganisationRequestValidator();

            validator.ShouldHaveValidationErrorFor(x => x.OvoNumber, null as string);
            validator.ShouldHaveValidationErrorFor(x => x.OvoNumber, "bla");
            validator.ShouldHaveValidationErrorFor(x => x.OvoNumber, new string('a', OvoNumber.MaxLength + 10));

            var validRequest = new RegisterOrganisationRequest
            {
                OvoNumber = "OVO003347"
            };

            validator.ShouldNotHaveValidationErrorFor(x => x.OvoNumber, validRequest);
        }

        [Fact]
        public async Task should_create_a_correct_command()
        {
            var request = new RegisterOrganisationRequest
            {
                OvoNumber = "OVO003347"
            };

            var commands = await Post("/v1/organisations", request);

            Assert.True(commands.Count == 1);

            commands[0].IsEqual(
                new RegisterOrganisation(
                    new OvoNumber(request.OvoNumber)));
        }
    }
}
