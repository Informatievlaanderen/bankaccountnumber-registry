namespace BankAccountNumberRegistry.BankAccount.Events
{
    using Be.Vlaanderen.Basisregisters.EventHandling;

    [EventName("BankAccountWasLinkedToPublicService")]
    [EventDescription("A bank account was linked to a public service.")]
    public class BankAccountWasLinkedToPublicService
    {
        public BankAccountWasLinkedToPublicService(
           )
        {

        }

        //[JsonConstructor]
        //public BankAccountWasLinkedToPublicService(
        //    string ovoNumber,
        //    Guid organisationBankAccountId,
        //    string bankAccountNumber,
        //    bool isIban,
        //    string bic,
        //    bool isBic,
        //    DateTime? validFrom,
        //    DateTime? validTo)
        //    : this(
        //        new OvoNumber(ovoNumber),
        //        organisationBankAccountId,
        //        bankAccountNumber,
        //        isIban,
        //        bic,
        //        isBic,
        //        validFrom,
        //        validTo) { }
    }
}
