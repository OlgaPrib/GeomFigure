using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    // класс окружность
     public class Okr : IGeomFig
    {
        double[] par; // параметры фигуры. считанные из файла

        public Okr(string[] param)
        {
            par = new double[3];
            for (int i = 0; i < 3; i++)
            {
                par[i] = Convert.ToDouble(param[i]);
            }
        }
        public double this[int i]
        {
            set { par[i] = value; }
            get { return par[i]; }
        }


        //периметр окружности
        public double perimetr
        {
            get { return  2 * Math.PI * par[2]; }
        }

        // площадь окружности
        public double ploshad
        {
            get { return Math.PI * par[2] * par[2]; }
        }

        public void Vyvod(int i)
        {
            Console.WriteLine(i + " КРУГ " + " P= " + perimetr + " S= " + ploshad);
        }
    }
}
