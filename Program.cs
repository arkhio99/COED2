using System;
using M=Matrix;
namespace COED2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] ar=new double[3,3]{
                {1,2,3},
                {4,5,6},
                {7,8,10}
            };
            M.Matrix m=new M.Matrix(ar,0.001);
            System.Console.WriteLine(m.GetDiagMatr(out double mnoj).ToString());
        }
    }
}
