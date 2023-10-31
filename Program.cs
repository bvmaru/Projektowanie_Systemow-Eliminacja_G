using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

//double[,] a = { { 2, -2, -2, -2 }, { -1, 3, 4, 4 }, { 5, 2, 3, 8 } };
int N = 3;
Random random = new Random();
//var a = Matrix<double>.Build.Random(N, N+1);
var a = Matrix<double>.Build.Random(N, N + 1).Multiply(random.Next(1,100));
var m = Matrix<double>.Build.Dense(N,N);



//double[,] m = new double[N, N-1];

for (int i = 0; i < N - 1; i++)
{
    for (int j = i + 1; j < N; j++)
    {
        if (a[i, i] != 0)
        {
            m[j, i] = -a[j, i] / a[i, i];
        }
        else
        {
            m[j, i] = 0;
        }

        for (int k = i + 1; k < N + 1; k++)
        {
            a[j, k] = a[j, k] + m[j, i] * a[i, k];
        }
    }
}



//for(int i=0; i<N-1; i++)
//{
//    for(int j=i+1; j<N; j++)
//    {
//        if (A[i, i] != 0) M[j, i] = -A[j, i] / A[i, i];
//        else M[j, i] = 0;
//    }
//    for (int j = i + 1; j < N; j++)
//    {
//        for (int k = i + 1; k < N+1; k++)
//        {
//            A[j, k] = A[j, k] + M[j, i] * A[i, k];
//        }
//    }
//}
Console.WriteLine("Hello, World!");


