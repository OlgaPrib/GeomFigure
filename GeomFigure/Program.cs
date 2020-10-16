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
                int countKv = 0; //количество квадратов
                double perKv = 0; // средний периметр квадратов
                int countOkr = 0;//количество Окружностей
                double perOkr = 0;// средний периметр окружностей
                int countTr = 0;//количество трапеций
                double perTr = 0;// средний периметр трапеций
                double pr = 0; // периметр
                double sq = 0; //площадь
                int j = 0;
                string[] stroki; //массив строк из файла
                string[] paramFig; //строка с параметрами фигуры
                IGeomFig[] figures = null; //массив объектов
                StreamReader reader = new StreamReader(@"1.txt");
                Dictionary<double, string> perimDict = new Dictionary<double, string>(); // словарь для средних периметров
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
                                figures[j] = new Okruzhnost(paramFig);
                                pr = pr + figures[j].perimetr; 
                                sq = sq + figures[j].ploshad;
                                countOkr++;
                                perOkr = perOkr + figures[j].perimetr;
                                perimDict.Add(perOkr, figures[j].GetType().Name);
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
                                perimDict.Add(perKv, figures[j].GetType().Name);
                                j++;
                            }
                            else if (Trapeciya.proverka(paramFig))
                            {
                                figures[j] = new Trapeciya(paramFig);
                                pr = pr + figures[j].perimetr;
                                sq = sq + figures[j].ploshad;
                                countTr++;
                                perTr = perTr + figures[j].perimetr;
                                perimDict.Add(perTr, figures[j].GetType().Name);
                                j++;
                            }
                            else
                                Console.WriteLine("В строке " + (i + 1) + " возможно неправильно введены параметры!");
                        }
                        else
                            Console.WriteLine("В строке " + (i + 1) + " возможно неправильно введены параметры!");
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
                    // средний периметр всех фигур
                    Console.WriteLine("\n\n Средний периметр всех фигур = " + pr / j);

                    // средняя площадь всех фигур
                    Console.WriteLine("\n\n Средняя площадь всех фигур = " + sq / j);
                    
                    //сортировка массива по площади и поиск фигуры с наибольшей площадью
                    Array.Sort(figures, new SravPoPloshadi());
                    int maxValue = figures.Length - 1;
                    Console.WriteLine("\n\n Фигура, с наибольшей площадью \n");
                    figures[maxValue].Vyvod(maxValue + 1);

                    // тип фигуры с наибольшим значением среднего периметра среди всех других типов фигур
                    string result = perimDict.Values.Max();
                    Console.WriteLine("\n\n Тип фигуры, с наибольшим значением среднего периметра: " + result);                    
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
