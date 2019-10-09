using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace WindowsFormsGalaxy
{
    public struct Detect
    {
        public int row;
        public BindingList<PropertyInfo> prop;
    }
    public class DetectList
    {
        BindingList<Detect> list;

        public DetectList()
        {
            list = new BindingList<Detect>();
        }

        public BindingList<Detect> List
        {
            get { return list; }
        }

        public void Find(CurrencyManager cm, string find)
        {
            int i = 0;
            foreach (object o in cm.List)
            {
                Detect temp = new Detect();
                temp.row = i;
                temp.prop = FindPropInRow(o, find);
                list.Add(temp);
                i++;
            }

        }

        public bool Show(DataGridViewColumnCollection coll, out Point forCell)
        {
            forCell = new Point();

            for (int i = 0; i < list.Count; i++)
            {
                Detect d = new Detect();
                d = list[i];

                forCell.Y = d.row;
                foreach (PropertyInfo inf in d.prop)
                {
                    foreach (DataGridViewColumn c in coll)
                    {
                        if (inf.Name == c.HeaderText)
                        {
                            forCell.X = c.Index;
                            d.prop.Remove(inf);
                            return true;
                        }
                    }
                }
                list.Remove(d);
                i--;
            }
            return false;
        }


        BindingList<PropertyInfo> FindPropInRow(object o, string find)
        {

            BindingList<PropertyInfo> temp = new BindingList<PropertyInfo>();
            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {

                if (p.GetValue(o, null).ToString() == find)
                    temp.Add(p);
            }
            return temp;

        }
    }
}
    


    
