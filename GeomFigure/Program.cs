using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeomFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
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
                    for(int i=0; i<stroki.Length; i++)
                    {
                        paramFig = stroki[i].Split(' ');
                        if(paramFig.Length == 3)
                        {
                            if (Convert.ToDouble(paramFig[2]) > 0)
                            {
                                figures[j] = new Okr(paramFig);
                                j++;
                            }
                            else
                                Console.WriteLine("В строке " + (i+i) + " круг имеет отрицательный радиус, объект не может быть создан!");
                        }
                        else
                            if (paramFig.Length == 8)
                            {
                                if (Kvadrat.proverka(paramFig))
                                {
                                    figures[j] = new Kvadrat(paramFig);
                                    j++;
                                }
                                else
                                {
                                    figures[j] = new Trap(paramFig);
                                    j++;
                                }                                                                                      
                            }
                            else
                            Console.WriteLine("В строке " + (i + i) + " возможно неправельно введены параметры!");
                        }
                    }

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

                    // сортировка массива в порядке убывания периметра
                    Array.Sort(figures, new SravPoPerimetru());
                    Console.WriteLine("\n\n Массив, отсортированный по периметру \n");
                    for (int i = 0; i < j; i++)
                    {
                        figures[i].Vyvod(i + 1);
                    }                   
                }
                else
                    Console.WriteLine("Элементы отсутствуют");
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
