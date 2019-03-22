namespace BankAccountNumberRegistry.Api.Tests
{
    using System.Threading.Tasks;
    using BankAccountNumberRegistry.Organisation.Commands;
    using Organisation.Requests;
    using FluentValidation.TestHelper;
    using Infrastructure;
    using Xunit;
    using Xunit.Abstractions;

    public class AddOrganisationBankAccountTests : ApiTest
    {
        public AddOrganisationBankAccountTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void should_validate_request()
        {
            var validator = new AddOrganisationBankAccountRequestValidator();

            //validator.ShouldHaveValidationErrorFor(x => x.OvoNumber, null as string);
            //validator.ShouldHaveValidationErrorFor(x => x.OvoNumber, "bla");
            //validator.ShouldHaveValidationErrorFor(x => x.OvoNumber, new string('a', OvoNumber.MaxLength + 10));

            //var validRequest = new AddOrganisationBankAccountRequest
            //{
            //    OvoNumber = "OVO003347"
            //};

            //validator.ShouldNotHaveValidationErrorFor(x => x.OvoNumber, validRequest);
        }

        [Fact]
        public async Task should_create_a_correct_command()
        {
            //var request = new AddOrganisationBankAccountRequest
            //{
            //};

            //var commands = await Post($"/v1/organisations/{request.OvoNumber}/bankaccountnumbers", request);

            //Assert.True(commands.Count == 1);

            //commands[0].IsEqual(
            //    new AddOrganisationBankAccount(
            //        new OvoNumber(request.OvoNumber)));
        }
    }
}
