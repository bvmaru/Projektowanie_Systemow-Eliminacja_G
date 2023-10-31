using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliminacja_G
{
    public class GaussElimination
    {
        public Matrix<double> aMatrix { get; set; }
        public Matrix<double> mMatrix { get; set; }
        public int nSize { get; set; }


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

                    for (int k = i + 1; k < nSize + 1; k++)
                    {
                        aMatrix[j, k] = aMatrix[j, k] + mMatrix[j, i] * aMatrix[i, k];
                    }
                }
            }
        }
    }
}
