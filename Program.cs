class Result
{
    public static bool satisfy = true;
    public static int primeDigitSums(int n)
    {
        int count = 0;
        long min = (long)Math.Pow(10, (n - 1)) + 1;
        long max = ((long)Math.Pow(10, n)) - 1;
        bool[] isPrimeArr = FillIsPrimeArray();

        for (long currentNumber = min; currentNumber <= max; currentNumber++)
        {
            satisfy = true;

            int numberOfDigits = 3;
            SatisfyTheRule(numberOfDigits, currentNumber, n);
            if (!satisfy)
            {
                continue;
            }

            numberOfDigits = 4;
            SatisfyTheRule(numberOfDigits, currentNumber, n);
            if (!satisfy)
            {
                continue;
            }

            numberOfDigits = 5;
            SatisfyTheRule(numberOfDigits, currentNumber, n);
            if (!satisfy)
            {
                continue;
            }

            if (satisfy)
            {
                count++;
            }
        }

        return count;
    }

    public static void SatisfyTheRule(int numberOfDigits, long currentNumber, int n)
    {
        if (satisfy)
        {
            for (int j = 0; j + (numberOfDigits - 1) < n; j++)
            {
                int sumDigits = currentNumber.ToString().Substring(j, numberOfDigits).Sum(c => c - '0');

                satisfy = IsPrime(sumDigits);
                if (!satisfy)
                {
                    break;
                }
            }
        }
    }

    public static bool[] FillIsPrimeArray()
    {
        bool[] isPrimeArr = new bool[45];

        for (int i = 0; i < isPrimeArr.Length; i++)
        {
            isPrimeArr[i] = IsPrime(i);
        }

        return isPrimeArr;
    }

    public static bool IsPrime(int sumDigits)
    {
        if (sumDigits == 2) return true;
        if (sumDigits % 2 == 0) return false;
        if (sumDigits <= 1) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(sumDigits));

        for (int i = 3; i <= boundary; i += 2)
            if (sumDigits % i == 0)
                return false;

        return true;
    }



}

class Solution
{
    public static void Main(string[] args)
    {

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.primeDigitSums(n);

            Console.WriteLine(result);
        }

    }
}
