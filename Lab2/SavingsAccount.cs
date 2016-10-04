using System;

namespace eu.sig.training.ch04.v1
{
    public class SavingsAccount : AbstractAccount
    {
        public CheckingAccount RegisteredCounterAccount { get; set; }

        public Transfer makeTransfer(string counterAccount, Money amount)
        {
            AssertCounterAccount(counterAccount);
            int sum = Do11Test(counterAccount);

            if (sum % 11 == 0)
            {
                return TransferMoney(counterAccount, amount);
            }
            else
            {
                throw new BusinessException("Invalid account number!!");
            }
        }

        private Transfer TransferMoney(string counterAccount, Money amount)
        {
            // 2. Look up counter account and make transfer object:
            CheckingAccount acct = Accounts.FindAcctByNumber(counterAccount);
            Transfer result = new Transfer(this, acct, amount); // <2>
                                                                // 3. Check whether withdrawal is to registered counter account:
            if (result.CounterAccount.Equals(this.RegisteredCounterAccount))
            {
                return result;
            }
            else
            {
                throw new BusinessException("Counter-account not registered!");
            }
        }
    }
}
