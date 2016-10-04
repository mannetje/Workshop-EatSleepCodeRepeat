using System;
namespace eu.sig.training.ch04.v1
{
    public class CheckingAccount : AbstractAccount
    {
        private int transferLimit = 100;

        public Transfer MakeTransfer(String counterAccount, Money amount)
        {
            // 1. Check withdrawal limit:
            AssertAmount(amount);
            AssertCounterAccount(counterAccount);

            // 2. Assuming result is 9-digit bank account number, validate 11-test:
            int sum = Do11Test(counterAccount);
            if (sum % 11 == 0)
            {
                // 3. Look up counter account and make transfer object:
                CheckingAccount acct = Accounts.FindAcctByNumber(counterAccount);
                Transfer result = new Transfer(this, acct, amount);
                return result;
            }
            else
            {
                throw new BusinessException("Invalid account number!");
            }
        }

        private void AssertAmount(Money amount)
        {
            if (amount.GreaterThan(this.transferLimit))
            {
                throw new BusinessException("Limit exceeded!");
            }
        }
    }
}