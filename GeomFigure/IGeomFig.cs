using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeomFigure
{
    public interface IGeomFig
    {
        double perimetr { get; } // периметр фигуры
        double ploshad { get; } // площадь фигуры
        void Vyvod(int i); // метод для вывода информации

        double this [int i] { set; get; } // индексатор для доступа к параметрам фигуры
    }
}
