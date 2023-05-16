namespace LCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string x = "AGGTAB";
            string y = "GXTXAYB";
            int l1 = x.Length;
            int l2 = y.Length;

            Console.WriteLine($"LCS recursive = {lcsRecursive(x, y, l1, l2)} \n\n");
            Console.WriteLine($"LCS dinamic:");
            lcsDinamic(x, y, l1, l2);
        }
        static int lcsRecursive(string X, string Y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;
            if (X[m - 1] == Y[n - 1])
                return 1 + lcsRecursive(X, Y, m - 1, n - 1);
            else
                return Math.Max(lcsRecursive(X, Y, m, n - 1),
                           lcsRecursive(X, Y, m - 1, n));
        }

        static void lcsDinamic(string S1, string S2, int m, int n)
        {
            int[,] LCS_table = new int[m + 1, n + 1];

            // Building the mtrix in bottom-up way
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        LCS_table[i,j] = 0;
                    else if (S1[i - 1] == S2[j - 1])
                        LCS_table[i,j] = LCS_table[i - 1, j - 1] + 1;
                    else
                        LCS_table[i,j] = Math.Max(LCS_table[i - 1,j], LCS_table[i,j - 1]);
                }
            }

            int index = LCS_table[m,n];
            int temp = index;

            char[] lcs = new char[index + 1];
            lcs[index] = '\0';

            int i1 = m, j1 = n;
            while (i1 > 0 && j1 > 0)
            {
                if (S1[i1 - 1] == S2[j1 - 1])
                {
                    lcs[index - 1] = S1[i1 - 1];

                    i1--;
                    j1--;
                    index--;
                }

                else if (LCS_table[i1 - 1,j1] > LCS_table[i1,j1 - 1])
                    i1--;
                else
                    j1--;
            }

            // Printing the sub sequences
            Console.WriteLine("S1 : " + S1 + "\nS2 : " + S2 + "\nLCS: ");
            for (int k = 0; k <= temp; k++)
                Console.Write(lcs[k]);
            Console.WriteLine("");
        }
    }
}