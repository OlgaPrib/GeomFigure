using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyLib;

namespace GeomFigure
{
     public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int countKv = 0;
                double perKv = 0;
                int countOkr = 0;
                double perOkr = 0;
                int countTr = 0;
                double perTr = 0;
                double pr = 0;
                double sq = 0;
                int j = 0;
                int flag = 0;
                string[] stroki; //массив строк из файла
                string[] paramFig; //строка с параметрами фигуры
                IGeomFig[] figures = null; //массив объектов
                StreamReader reader = new StreamReader(@"1.txt");
                string s = reader.ReadToEnd(); // читаем строку до конца
                reader.Close();

                //проверяем файл на наличие строк
                if (s.Length == 0)
                    Console.WriteLine("Файл не содержит строк!");
                else
                {
                    Console.Clear();
                    Console.WriteLine("Строка:\n" + s);

                    stroki = s.Split('\n');
                    figures = new IGeomFig[stroki.Length];

                    //заполняем массив объектов
                    for (int i = 0; i < stroki.Length; i++)
                    {
                        paramFig = stroki[i].Split(' ');
                        if (paramFig.Length == 3)
                        {
                            if (Convert.ToDouble(paramFig[2]) > 0)
                            {
                                figures[j] = new Okr(paramFig);
                                pr = pr + figures[j].perimetr;
                                sq = sq + figures[j].ploshad;
                                countOkr++;
                                perOkr = perOkr + figures[j].perimetr;
                                j++;
                            }
                            else
                                Console.WriteLine("В строке " + (i + 1) + " круг имеет отрицательный радиус, объект не может быть создан!");
                        }
                        else
                            if (paramFig.Length == 8)
                        {
                            if (Kvadrat.proverka(paramFig))
                            {
                                figures[j] = new Kvadrat(paramFig);
                                pr = pr + figures[j].perimetr;
                                sq = sq + figures[j].ploshad;
                                countKv++;
                                perKv = perKv + figures[j].perimetr;
                                j++;
                            }
                            else
                            {
                                figures[j] = new Trap(paramFig);
                                pr = pr + figures[j].perimetr;
                                sq = sq + figures[j].ploshad;
                                countTr++;
                                perTr = perTr + figures[j].perimetr;
                                j++;
                            }
                        }
                        else
                            Console.WriteLine("В строке " + (i + 1) + " возможно неправильно введены параметры!");
                    }
                }

                //среднее значние периметра 
               /* string typeFig = "";
                if (countKv != 0)
                {
                    typeFig = "Квадрат";
                    double srednKv = perKv / countKv;
                }
                if (countOkr != 0)
                {
                    typeFig = "Окружность";
                    double srednOkr = perOkr / countOkr;
                }
                if (countTr != 0)
                {
                    typeFig = "Трапеция";
                    double srednTr = perTr / countTr;
                }*/

               

                Array.Resize(ref figures, j);
                if(j > 0)
                {
                    //вывод исходного массива
                    Console.WriteLine("\n\n Полученный массив\n");
                    for (int i=0; i< j; i++)
                    {
                        figures[i].Vyvod(i + 1);
                    }
                    //сортировка массива по площади
                    Array.Sort(figures, new SravPoPloshadi());
                    // Вывод отсортированного массива
                    
                    Console.WriteLine("\n\n Массив, отсортированный по площади \n");
                    for (int i = 0; i < j; i++)
                    {
                        figures[i].Vyvod(i + 1);
                    }

                    int maxValue = figures.Length - 1;
                    Console.WriteLine("\n\n Фигура, с наибольшей площадью \n");
                    figures[maxValue].Vyvod(maxValue + 1);

                    // сортировка массива в порядке убывания периметра
                    Array.Sort(figures, new SravPoPerimetru());
                    Console.WriteLine("\n\n Массив, отсортированный по периметру \n");
                    for (int i = 0; i < j; i++)
                    {
                        figures[i].Vyvod(i + 1);
                    }


                   
                    Console.WriteLine("\n\n Массив, отсортированный по названию \n");
                    for (int i = 0; i < j; i++)
                    {
                        figures[i].Vyvod(i + 1);
                    }
                }
                else
                    Console.WriteLine("Элементы отсутствуют");

                Console.WriteLine("Средний периметр всех фигур = " + pr/j);
                Console.WriteLine("Средняя площадь всех фигур = " + sq / j);

                for (int i = 0; i < j; i ++)
                {
                    if(figures[i] is Kvadrat)
                    {

                    }
                }

                Console.ReadKey();
            }
            catch(FileNotFoundException) { Console.WriteLine("Ошибка открытия файла "); }
            catch (IndexOutOfRangeException) { Console.WriteLine("В массиве отсутствуют элементы "); }
            catch (OverflowException) { Console.WriteLine("Данные введены неверно "); }
            catch (FormatException) { Console.WriteLine("Данные введены неверно "); }
            catch
            {
                { Console.WriteLine("Непредвиденная ошибка "); }
            }
        }

        
    }
}
