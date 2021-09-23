using System;

namespace Matrices
{
    class Program
    {
        static double[,] Check(double[,] output, int[,] arr)
        {
            double[,] C = new double[output.GetLength(0), output.GetLength(0)];//Create matrix of check
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int y = 0; y < C.GetLength(0); y++)
                {
                    Console.Write("C({0},{1}) = ", i + 1, y + 1);//display the number of element
                    for (int j = 0; j < C.GetLength(0); j++)
                    {
                        C[i, y] += output[i, j] * arr[j, y];
                        if (j != C.GetLength(0) - 1)
                            Console.Write("({0} * {1}) + ", Math.Round(output[i, j], 2, MidpointRounding.ToEven), arr[j, y]);//display operations
                        else
                            Console.Write("({0} * {1})", Math.Round(output[i, j], 2, MidpointRounding.ToEven), arr[j, y]);
                    }
                    C[i, y] = Math.Round(C[i, y], 2, MidpointRounding.ToEven);//count sum of operations
                    Console.SetCursorPosition(50, Console.CursorTop - 0);
                    Console.WriteLine(" = " + C[i, y]);
                }
            }
            return C;
        }
        static double[,] Check(int[,] arr, double[,] output)
        {
            double[,] C = new double[output.GetLength(0), output.GetLength(0)];//Create matrix of check
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int y = 0; y < C.GetLength(0); y++)
                {
                    Console.Write("C({0},{1}) = ", i + 1, y + 1);//display the number of element
                    for (int j = 0; j < C.GetLength(0); j++)
                    {
                        C[i, y] += arr[i, j] * output[j, y];
                        if (j != C.GetLength(0) - 1)
                            Console.Write("({0} * {1}) + ", arr[i, j], Math.Round(output[j, y], 2, MidpointRounding.ToEven));//display operations
                        else
                            Console.Write("({0} * {1})", arr[i, j], Math.Round(output[j, y], 2, MidpointRounding.ToEven));
                    }
                    C[i, y] = Math.Round(C[i, y], 2, MidpointRounding.ToEven);//count sum of operations
                    Console.SetCursorPosition(50, Console.CursorTop - 0);
                    Console.WriteLine(" = " + C[i, y]);
                }
            }
            return C;
        }
        static int[,] Sum_Matrix(int[,] A, int[,] B)
        {
            int[,] C = new int[A.GetLength(0), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(0); j++)
                    C[i, j] = A[i, j] + B[i, j];
            return C;
        }
        static int[,] MultiPlay_On_Number(int[,] A3, int a)
        {
            for (int i = 0; i < A3.GetLength(0); i++)
                for (int j = 0; j < A3.GetLength(0); j++)
                    A3[i, j] *= a;
            return A3;
        }
        static double[,] Multiplay(int[,] A, int[,] B)
        {
            double[,] C = new double[A.GetLength(0), A.GetLength(0)];
            for (int i = 0; i < C.GetLength(0); i++)
                for (int y = 0; y < C.GetLength(0); y++)
                    for (int j = 0; j < C.GetLength(0); j++)
                        C[i, y] += (A[i, j] * B[j, y]);
            return C;
        }
        static int[,] InputMatrix(int[,] arr)
        {
            Console.WriteLine("Enter the matrix");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(4 * (j + 1), Console.CursorTop - 1);
                }
                Console.WriteLine();
            }
            return arr;
        }
        static double Determinate(int[,] arr)
        {
            double determinate = 0;
            if (arr.GetLength(0) == 2)//method of two diagonals
                determinate = arr[0, 0] * arr[1, 1] - arr[0, 1] * arr[1, 0];
            else if (arr.GetLength(0) == 3)
            {//Star method
                determinate = arr[0, 0] * arr[1, 1] * arr[2, 2] +
                               arr[0, 1] * arr[1, 2] * arr[2, 0] +
                               arr[0, 2] * arr[1, 0] * arr[2, 1] -
                               arr[0, 2] * arr[1, 1] * arr[2, 0] -
                               arr[0, 1] * arr[1, 0] * arr[2, 2] -
                               arr[0, 0] * arr[1, 2] * arr[2, 1];
            }
            else if (arr.GetLength(0) == 4)
            {//Minor's method
                int[,] newarr = new int[3, 3];
                for (int a = 0; a < 4; a++)
                {
                    for (int i = 1; i < 4; i++)
                        for (int x = 0, j = 0; j < 4; j++)
                            if (j != a)
                                newarr[x++, i - 1] = arr[j, i];
                    determinate += arr[a, 0] * (int)Math.Pow(-1, a + 2) * Determinate(newarr);
                }
            }
            return determinate;
        }
        static void OutputMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
        }
        static void OutputMatrix(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\ndet - determinate\nA*B - matrix multiplication\n3A - matrix multiplication by number\nA+B - Sum of matrices\n" +
                                  "multi - addition operations (-4A + B / A - B)\nA^T - Reverse matrix\n" +
                                  "SLE - Systems of line equaintance by Gausse's method\nclear - clear console");
                switch (Console.ReadLine().ToLower())
                {
                    case "sle":
                        #region
                        Console.WriteLine("Enter the number of variables");
                        int n = Convert.ToInt32(Console.ReadLine());
                        string[] equations = new string[n];
                        double[,] sle = new double[n, n + 1];
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Enter the equations {0} (Example: 3a-4b-8c+y)", i + 1);
                            equations[i] = Console.ReadLine();
                        }
                        for (int i = 0; i < n; i++) //Convert equations to matrix
                        {
                            for (int j = 0, y = 0; j < equations[i].Length; j++)
                            {
                                if (Char.IsLetter(equations[i][j]))
                                {
                                    if (j - 1 >= 0 && Char.IsDigit(equations[i][j - 1]))
                                    {
                                        if (j - 2 >= 0 && equations[i][j - 2] == '-')
                                            sle[i, y++] = Convert.ToInt32(Convert.ToString(equations[i][j - 2]) + Convert.ToString(equations[i][j - 1]));
                                        else if (j - 2 >= 0 && Char.IsDigit(equations[i][j - 2]))
                                        {
                                            if (j - 3 >= 0 && equations[i][j - 3] == '-')
                                                sle[i, y++] = Convert.ToInt32(Convert.ToString(equations[i][j - 3]) + Convert.ToString(equations[i][j - 2]) + Convert.ToString(equations[i][j - 1]));
                                            else
                                                sle[i, y++] = Convert.ToInt32(Convert.ToString(equations[i][j - 2]) + Convert.ToString(equations[i][j - 1]));
                                        }
                                        else
                                            sle[i, y++] = Convert.ToInt32(Convert.ToString(equations[i][j - 1]));
                                    }
                                    else if (j - 1 >= 0 && equations[i][j - 1] == '-')
                                        sle[i, y++] = -1;
                                    else
                                        sle[i, y++] = 1;
                                }
                                else if (equations[i][j] == '=')
                                {
                                    sle[i, sle.GetLength(1) - 1] = j + 2 < equations[i].Length ? Convert.ToInt32(Convert.ToString(equations[i][j + 1]) + Convert.ToString(equations[i][j + 2])) : Convert.ToInt32(Convert.ToString(equations[i][j + 1]));
                                    break;
                                }
                            }

                        }
                        OutputMatrix(sle);
                        Console.WriteLine("\n\n");
                        for (int k = 0; k < sle.GetLength(0) - 1; k++)//Work on matrix
                        {
                            for (int i = k + 1; i < sle.GetLength(0); i++)
                            {
                                if (sle[i, i - 1] == sle[k, k])
                                {
                                    for (int j = k; j < sle.GetLength(1); j++)
                                    {
                                        sle[i, j] -= sle[k, j];
                                    }
                                }
                                else
                                {
                                    double temp = sle[i, k];
                                    for (int j = k; j < sle.GetLength(1); j++)
                                    {
                                        sle[i, j] *= sle[k, k];
                                        sle[i, j] -= sle[k, j] * temp;
                                    }
                                }
                            }
                        }
                        OutputMatrix(sle);
                        double[] item = new double[n];
                        for (int i = sle.GetLength(0) - 1; i >= 0; i--)
                        {
                            double temp = sle[i, sle.GetLength(1) - 1];
                            for (int j = i + 1; j < sle.GetLength(1) - 1; j++)
                                temp -= sle[i, j] * item[j];
                            item[i] = temp / sle[i, i];
                        }
                        for (int i = 0; i < item.Length; i++)
                            Console.WriteLine(Convert.ToChar(97 + i) + " = " + item[i]);
                        break;
                    #endregion
                    case "det":
                        #region
                        Console.WriteLine("Enter the matrix order");
                        int b = Convert.ToInt32(Console.ReadLine());
                        int[,] matrix = new int[b, b];
                        InputMatrix(matrix);
                        Console.WriteLine("Determinate = " + Determinate(matrix));
                        break;
                    #endregion
                    case "a*b":
                        #region
                        Console.WriteLine("Enter the matrix order");
                        int a = Convert.ToInt32(Console.ReadLine());
                        int[,] A = new int[a, a];
                        int[,] B = new int[a, a];
                        Console.WriteLine("Enter matrix A");
                        InputMatrix(A);
                        Console.WriteLine("Enter matrix B");
                        InputMatrix(B);
                        OutputMatrix(Multiplay(A, B));
                        break;
                    #endregion
                    case "3a":
                        #region
                        Console.WriteLine("Enter the matrix order");
                        int c = Convert.ToInt32(Console.ReadLine());
                        int[,] A3 = new int[c, c];
                        InputMatrix(A3);
                        Console.WriteLine("What is the number to multiply the matrix by?");
                        OutputMatrix(MultiPlay_On_Number(A3, Convert.ToInt32(Console.ReadLine())));
                        break;
                    #endregion
                    case "a+b":
                        #region
                        Console.WriteLine("Enter the matrix order");
                        int AB = Convert.ToInt32(Console.ReadLine());
                        int[,] Ab = new int[AB, AB];
                        int[,] Ba = new int[AB, AB];
                        Console.WriteLine("Enter matrix A");
                        InputMatrix(Ab);
                        Console.WriteLine("Enter matrix B");
                        InputMatrix(Ba);
                        OutputMatrix(Sum_Matrix(Ab, Ba));
                        break;
                    #endregion
                    case "Multi":
                        #region
                        Console.WriteLine("Enter the matrix order");
                        int MultiR = Convert.ToInt32(Console.ReadLine());
                        int[,] MultiA = new int[MultiR, MultiR];
                        int[,] MultiB = new int[MultiR, MultiR];
                        Console.WriteLine("Enter matrix A");
                        InputMatrix(MultiA);
                        Console.WriteLine("Enter matrix B");
                        InputMatrix(MultiB);
                        Console.WriteLine("Enter matrix operations (-4A+B)");
                        string Multi = Console.ReadLine().ToUpper();
                        for (int i = 0; i < Multi.Length; i++)
                        {
                            if (Multi[i] == 'A' || Multi[i] == 'B')
                            {
                                if (i - 1 >= 0 && Char.IsDigit(Multi[i - 1]))
                                {
                                    if (i - 2 >= 0 && Multi[i - 2] == '-')
                                    {
                                        if (Multi[i] == 'A')
                                            MultiPlay_On_Number(MultiA, -1 * Convert.ToInt32(Convert.ToString(Multi[i - 1])));
                                        else
                                            MultiPlay_On_Number(MultiB, -1 * Convert.ToInt32(Convert.ToString(Multi[i - 1])));
                                    }
                                    else
                                    {
                                        if (Multi[i] == 'A')
                                            MultiPlay_On_Number(MultiA, Convert.ToInt32(Convert.ToString(Multi[i - 1])));
                                        else
                                            MultiPlay_On_Number(MultiB, Convert.ToInt32(Convert.ToString(Multi[i - 1])));
                                    }
                                }
                                else if (i - 1 >= 0 && Multi[i - 1] == '-')
                                {
                                    if (Multi[i] == 'A')
                                        MultiPlay_On_Number(MultiA, -1);
                                    else
                                        MultiPlay_On_Number(MultiB, -1);
                                }
                            }
                        }
                        OutputMatrix(Sum_Matrix(MultiA, MultiB));
                        break;
                    #endregion
                    case "A^T":
                        #region
                        Console.WriteLine("Enter matrix order");
                        int rang = Convert.ToInt32(Console.ReadLine());
                        int[,] arr = new int[rang, rang];
                        double[,] output = new double[arr.GetLength(0), arr.GetLength(0)];
                        Console.WriteLine("Reverse matrix");
                        InputMatrix(arr);
                        for (int i = 0; i < arr.GetLength(0); i++)
                        {
                            int[,] newarr = new int[arr.GetLength(0) - 1, arr.GetLength(0) - 1];
                            for (int j = 0; j < arr.GetLength(0); j++)//Indexes(i,j) iterate over the values ​​of the columns and rows that need to be cut
                            {
                                for (int x = 0, k = 0; x < arr.GetLength(0); x++)
                                {
                                    for (int y = 0, o = 0; y < arr.GetLength(0); y++)
                                    {
                                        if (x != i && y != j)
                                        {
                                            newarr[k, o++] = arr[x, y]; //Writes cut out matrix, x and j - index of main matrix
                                            if (o == newarr.GetLength(0))// k and o - index of cut out matrix(newarr[])
                                            {
                                                o = 0;
                                                k++;
                                            }
                                        }
                                    }
                                }
                                output[j, i] = (int)Math.Pow(-1, i + j + 2) * Determinate(newarr);//Execute operations on cut out matrix and writes the number in finite matrix(output[])
                                Console.WriteLine("C({0},{1}) = {2}", i + 1, j + 1, output[j, i]);//Indices is transpoted
                            }
                        }
                        for (int i = 0, d = (int)Determinate(arr); i < output.GetLength(0); i++)
                        {
                            for (int j = 0; j < output.GetLength(0); j++)
                            {
                                Console.Write(output[i, j] + "/" + d + "\t"); //Division of finite matrix
                                output[i, j] /= d;
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("To see the check A * A^-1 press any key");
                        Console.ReadKey();
                        Console.WriteLine("\n\n");
                        OutputMatrix(Check(arr, output));
                        Console.WriteLine("To see the check A^-1 * A press any key");
                        Console.ReadKey();
                        Console.WriteLine("\n\n");
                        OutputMatrix(Check(output, arr));
                        break;
                    #endregion
                    case "clear":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Input Error");
                        break;
                }
            }
        }
    }
}
