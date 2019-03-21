namespace BankAccountNumberRegistry.Organisation.Commands
{
    public class RegisterOrganisation
    {
        public OvoNumber OvoNumber { get; }

        public RegisterOrganisation(OvoNumber ovoNumber) => OvoNumber = ovoNumber;
    }
}
