using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            V3DataOnGrid test_dataOnGrid = new V3DataOnGrid("constructor.txt");
            Console.WriteLine(test_dataOnGrid.ToLongString("f2"));
            V3MainCollection test_mainCollection = new V3MainCollection();
            test_mainCollection.AddDefaults();
            Console.WriteLine(test_mainCollection.ToLongString("f3"));
            

            Console.WriteLine("запрос возвращает множество точек измерения поля в MainCollection, которые есть в V3DataCollection, но нет в V3DataOnGrid"); 
            IEnumerable<Vector2> query = test_mainCollection.IEnumerableVectors;
            foreach (var el in query)
            {
                Console.WriteLine(el.ToString("f3"));
            }

            Console.WriteLine("\n");
            Vector2 v = new Vector2((float)0.19, (float)0.19);
            Console.WriteLine("запрос возвращает расстояние от заданной точки {0} до самой близкой точки из MainCollection", v.ToString());
            Console.WriteLine(test_mainCollection.RMin(v).ToString("f4"));

            Console.WriteLine("\n");
            Vector2 v1 = new Vector2((float)0.19, (float)0.20);
            Console.WriteLine("запрос возвращает информацию о точке, самой близкой к {0}, в виде элемента DataItem", v1.ToString());
            Console.WriteLine(test_mainCollection.RMinDataItem(v1).ToString("f3"));
            
        }
    }
}
