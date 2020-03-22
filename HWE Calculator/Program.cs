using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaitlinsDissShit
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("HWE Calculator V1.0\n");
            List<String> DataString = File.ReadAllLines("Data.txt").ToList();
            List<Decimal> Data = new List<Decimal>();
            List<Decimal> DataOutput = new List<Decimal>();
            List<Decimal> Q2Values = new List<Decimal>();
            List<Decimal> P2Values = new List<Decimal>();
            List<Decimal> TwoPQValues = new List<Decimal>();
            Decimal OutputMean = 0;
            Decimal QMean = 0;
            int DataCount = DataString.Count;
            foreach (String DP in DataString)
            {
                Data.Add(Convert.ToDecimal(DP));
            }
            foreach (Decimal DP in Data)
            {
                Decimal P = 1 - DP;
                Decimal Q = DP;
                Decimal P2 = P * P;
                P2Values.Add(P2);
                Decimal Q2 = Q * Q;
                Q2Values.Add(Q2);
                Decimal X = 2 * P * Q;
                TwoPQValues.Add(X);
                Decimal Output = P2 + Q2 + X;
                DataOutput.Add(Output);
                Console.WriteLine("(1 - " + Q + ")\u00b2 + " + Q + "\u00b2 + (2 * " + P + " * " + Q + ") = " + Output);
            }
            foreach (Decimal DP in DataOutput)
            {
                OutputMean += DP;
            }
            foreach (Decimal DP in Data)
            {
                QMean += DP;
            }
            using (var file = new StreamWriter("P^2 Values.txt"))
            {
                P2Values.ForEach(v => file.WriteLine(v));
            }
            using (var file = new StreamWriter("Q^2 Values.txt"))
            {
                Q2Values.ForEach(v => file.WriteLine(v));
            }
            using (var file = new StreamWriter("2PQ Values.txt"))
            {
                TwoPQValues.ForEach(v => file.WriteLine(v));
            }
            OutputMean /= DataCount;
            QMean /= DataCount;
            Decimal MeanOutput = ((1 - QMean) * (1 - QMean)) + (QMean * QMean) + (2 * QMean * (1 - QMean));
            File.WriteAllText("QMean Value.txt", Convert.ToString(QMean));
            Console.WriteLine("\nFormula Output Mean: " + OutputMean);
            Console.WriteLine("Data 'Q' Mean: " + QMean);
            Console.WriteLine("Formula Output using 'Q' Mean: ");
            Console.WriteLine("\n" + (1 - QMean) + "\u00b2 + " + QMean + "\u00b2 + (2 * " + (1 - QMean) + " * " + QMean + ") = " + MeanOutput);
            Console.WriteLine("\n\\/   \\/   \\/  \\/   \\/  \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/   \\/\n");
            Console.WriteLine(((1 - QMean) * (1 - QMean)) + " + " + (QMean * QMean) + " + " + (2 * (1 - QMean) * QMean) + " = " + MeanOutput);
            Console.WriteLine("\nIf this is missing anything throw something at the developer, preferably heavy so he notices!");
            Console.ReadLine();
        }
    }
}
