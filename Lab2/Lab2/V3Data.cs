﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace Lab2
{
    abstract class V3Data: IEnumerable<DataItem>
    {
        public string information { get; set; }
        public DateTime time { get; set; }
        public V3Data() { }
        public V3Data(string constr_information, DateTime constr_time)
        {
            information = constr_information;
            time = constr_time;
        }
        public abstract Vector2[] Nearest(Vector2 v);
        public abstract string ToLongString();
        public override string ToString()
        {
            return (information + " " + time.ToString());
        }
        public abstract string ToLongString(string format);
        public IEnumerator<DataItem> GetEnumerator()
        {
            V3DataCollection tmp = new V3DataCollection();
            tmp = (V3DataCollection)this;
            return tmp.dataItems.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            V3DataCollection tmp = new V3DataCollection();
            tmp = (V3DataCollection)this;
            return tmp.GetEnumerator();
        }
    }
}
