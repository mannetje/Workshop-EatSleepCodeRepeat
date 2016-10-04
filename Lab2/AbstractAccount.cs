using eu.sig.training.ch04;
using System;

public abstract class AbstractAccount
{
	protected AbstractAccount()
	{
    }

    protected static int Do11Test(string counterAccount)
    {
        int sum = 0;
        for (int i = 0; i < counterAccount.Length; i++)
        {
            sum = sum + (9 - i) * (int)Char.GetNumericValue(counterAccount[i]);
        }

        return sum;
    }

    protected static void AssertCounterAccount(string counterAccount)
    {
        // 1. Assuming result is 9-digit bank account number, validate 11-test:
        if (String.IsNullOrEmpty(counterAccount) || counterAccount.Length != 9)
        {
            throw new BusinessException("Invalid account number!");
        }
    }
}
