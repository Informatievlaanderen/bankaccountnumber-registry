namespace BankAccountNumberRegistry.Tests
{
    using Exceptions;
    using Xunit;

    public class OvoNumberTests
    {
        [Fact]
        public void ovo_cannot_be_empty()
        {
            void NullOvoNumber() => new OvoNumber(null);

            var ex = Record.Exception(NullOvoNumber);

            Assert.NotNull(ex);
            Assert.IsType<EmptyOvoNumberException>(ex);
        }

        [Fact]
        public void ovo_cannot_be_over_maxlength()
        {
            void TooLongOvoNumber() => new OvoNumber(new string('a', OvoNumber.MaxLength + 10));

            var ex = Record.Exception(TooLongOvoNumber);

            Assert.NotNull(ex);
            Assert.IsType<OvoNumberTooLongException>(ex);
        }

        [Theory]
        [InlineData("OVO003347")]
        [InlineData("OVO003348")]
        public void ovo_must_be_valid(string name)
        {
            void ValidOvoNumber() => new OvoNumber(name);

            var ex = Record.Exception(ValidOvoNumber);

            Assert.Null(ex);
        }
    }
}
