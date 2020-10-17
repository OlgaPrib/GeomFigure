using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
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
            if (dlina(param[0], param[1], param[2], param[3]) == dlina(param[2], param[3], param[4], param[5]) &&
                dlina(param[4], param[5], param[6], param[7]) == dlina(param[6], param[7], param[0], param[1]) && 
                dlina(param[0], param[1], param[2], param[3])!= 0 &&
                ugol(param)) // все стороны равны и не равны 0
                return true; // это квадрат
            else return false;
        }

        public static bool ugol(string[] param)
        {
            double ABx = Convert.ToDouble(param[0]) - Convert.ToDouble(param[2]);
            double ABy = Convert.ToDouble(param[1]) - Convert.ToDouble(param[3]);
            double BCx = Convert.ToDouble(param[4]) - Convert.ToDouble(param[2]);
            double BCy = Convert.ToDouble(param[5]) - Convert.ToDouble(param[3]);
            double scalar = ABx * BCx + ABy * BCy; //скалярное произведение (АВ,ВС)
            double modAB = Math.Sqrt(Math.Pow(ABx, 2) + Math.Pow(ABy, 2)); //длина АВ по теореме Пифагора
            double modBC = Math.Sqrt(Math.Pow(BCx, 2) + Math.Pow(BCy, 2)); // длина ВС по теореме Пифагора
            double cosAlpha = scalar / (modAB * modBC);

            if (cosAlpha == 0)
                return true;
            else return false;
        }
    }
}
