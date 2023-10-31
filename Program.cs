using Eliminacja_G;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.Diagnostics;


int sampleGroup = 15;
Stopwatch timer = new Stopwatch();
GaussElimination gauss = new GaussElimination();
Random random = new Random();
double[] timeTable = new double[sampleGroup];
//List<double> timeTable = new List<double>();

int N = 200;
gauss.nSize = N;


for (int i = 0; i< sampleGroup; i++)
{ 
    gauss.aMatrix = Matrix<double>.Build.Random(N, N + 1).Multiply(random.Next(1,100));
    gauss.mMatrix = Matrix<double>.Build.Dense(N,N);
    timer.Restart();
    gauss.Calculate();
    timeTable[i] = timer.Elapsed.TotalMilliseconds;
    //timeTable.Add(timer.Elapsed.TotalMilliseconds);
    timer.Stop();
}

Console.WriteLine($"Time measurements for the N = {N}:");
for (int i = 0; i < sampleGroup; i++) Console.WriteLine($"{i+1}) {timeTable[i]} ms");
Console.WriteLine($"Average time: {timeTable.Average()} ms");



//double[,] m = new double[N, N-1];

//void Calculate()
//{
//    for (int i = 0; i < N - 1; i++)
//    {
//        for (int j = i + 1; j < N; j++)
//        {
//            if (a[i, i] != 0)
//            {
//                m[j, i] = -a[j, i] / a[i, i];
//            }
//            else
//            {
//                m[j, i] = 0;
//            }

//            for (int k = i + 1; k < N + 1; k++)
//            {
//                a[j, k] = a[j, k] + m[j, i] * a[i, k];
//            }
//        }
//    }
//}



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


