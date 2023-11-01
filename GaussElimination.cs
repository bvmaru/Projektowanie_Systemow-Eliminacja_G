using MathNet.Numerics.LinearAlgebra;

namespace Eliminacja_G
{
    public class GaussElimination
    {
        public Matrix<double> aMatrix { get; set; }
        public Matrix<double> mMatrix { get; set; }
        public Matrix<int> dataMatrix { get; set; }
        public int nSize { get; set; }
        public LoopNest nest1 { get; set; }
        public LoopNest nest2 { get; set; }


        public void Calculate()
        {
            for (int i = 0; i < nSize - 1; i++)
            {
                for (int j = i + 1; j < nSize; j++)
                {
                    if (aMatrix[i, i] != 0)
                    {
                        mMatrix[j, i] = -aMatrix[j, i] / aMatrix[i, i];
                    }
                    else
                    {
                        mMatrix[j, i] = 0;
                    }

                    for (int k = i + 1; k < nSize + 1; k++) // (int k = i; k < nSize + 1; k++) to clear the lower triangle 
                    {
                        aMatrix[j, k] = aMatrix[j, k] + mMatrix[j, i] * aMatrix[i, k];
                    }
                }
            }
        }

        public void CollectGraphData()
        {
            nest1 = new LoopNest();
            nest2 = new LoopNest();
            int nr = 0;
            for (int i1 = 0; i1 < nSize - 1; i1++)
            {
                for (int i2 = i1 + 1; i2 < nSize; i2++)
                {
                    for (int i3 = i1; i3 < i1+1; i3++)
                    {
                        if (aMatrix[i1, i1] != 0)
                        {
                            mMatrix[i2, i1] = -aMatrix[i2, i1] / aMatrix[i1, i1];
                            nest1.W1.Add(i1 + 1); //1 is being added so we can compare it with the presentation, we might mot need it later in the project 
                            nest1.W2.Add(i2 + 1);
                            nest1.W3.Add(i3 + 1);
                            nest1.Ia1.Add((i2 + 1, i3 + 1));
                            nest1.Ia2.Add((i1 + 1, i3 + 1));
                            nest1.Im.Add((i2 + 1, i1 + 1));
                        }
                        else
                        {
                            mMatrix[i2, i1] = 0;
                            nest1.W1.Add(i1 + 1); //1 is being added so we can compare it with the presentation, we might mot need it later in the project 
                            nest1.W2.Add(i2 + 1);
                            nest1.W3.Add(i3 + 1);
                            nest1.Ia1.Add((i2 + 1, i3 + 1));
                            nest1.Ia2.Add((i1 + 1, i3 + 1));
                            nest1.Im.Add((i2 + 1, i1 + 1));
                        }
                    }
                    for (int i3 = i1 + 1; i3 < nSize; i3++) //why the nSize parameter has to be smaller compared to the working algorithm??? do we just ignore the B vector?
                    {
                        aMatrix[i2, i3] = aMatrix[i2, i3] + mMatrix[i2, i1] * aMatrix[i1, i3];
                        nr++;
                        nest2.nr.Add(nr);
                        nest2.W1.Add(i1 + 1); //1 is being added so we can compare it with the presentation, we might mot need it later in the project 
                        nest2.W2.Add(i2 + 1);
                        nest2.W3.Add(i3 + 1);
                        nest2.Ia1.Add((i2 + 1, i3 + 1));
                        nest2.Ia2.Add((i1 + 1, i3 + 1));
                        nest2.Im.Add((i2 + 1, i1 + 1));
                    }
                }
            }
        }
    }
}
