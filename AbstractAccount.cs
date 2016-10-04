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
}
