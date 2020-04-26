using System;
using System.Text;

namespace Matrix
{
    class Matrix{
        private double[,] _val;
        private readonly double epsilon;
        public double this[Int32 i,Int32 j]
        {
            get{
                return _val[i,j];
            }
            set{
                _val[i,j]=value;
            }
        }
        public int strs{
            get{
                return _val.GetLength(0);
            }
        }
        public int cols{
            get{
                return _val.GetLength(1);
            }
        }
        public Matrix(double[,] ar, double eps)
        {
            _val=new double[ar.GetLength(0),ar.GetLength(1)];
            for(int i=0;i<ar.GetLength(0);i++)
            for(int j=0;j<ar.GetLength(0);j++)
            {
                _val[i,j]=ar[i,j];
            }
            epsilon=eps;
        }
        public double[,] Transp()
        {
            double[,] res=new double[cols,strs];
            for(int i=0;i<cols;i++)
                for(int j=0;j<strs;j++)
                    res[j,i]=_val[i,j];
            return res;
        }

        private void SwapStrs(double[,] ar,int i, int j)
        {
            for(int k=0;k<cols;k++)
            {
                ar[i,k]+=ar[j,k];
                ar[j,k]=ar[i,k]-ar[j,k];
                ar[i,k]-=ar[j,k];
            }
        }
        public Matrix GetDiagMatr(out double mnoj)
        {
            mnoj=1;
            double[,] res=new double[strs,cols];
            for(int i=0;i<strs;i++)
                for(int j=0;j<cols;j++)
                    res[i,j]=_val[i,j];
            for(int i=0;i<strs;i++)
            {
                if(Math.Abs(res[i,i])<epsilon)
                {
                    for(int j=0;j<strs;j++)
                    if(Math.Abs(res[j,i])>epsilon)
                    {
                        SwapStrs(res,i,j);
                        mnoj*=-1;
                    }
                }
                for(int j=0;j<strs;j++)
                {
                    if(j==i || res[i,i]==0)
                    continue;
                    double temp=res[j,i];
                    for(int k=0;k<cols;k++)
                    {
                        res[j,k]-=res[i,k]/res[i,i]*temp;
                    }
                    System.Console.WriteLine(Environment.NewLine);
                    for(int r=0;r<strs;r++)
                    {
                        for(int c=0;c<cols;c++)
                            System.Console.Write(res[r,c]+" ");
                        System.Console.WriteLine("\n");
                    }
                }                
            }
            return new Matrix(res,epsilon);
        }
        public double GetDet()
        {
            double res=1;
            Matrix diag=GetDiagMatr(out double mnoj);
            for(int i=0;i<strs;i++)
            res*=diag[i,i];
            return res*mnoj;            
        }
        public double[,] GetRevMatr()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder s=new StringBuilder();
            for(int i=0;i<strs;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    s.Append(_val[i,j].ToString());
                    s.Append("\t");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}