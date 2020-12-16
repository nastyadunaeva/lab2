using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Linq;

namespace Lab2
{
    class V3MainCollection : IEnumerable<V3Data>
    {
        private List<V3Data> v3Datas { get; set;}
        public V3MainCollection()
        {
            v3Datas = new List<V3Data>();
        }
        public int Count => v3Datas.Count;
        public IEnumerator<V3Data> GetEnumerator()
        {
            return v3Datas.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return v3Datas.GetEnumerator();
        }

        public void Add(V3Data item)
        {
            v3Datas.Add(item);
        }
        public bool Remove(string id, DateTime dt)
        {
            int amount = v3Datas.RemoveAll(x => ((x.information == id) && (x.time == dt)));
            if (amount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddDefaults()
        {
            Grid1D x = new Grid1D((float)0.2, 2);
            Grid1D y = new Grid1D((float)0.2, 2);
            V3DataOnGrid data1 = new V3DataOnGrid("", DateTime.Now, x, y);
            data1.InitRandom(0.25, 0.5);

            Grid1D x1 = new Grid1D((float)0.0, 0);
            Grid1D y1 = new Grid1D((float)0.0, 0);
            V3DataOnGrid data2 = new V3DataOnGrid("", DateTime.Now, x1, y1);
            
            V3DataCollection data3 = new V3DataCollection();
            data3.InitRandom(4,(float)0.4, (float)0.4, 1.25, 0.2);
            
            V3DataCollection data4 = new V3DataCollection();
            v3Datas.Add(data1);
            v3Datas.Add(data2);
            v3Datas.Add(data3);
            v3Datas.Add(data4);
        }
        public override string ToString()
        {
            string tmp = "";
            foreach (V3Data v3 in v3Datas)
            {
                tmp = tmp + v3.ToString() + " ";
            }
            return tmp;
        }
        public string ToLongString(string format)
        {
            string tmp = "";
            foreach (V3Data v3 in v3Datas)
            {
                tmp = tmp + v3.ToLongString(format) + " ";
                Console.WriteLine();
            }
            return tmp;
        }
        public float RMin(Vector2 v)
        {
            var query = from data in v3Datas
                        from item in data
                        select Vector2.Distance(v, item.Vec);

            return query.Min();
            
        }
        public DataItem RMinDataItem (Vector2 v)
        {
            var query = from data in v3Datas
                        from item in data
                        where Vector2.Distance(v, item.Vec) == RMin(v)
                        select item;
            return query.First();
        }
        public IEnumerable<Vector2> IEnumerableVectors
        {
            get
            {
                IEnumerable<Vector2> vector_set1 = from data in v3Datas
                                                  from item in data
                                                  where data.GetType().ToString() == "Lab2.V3DataCollection" 
                                                  select item.Vec;
                IEnumerable<Vector2> vector_set2 = from data in v3Datas
                                                   from item in data
                                                   where data.GetType().ToString() == "Lab2.V3DataOnGrid"
                                                   select item.Vec;
                var query = from item in vector_set1.Except(vector_set2)
                            select item;
                return query;
            }
        }
        
    }
}
