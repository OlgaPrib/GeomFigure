using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
     public class Trap : IGeomFig
    {
        double[] par; // параметры фигуры. считанные из файла

        public Trap(string[] param)
        {
            par = new double[8];
            for (int i = 0; i < 8; i++)
            {
                par[i] = Convert.ToDouble(param[i]);
            }
        }
        public double this[int i]
        {
            set { par[i] = value; }
            get { return par[i]; }
        }

        // длина стороны трапеции (основания) или высота
        static double dlina(string x1, string y1, string x2, string y2)
        {
            return Math.Sqrt(Math.Pow(Convert.ToDouble(x2) - Convert.ToDouble(x1), 2) + Math.Pow(Convert.ToDouble(y2) - Convert.ToDouble(y1), 2));
        }
       
        //периметр трапеции P = a + b + c + d
        public double perimetr
        {
            get { return dlina(Convert.ToString(par[0]), Convert.ToString(par[1]), Convert.ToString(par[2]), Convert.ToString(par[3])) + dlina(Convert.ToString(par[4]), Convert.ToString(par[5]), Convert.ToString(par[6]), Convert.ToString(par[7])) + dlina(Convert.ToString(par[4]), Convert.ToString(par[5]), Convert.ToString(par[0]), Convert.ToString(par[1])) + dlina(Convert.ToString(par[2]), Convert.ToString(par[3]), Convert.ToString(par[6]), Convert.ToString(par[7])); }
        }

        // площадь трапеции
        public double ploshad
        {
            get { return (dlina(Convert.ToString(par[0]), Convert.ToString(par[1]), Convert.ToString(par[2]), Convert.ToString(par[3])) + dlina(Convert.ToString(par[4]), Convert.ToString(par[5]), Convert.ToString(par[6]), Convert.ToString(par[7]))) / 2 * dlina(Convert.ToString(par[0]), Convert.ToString(par[1]), Convert.ToString(par[5]), Convert.ToString(par[5])); }
        }

        public void Vyvod(int i)
        {
            Console.WriteLine(i + " ТРАПЕЦИЯ " + " P= " + perimetr + " S= " + ploshad);
        }
    }
}
