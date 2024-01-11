using MathNet.Numerics.LinearAlgebra;
using OfficeOpenXml;

namespace Eliminacja_G
{
    public class GaussElimination
    {
        public Matrix<double> aMatrix { get; set; }
        public Matrix<double> mMatrix { get; set; }
        public Matrix<int> dataMatrix { get; set; }
        public int nSize { get; set; }
        public List<LoopNest> nest1 { get; set; }
        public List<LoopNest> nest2 { get; set; }
        public List<LoopNest> nest3 { get; set; }
        List<ValueTuple<int, int, string>> ArcsList = new List<ValueTuple<int, int, string>>();


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

                    for (int k = i + 1; k < nSize + 1; k++) // (int k = i; k < nSize + 1; k++) to clear the lower triangle|| k=i+1 to leave it filled with numbers
                    {
                        aMatrix[j, k] = aMatrix[j, k] + mMatrix[j, i] * aMatrix[i, k];
                    }
                }
            }
        }

        public void CollectGraphData()
        {
            nest1 = new List<LoopNest>();
            nest2 = new List<LoopNest>();
            nest3 = new List<LoopNest>();
            //LoopNest temp = new LoopNest();
            int nr1 = 0;
            int nr2 = 0;
            string ne1 = "";
            string ne2 = "";
            string ne3 = "";
            for (int i1 = 0; i1 < nSize - 1; i1++)
            {
                for (int i2 = i1 + 1; i2 < nSize; i2++)
                {
                    for (int i3 = i1; i3 < i1+1; i3++)
                    {
                        if (aMatrix[i1, i1] != 0)
                        {
                            LoopNest temp = new LoopNest();
                            mMatrix[i2, i1] = -aMatrix[i2, i1] / aMatrix[i1, i1];
                            temp.nr = (i1 + 1) * 100 + (i2 + 1) * 10 + (i3 + 1);
                            temp.W1 = (i1 + 1); //1 is being added so we can compare it with the presentation, we might mot need it later in the project 
                            temp.W2 = (i2 + 1);
                            temp.W3 = (i3 + 1);
                            temp.Ia11 = (i1 + 1, i1 + 1);
                            temp.Ia21 = (i2 + 1, i1 + 1);
                            temp.Ia13 = (0, 0);
                            temp.Ia23 = (0, 0);
                            temp.Im = (i2 + 1, i1 + 1);
                            temp.Operation = "-/";
                            nr2++;
                            ne2 += $"{temp.nr} | {i1 + 1} | {i2 + 1} | {i3 + 1} | {i2 + 1} {i1 + 1}| {i1 + 1} {i1 + 1} | {i2 + 1} {i1 + 1} | -/ |\n";
                            nest1.Add(temp);
                        }
                        else
                        {
                            LoopNest temp = new LoopNest();
                            mMatrix[i2, i1] = 0;
                            temp.nr = (i1+1) * 100 + (i2+1) * 10 + (i3+1);
                            temp.W1 = (i1 + 1); //1 is being added so we can compare it with the presentation, we might mot need it later in the project 
                            temp.W2 = (i2 + 1);
                            temp.W3 = (i3 + 1);
                            temp.Ia11 = (i1 + 1, i1 + 1);
                            temp.Ia21 = (i2 + 1, i1 + 1);
                            temp.Ia13 = (0, 0);
                            temp.Ia23 = (0, 0);
                            temp.Im = (i2 + 1, i1 + 1);
                            temp.Operation = "-/";
                            nr2++;
                            //Console.WriteLine($"{nr2} | {i1 + 1} | {i2 + 1} | {i3 + 1} | {i2 + 1} {i3 + 1}| {i1 + 1} {i3 + 1} | {i2 + 1} {i1 + 1} | ");
                            ne2 += $"{temp.nr} | {i1 + 1} | {i2 + 1} | {i3 + 1} | {i2 + 1} {i1 + 1}| {i1 + 1} {i1 + 1} | {i2 + 1} {i1 + 1} | -/ |\n";
                            nest1.Add(temp);
                        }
                    }
                    for (int i3 = i1 + 1; i3 < nSize +1; i3++) //why the nSize parameter has to be smaller compared to the one in working algorithm??? do we just ignore the B vector?
                    {
                        LoopNest temp = new LoopNest();
                        aMatrix[i2, i3] = aMatrix[i2, i3] + mMatrix[i2, i1] * aMatrix[i1, i3];
                        nr1++;
                        temp.nr = (i1 + 1) * 100 + (i2 + 1) * 10 + (i3 + 1);
                        temp.W1 = (i1 + 1); //1 is being added so we can compare it with the presentation, we might mot need it later in the project 
                        temp.W2 = (i2 + 1);
                        temp.W3 = (i3 + 1);
                        temp.Ia13 = ((i1 + 1, i3 + 1));
                        temp.Ia23 = ((i2 + 1, i3 + 1));
                        temp.Ia11 = ((0, 0));
                        temp.Ia21 = ((0, 0));
                        temp.Im = ((i2 + 1, i1 + 1));
                        temp.Operation = "+*";
                        ne1 += $"{temp.nr} | {i1 + 1} | {i2 + 1} | {i3 + 1} | {i2 + 1} {i1 + 1}| {i1 + 1} {i3 + 1} | {i2 + 1} {i3 + 1} | +* |\n";
                        //Console.WriteLine($"{nr1} | {i1 + 1} | {i2 + 1} | {i3 + 1} | {i2 + 1} {i1 + 1}| {i1 + 1} {i3 + 1} | {i2 + 1} {i3 + 1} | ");
                        nest2.Add(temp);
                    }
                }
            }
            File.WriteAllText("D:\\Nest\\Nest1.txt", ne1);
            File.WriteAllText("D:\\Nest\\Nest2.txt", ne2);
            while (nest1.Any() || nest2.Any())
            {
                if (nest1.Any())
                {
                    if (nest1[0].nr < nest2[0].nr)
                    {
                        nest3.Add(nest1[0]);
                        nest1.Remove(nest1[0]);
                    }
                    else
                    {
                        nest3.Add(nest2[0]);
                        nest2.Remove(nest2[0]);
                    }
                }
                else
                {
                    nest3.Add(nest2[0]);
                    nest2.Remove(nest2[0]);
                }
            }
            ne3 += $"Nr | W1 | W2 | W3 | Im | Ia11 | Ia13 | Ia21 | Ia23 |\n";
            for (int i = 0; i < nest3.Count; i++)
            {
                //ne3 += $"{i+1} | {nest3[i].W1} | {nest3[i].W2} | {nest3[i].W3} |\n";
                if(i>=9)
                    ne3 += $"{i + 1} | {nest3[i].W1} | {nest3[i].W2} | {nest3[i].W3} | {nest3[i].Im}| {nest3[i].Ia11} | {nest3[i].Ia13} | {nest3[i].Ia21} | {nest3[i].Ia23} | {nest3[i].Operation} |\n";
                else
                    ne3 += $"0{i + 1} | {nest3[i].W1} | {nest3[i].W2} | {nest3[i].W3} | {nest3[i].Im}| {nest3[i].Ia11} | {nest3[i].Ia13} | {nest3[i].Ia21} | {nest3[i].Ia23} | {nest3[i].Operation} |\n";
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the Excel package
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                // Populate some data in the worksheet
                worksheet.Cells["A1"].Value = "Nr";
                worksheet.Cells["B1"].Value = "W1";
                worksheet.Cells["C1"].Value = "W2";
                worksheet.Cells["D1"].Value = "W3";
                worksheet.Cells["E1"].Value = "Im";
                worksheet.Cells["F1"].Value = "Ia11";
                worksheet.Cells["G1"].Value = "Ia13";
                worksheet.Cells["H1"].Value = "Ia21";
                worksheet.Cells["I1"].Value = "Ia23";
                worksheet.Cells["J1"].Value = "Operation";

                for (int i = 0; i < nest3.Count; i++)
                {
                    worksheet.Cells[$"A{i + 2}"].Value = $"{i + 1}";
                    worksheet.Cells[$"B{i + 2}"].Value = $"{nest3[i].W1}";
                    worksheet.Cells[$"C{i + 2}"].Value = $"{nest3[i].W2}";
                    worksheet.Cells[$"D{i + 2}"].Value = $"{nest3[i].W3}";
                    worksheet.Cells[$"E{i + 2}"].Value = $"{nest3[i].Im}";
                    worksheet.Cells[$"F{i + 2}"].Value = $"{nest3[i].Ia11}";
                    worksheet.Cells[$"G{i + 2}"].Value = $"{nest3[i].Ia13}";
                    worksheet.Cells[$"H{i + 2}"].Value = $"{nest3[i].Ia21}";
                    worksheet.Cells[$"I{i + 2}"].Value = $"{nest3[i].Ia23}";
                    worksheet.Cells[$"J{i + 2}"].Value = nest3[i].Operation;

                    //ne3 += $"{i+1} | {nest3[i].W1} | {nest3[i].W2} | {nest3[i].W3} |\n";
                    //ne3 += $"{i + 1} | {nest3[i].W1} | {nest3[i].W2} | {nest3[i].W3} | {nest3[i].Im}| {nest3[i].Ia11} | {nest3[i].Ia13} | {nest3[i].Ia21} | {nest3[i].Ia23} |\n";
                }

                // Save the Excel package to a file
                var excelFile = new FileInfo("D:\\Nest\\Nest3.xlsx");
                package.SaveAs(excelFile);
            }

            File.WriteAllText("D:\\Nest\\Nest3.txt", ne3);
        }
        public void graphArcs()
        {
            List<ValueTuple<int, int, string>> ArcsListInternal = new List<ValueTuple<int, int, string>>();

            for (int i = 0; i < nest3.Count; i++) // horizontal arcs
            {
                for(int j = i+1; j<nest3.Count; j++)
                {
                    if (nest3[i].Im == nest3[j].Im)
                    {
                        ArcsListInternal.Add(new ValueTuple<int, int, string>(nest3[i].W1*100 + nest3[i].W2 * 10 + nest3[i].W3, nest3[j].W1 * 100 + nest3[j].W2 * 10 + nest3[j].W3, "->"));
                        break;
                    }
                }
            }

            for (int i = 0; i < nest3.Count; i++) // horizontal arcs part2
            {
                for (int j = i + 1; j < nest3.Count; j++)
                {
                    if ((nest3[i].Ia11 == nest3[j].Ia11 && nest3[i].Ia11 != (0,0) || nest3[i].Ia13 == nest3[j].Ia13 && nest3[i].Ia13 != (0, 0)))
                    {
                        ArcsListInternal.Add(new ValueTuple<int, int, string>(nest3[i].W1 * 100 + nest3[i].W2 * 10 + nest3[i].W3, nest3[j].W1 * 100 + nest3[j].W2 * 10 + nest3[j].W3, "-^"));
                        break;
                    }
                }
            }

            for (int i = 0; i < nest3.Count; i++) // vertical arcs
            {
                for (int j = i + 1; j < nest3.Count; j++)
                {
                    if (nest3[i].Ia23!=(0,0) && (nest3[i].Ia23 == nest3[j].Ia21 || nest3[i].Ia23 == nest3[j].Ia23))
                    {
                        ArcsListInternal.Add(new ValueTuple<int, int, string>(nest3[i].W1 * 100 + nest3[i].W2 * 10 + nest3[i].W3, nest3[j].W1 * 100 + nest3[j].W2 * 10 + nest3[j].W3, "|"));
                        break;
                    }
                }
            }

            for (int i = 0; i < nest3.Count; i++) // oblique arcs
            {
                for (int j = i + 1; j < nest3.Count; j++)
                {
                    if (nest3[i].Ia23 != (0, 0) && (nest3[i].Ia23 == nest3[j].Ia11 || nest3[i].Ia23 == nest3[j].Ia13))
                    {   
                        int count = 0;
                        for(int k = i; k<nest3.Count; k++)
                        {
                            if (nest3[i].Ia23 == nest3[k].Ia23) count++;
                        }
                        if(count > 1) break;
                        ArcsListInternal.Add(new ValueTuple<int, int, string>(nest3[i].W1 * 100 + nest3[i].W2 * 10 + nest3[i].W3, nest3[j].W1 * 100 + nest3[j].W2 * 10 + nest3[j].W3, "/"));
                        break;
                    }
                }
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the Excel package
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                // Populate some data in the worksheet
                worksheet.Cells["A1"].Value = "From";
                worksheet.Cells["B1"].Value = "To";
                worksheet.Cells["C1"].Value = "Direction";

                for (int i = 0; i < ArcsListInternal.Count; i++)
                {
                    worksheet.Cells[$"A{i + 2}"].Value = $"{ArcsListInternal[i].Item1}";
                    worksheet.Cells[$"B{i + 2}"].Value = $"{ArcsListInternal[i].Item2}";
                    worksheet.Cells[$"C{i + 2}"].Value = $"{ArcsListInternal[i].Item3}";

                    //ne3 += $"{i+1} | {nest3[i].W1} | {nest3[i].W2} | {nest3[i].W3} |\n";
                    //ne3 += $"{i + 1} | {nest3[i].W1} | {nest3[i].W2} | {nest3[i].W3} | {nest3[i].Im}| {nest3[i].Ia11} | {nest3[i].Ia13} | {nest3[i].Ia21} | {nest3[i].Ia23} |\n";
                }

                // Save the Excel package to a file
                var excelFile = new FileInfo("D:\\Nest\\arcs.xlsx");
                package.SaveAs(excelFile);
            }

            ArcsList = ArcsListInternal;

        }

        public void architectureCreator(List<int[]> fs)
        {

            HashSet<(int,int)> processors = new HashSet<(int, int)>();

            List<ValueTuple<LoopNest, (int, int), int>> operations = new List<(LoopNest, (int, int), int)>();


            foreach (var nest in nest3)
            {
                (int, int) number = (0, 0);
                number.Item1 = fs[0][0] * nest.W1 + fs[0][1] * nest.W2 + fs[0][2] * nest.W3;

                if(fs.Count==2)
                    number.Item2 = fs[1][0] * nest.W1 + fs[1][1] * nest.W2 + fs[1][2] * nest.W3;



                ValueTuple<LoopNest, (int, int), int> record = (nest, number, nest.W1 + nest.W2 + nest.W3);

                operations.Add(record);
                processors.Add(number);
            }

            foreach(var processor in processors)
            {
            }

            var a = 0;
        }
    }
}
