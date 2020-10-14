using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeomFigure
{
     public  class Kvadrat : IGeomFig // класс Квадрат
    {
        double[] par; // параметры фигуры. считанные из файла

        public Kvadrat(string[] param)
        {
            par = new double[8];
            for (int i = 0; i < 8; i ++)
            {
                par[i] = Convert.ToDouble(param[i]);
            }
        }
        public double this[int i] 
        {             
            set { par[i] = value; }
            get { return par[i]; } 
        }

        // длина стороны квадрата
        static double dlina(string x1, string y1, string x2, string y2)
        {
            return Math.Pow(Math.Pow(Convert.ToDouble(x2) - Convert.ToDouble(x1), 2) + Math.Pow(Convert.ToDouble(y2) - Convert.ToDouble(y1), 2), 0.5);
        }

        //периметр квадрата
        public double perimetr 
        {
            get { return dlina(Convert.ToString(par[0]), Convert.ToString(par[1]), Convert.ToString(par[2]), Convert.ToString(par[3])) * 4; } 
        }

        // площадь квадрата
        public double ploshad 
        {
            get { return Math.Pow(dlina(Convert.ToString(par[0]), Convert.ToString(par[1]), Convert.ToString(par[2]), Convert.ToString(par[3])), 2); }
        }

        public void Vyvod(int i)
        {
            Console.WriteLine(i + " КВАДРАТ " + " P= " + perimetr + " S= " + ploshad);
        }

        // проверка на равенство сторон 
        public static bool proverka (string[] param)
        {
            if (dlina(param[0], param[1], param[6], param[7]) == dlina(param[2], param[3], param[4], param[5]) &&
                dlina(param[0], param[1], param[4], param[5]) == dlina(param[0], param[1], param[2], param[3]))
                return true; // это квадрат
            else return false;
        }
    }
}
