using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using WindowsFormsGalaxy;
using System.ComponentModel;

namespace WindowsFormsGalaxy
{
    public enum GalaxyType : byte { NA, E, S0, Sa, Sb, Irr };
    [Serializable]
    public class Galaxy
    {
        string name, photoFile;
        GalaxyType type;
        DateTime discovered;
        double rad, thic; //кпк

        double luminosity; //относительно светимости солнца
        static string DefPic = "1.jpg";
        Bitmap photo;

        static double minThic = 0.3, minRad = 1, minLuminosity = 1e7,
               maxThic = 1, maxRad = 7, maxLuminosity = 1e11;
            
        static string photoFolder = "C:\\Users\\Роман\\Desktop\\СПбГПУ\\Лабы C++ и C#\\С#\\MyConsole\\WindowsFormsGalaxy\\Images\\";
        static int maxName = 25;
        

        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set {
                if ((int)value.Length > maxName)
                    name = name.Substring(maxName+1);
                name = Helper.GetName(value); }
        }
        [XmlIgnore]
        public static string PhotoFolder
        {
            get { return photoFolder; }
            set
            {
                if (Directory.Exists(value))
                    photoFolder = value;
            }
        }

        [XmlAttribute]
        public string PhotoFile
        {
            get { return Path.GetFileName(photoFile); }
            set
            {
                if (photoFolder != null && value != null)
                {
                    string file = photoFolder + value;
                    photoFile = file;
                    //photo = new Bitmap(file);
                }
            }
        }

        [XmlAttribute]
        public GalaxyType Type
        {
            get { return type; }
            set
            {
                type = value;
                if (value < GalaxyType.E || GalaxyType.Irr < value)
                    type = GalaxyType.NA;
            }
        }

        [XmlAttribute]
        public DateTime Discovered
        {
            get { return discovered; }
            set
            {
                if (DateTime.Now < value)
                    discovered = DateTime.Now;
                discovered = value;
            }
        }
        
       [XmlAttribute]
        public double Thic
        {
            get { return thic; }
            set
                {
                    thic = minThic;
                    if (value >= minThic && value <= maxThic)
                    thic = value;
                }

        }

        [XmlAttribute]
        public double Rad
        {
            get{return rad;}
            set
                {
                rad = minRad;
                if (value >= minRad && value <= maxRad)
                    rad = value;
                }

        }

         [XmlAttribute]
        public double Luminosity
        {
            get{return luminosity;}
            set
                {
                luminosity = minLuminosity;
                if (value >= minLuminosity && value <= maxLuminosity)
                    luminosity = value;
                }

        }

         [XmlAnyAttribute]
         public Bitmap Photo
         {
             get { return photo; }         
         }
        //только чтение
         [XmlAttribute]
         public static double MinThic
         {
             get { return minThic; }
         }
         [XmlAttribute]
         public static double MinRad
         {
             get { return minRad; }
         }
         [XmlAttribute]
         public static double MinLuminosity
         {
             get { return minLuminosity; }
         }
         public static double MaxThic
         {
             get { return maxThic; }
         }
         [XmlAttribute]
         public static double MaxRad
         {
             get { return maxRad; }
         }
         [XmlAttribute]
         public static double MaxLuminosity
         {
             get { return maxLuminosity; }
         }


        public Galaxy()
        {
            Name = "N/A";
            Type = GalaxyType.NA;
            Discovered = DateTime.Now;
            Rad = minRad;
            Thic = minThic;
            Luminosity = minLuminosity;
            PhotoFile = DefPic;
        }
        public Galaxy(string n)
        {
            Name = n;
            Type = GalaxyType.NA;
            Discovered = DateTime.Now;
            Rad = minRad;
            Thic = minThic;
            Luminosity = minLuminosity;
            PhotoFile = DefPic;
        }
        public Galaxy(string n, GalaxyType t)
        {
            Name = n;
            Type = t;
            Discovered = DateTime.Now;
            Rad = minRad;
            Thic = minThic;
            Luminosity = minLuminosity;
            PhotoFile = DefPic;
        }    
        public Galaxy(string n, GalaxyType t, DateTime d)
        {
            Name = n;
            Type = t;
            Discovered = d;
            Rad = minRad;
            Thic = minThic;
            Luminosity = minLuminosity;
            PhotoFile = DefPic;
        }
        public Galaxy(string n, GalaxyType t, DateTime d, double r)
        {
            Name = n;
            Type = t;
            Discovered = d;
            Rad = r;
            Thic = minThic;
            Luminosity = minLuminosity;
            PhotoFile = DefPic;
        }
        public Galaxy(string n, GalaxyType t, DateTime d, double r, double thic)
        {
            Name = n;
            Type = t;
            Discovered = d;
            Rad = r;
            Thic = thic;
            Luminosity = minLuminosity;
            PhotoFile = DefPic;
        }
        public Galaxy(string n, GalaxyType t, DateTime d, double r, double thic, double l)
        {
            Name = n;
            Type = t;
            Discovered = d;
            Rad = r;
            Thic = thic;
            Luminosity = l;
            PhotoFile = DefPic;
        }

        public Galaxy(Galaxy g)
        {
            name = g.name;
            type = g.type;
            discovered = g.discovered;
            rad = g.rad;
            thic = g.thic;
            PhotoFile = g.photoFile;
        }

        public Galaxy(object o)
        {
            try
            {
                Galaxy g = o as Galaxy;
                name = g.name;
                type = g.type;
                discovered = g.discovered;
                rad = g.rad;
                thic = g.thic;
                PhotoFile = g.photoFile;
            }
            catch { }
        }

        public override string ToString()
        {
            return name + "; Type: " + type + "; Discovered: " + discovered.ToShortDateString() +
                          "; Rad: " + rad + "; Diam: " + thic + "; Luminosity: " + luminosity;
        }
        public override bool Equals(object o)
        {
            Galaxy g = o as Galaxy;
            return g == null ? false :
                name.Equals(g.name) && discovered.Equals(g.discovered) &&
                rad == g.rad && thic == g.thic && luminosity == g.luminosity;
        }
        public override int GetHashCode() { return (name + discovered).GetHashCode(); }



        public float AgeOfDiscovered
        {
            get
            {
                if (discovered == DateTime.MinValue)
                    return 0;
                TimeSpan span = DateTime.Now - discovered;
                return (float)Math.Round(span.Days / 365.25, 1);
            }
        }
    }

    public class GalaxyList
    {
        public BindingList<Galaxy> list = new BindingList<Galaxy>();

        [XmlElement(typeof(Galaxy))]
        public BindingList<Galaxy> Galax
        {
            get { return list; }
            set { list = value; }
        }

        public void WriteXml(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Galaxy>));
            Stream stream = new FileStream(FileName, FileMode.Create);
            serializer.Serialize(stream, list);
            stream.Close();
        }

        public void ReadXml(string FileName)
        {
            list.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Galaxy>));
            Stream stream = new FileStream(FileName, FileMode.Open);
            list = (serializer.Deserialize(stream) as BindingList<Galaxy>);
            stream.Close();
        }


    }
}
