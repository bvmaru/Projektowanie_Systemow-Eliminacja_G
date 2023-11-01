using Eliminacja_G;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Diagnostics;


int sampleGroup = 1;
Stopwatch timer = new Stopwatch();
GaussElimination gauss = new GaussElimination();
Random random = new Random();
double[] timeTable = new double[sampleGroup];
//List<double> timeTable = new List<double>(); // this solution is slower

int N = 4;
gauss.nSize = N;



for (int i = 0; i < sampleGroup; i++) // measuring time for the declared group
{
    //gauss.aMatrix = Matrix<double>.Build.Random(N, N + 1).Multiply(random.Next(1, 100)); //floating point data
    gauss.aMatrix = Matrix<double>.Build.Dense(N, N + 1, (i, j) => random.Next(-100, 100) - i + j); // integer data
    gauss.mMatrix = Matrix<double>.Build.Dense(N, N - 1);
    timer.Restart();
    gauss.Calculate();
    timeTable[i] = timer.Elapsed.TotalMilliseconds;
    //timeTable.Add(timer.Elapsed.TotalMilliseconds); //this solution is slower
    timer.Stop();
}

Console.WriteLine($"Time measurements for the N = {N}:");
for (int i = 0; i < sampleGroup; i++) Console.WriteLine($"{i + 1}) {timeTable[i]} ms");
Console.WriteLine($"Average time: {timeTable.Average()} ms\n");



//-------------------- testing area----------------------------------------------------------------------------------------------------------------------

//gauss.aMatrix = DenseMatrix.OfArray(new double[,]
//{
//    {2, -2, -2, -2},
//    {-1, 3, 4, 4},
//    {5, 2, 3, 8}
//});
//gauss.mMatrix = Matrix<double>.Build.Dense(3, 3);

//gauss.Calculate();

//Console.WriteLine(gauss.aMatrix);

//gauss.aMatrix = DenseMatrix.OfArray(new double[,]
//{
//    {2, -2, -2, -2},
//    {-1, 3, 4, 4},
//    {5, 2, 3, 8}
//});
//gauss.mMatrix = Matrix<double>.Build.Dense(3, 3);

gauss.ColectGraphData();
//Console.WriteLine(gauss.nest2.W1.ToArray().ToString());
Console.WriteLine(gauss.aMatrix);


//gauss.aMatrix = DenseMatrix.OfArray(new double[,]
//{
//    {2, -2, -2, -2},
//    {-1, 3, 4, 4},
//    {5, 2, 3, 8}
//});
//gauss.mMatrix = Matrix<double>.Build.Dense(3, 3);



