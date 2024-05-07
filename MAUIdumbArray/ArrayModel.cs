using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIdumbArray
{
    internal static class ArrayModel
    {
        //класс модели - хранилища данных приложения
        //при необходимости добавить методы для сохранения
        //и считывания из файла или заменить на полноценную БД
        public static uint RowCount = 2, ColCount = 2;
        public static double[,] Matrix = new double[RowCount, ColCount];
    }
}
