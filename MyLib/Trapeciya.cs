using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
     public class Trapeciya : IGeomFig
    {
        double[] par; // параметры фигуры. считанные из файла

        public Trapeciya(string[] param)
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

        // проверка , что фигура является трапецией m1*p2 = p1*m2 (параллельны)
        public static bool proverka(string[] param)
        {
            int bm1 = Convert.ToInt32(param[4]) - Convert.ToInt32(param[2]);
            int bm2 = Convert.ToInt32(param[0]) - Convert.ToInt32(param[6]);
            int bp1 = Convert.ToInt32(param[5]) - Convert.ToInt32(param[3]);
            int bp2 = Convert.ToInt32(param[1]) - Convert.ToInt32(param[7]);

            int om1 = Convert.ToInt32(param[2]) - Convert.ToInt32(param[0]);
            int om2 = Convert.ToInt32(param[4]) - Convert.ToInt32(param[6]);
            int op1 = Convert.ToInt32(param[3]) - Convert.ToInt32(param[1]);
            int op2 = Convert.ToInt32(param[5]) - Convert.ToInt32(param[7]);

            if (bm1*bp2 != bp1*bm2 && om1*op2 == op1*om2 )
                return true; // это трапеция
            else return false;

            /*if ((Convert.ToInt32(param[1]) == Convert.ToInt32(param[3]) && Convert.ToInt32(param[5]) == Convert.ToInt32(param[7])) || 
                (Convert.ToInt32(param[0]) == Convert.ToInt32(param[2]) && Convert.ToInt32(param[4]) == Convert.ToInt32(param[6]))) // две стороны параллельны
                return true; // это трапеция
            else return false;*/
        }

        //периметр трапеции P = a + b + c + d
        public double perimetr
        {
            get { return dlina(Convert.ToString(par[0]), Convert.ToString(par[1]), Convert.ToString(par[2]), Convert.ToString(par[3])) + 
                         dlina(Convert.ToString(par[2]), Convert.ToString(par[3]), Convert.ToString(par[4]), Convert.ToString(par[5])) +
                         dlina(Convert.ToString(par[4]), Convert.ToString(par[5]), Convert.ToString(par[6]), Convert.ToString(par[7])) + 
                         dlina(Convert.ToString(par[6]), Convert.ToString(par[7]), Convert.ToString(par[0]), Convert.ToString(par[1])); }
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
