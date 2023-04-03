class Result
{
    public static bool satisfy = true;
    public static int primeDigitSums(int n)
    {
        int count = 0;
        long min = (long)Math.Pow(10, (n - 1)) + 1;
        long max = ((long)Math.Pow(10, n)) - 1;
        int[] isPrimeArr = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43 };

        for (long currentNumber = min; currentNumber <= max; currentNumber++)
        {
            satisfy = true;

            if (currentNumber == 101101)
            {
                Console.WriteLine();
            }

            int numberOfDigits = 3;
            satisfy = SatisfyTheRule(numberOfDigits, currentNumber, n, isPrimeArr);
            if (!satisfy)
            {
                currentNumber += (int)Math.Pow(10, n - 2) / 10 - 1;
                long round = (long)Math.Pow(10, n - numberOfDigits);
                long number = (long)Math.Floor(Convert.ToDouble(currentNumber / round)) * round;
                continue;
            }

            numberOfDigits = 4;
            satisfy = SatisfyTheRule(numberOfDigits, currentNumber, n, isPrimeArr);
            if (!satisfy)
            {
                currentNumber += (int)Math.Pow(10, n - 3) / 10 - 1;
                long round = (long)Math.Pow(10, n - numberOfDigits);
                long number = (long)Math.Round(Convert.ToDouble(currentNumber / round), 0) * round;
                continue;
            }

            numberOfDigits = 5;
            satisfy = SatisfyTheRule(numberOfDigits, currentNumber, n, isPrimeArr);
            if (!satisfy)
            {
                currentNumber += (int)Math.Pow(10, n - 4) / 10 - 1;
                long round = (long)Math.Pow(10, n - numberOfDigits);
                long number = (long)Math.Round(Convert.ToDouble(currentNumber / round), 0) * round;
                continue;
            }

            if (satisfy)
            {
                count++;
            }
        }

        return count;
    }

    public static bool SatisfyTheRule(int numberOfDigits, long currentNumber, int n, int[] isPrimeArr)
    {
        if (satisfy)
        {
            for (int j = 0; j + (numberOfDigits - 1) < n; j++)
            {
                int sumDigits = currentNumber.ToString().Substring(j, numberOfDigits).Sum(c => c - '0');

                if (isPrimeArr.Contains(sumDigits))
                {
                    satisfy = true;
                }
                else
                {
                    satisfy = false;
                    break;
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
