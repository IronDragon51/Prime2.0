class Result
{
    public static bool satisfy = true;
    public static bool skip = true;
    public static int primeDigitSums(int n)
    {
        int count = 0;
        double min = (double)Math.Pow(10, (n - 1)) + 1;
        double max = ((double)Math.Pow(10, n)) - 1;
        int[] isPrimeArr = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43 };

        for (double currentNumber = min; currentNumber <= max; currentNumber++)
        {
            satisfy = true;
            skip = true;

            int numberOfDigits = 3;
            satisfy = SatisfyTheRule(numberOfDigits, currentNumber, n, isPrimeArr);
            if (!satisfy && skip)
            {
                currentNumber = RoundUpNumber(n, currentNumber, numberOfDigits);

                continue;
            }

            numberOfDigits = 4;
            satisfy = SatisfyTheRule(numberOfDigits, currentNumber, n, isPrimeArr);
            if (!satisfy && skip)
            {
                double round = (double)Math.Pow(10, n - numberOfDigits);
                double roundedNumber = Math.Round(currentNumber / round, 0) * round;
                if (roundedNumber > currentNumber)
                {
                    currentNumber = roundedNumber - 1;
                }
                else
                {
                    currentNumber = roundedNumber + round - 1;
                }

                continue;
            }

            numberOfDigits = 5;
            satisfy = SatisfyTheRule(numberOfDigits, currentNumber, n, isPrimeArr);
            if (!satisfy && skip)
            {
                double round = (double)Math.Pow(10, n - numberOfDigits);
                double roundedNumber = Math.Round(currentNumber / round, 0) * round;
                if (roundedNumber > currentNumber)
                {
                    currentNumber = roundedNumber - 1;
                }
                else
                {
                    currentNumber = roundedNumber + round - 1;
                }

                continue;
            }

            if (satisfy)
            {
                count++;
            }
        }

        return count;
    }

    private static double RoundUpNumber(int n, double currentNumber, int numberOfDigits)
    {
        double round = (double)Math.Pow(10, n - numberOfDigits);
        double roundedNumber = Math.Round(currentNumber / round, 0) * round;
        if (roundedNumber > currentNumber)
        {
            currentNumber = roundedNumber - 1;
        }
        else
        {
            currentNumber = roundedNumber + round - 1;
        }

        return currentNumber;
    }

    public static bool SatisfyTheRule(int numberOfDigits, double currentNumber, int n, int[] isPrimeArr)
    {
        if (satisfy)
        {
            for (int j = 0; j + (numberOfDigits - 1) < n; j++)
            {
                int sumDigits = currentNumber.ToString().Substring(j, numberOfDigits).Sum(c => c - '0');

                if (!isPrimeArr.Contains(sumDigits))
                {
                    satisfy = false;
                    break;
                }
                else
                {
                    skip = false;
                }
            }
        }
        return satisfy;
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
