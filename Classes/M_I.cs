using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace StoreofM_I
{
    [XmlRootAttribute("M_I", Namespace = "StoreofM_I")]
    public class M_I
    {
        private string ownerName;
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }

        private string producent;
        public string Producent
        {
            get { return producent; }
            set { producent = value; }
        }

        private int? age;
        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        private string serialNumber;
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        private string produsingDate;
        public string ProdusingDate
        {
            get { return produsingDate; }
            set { produsingDate = value; }
        }

        private string typeOf;
        public string TypeOf
        {
            get { return typeOf; }
            set { typeOf = value; }
        }

        private Bitmap bitmap;
        [XmlIgnoreAttribute()]
        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }

        static public List<M_I> M_IList;
        public static Type[] types = new Type[] { typeof(string), typeof(byte[]), typeof(bool), typeof(int) };

        public M_I(string ownerName, string producent, int age, string serialNumber, string produsingDate, string tyOf, Bitmap bitmap)
        {
            this.ownerName = ownerName;
            this.producent = producent;
            this.age = age;
            this.serialNumber = serialNumber;
            this.produsingDate = produsingDate;
            this.typeOf = tyOf;
            this.bitmap = bitmap;

            M_IList.Add(this);
        }

        public M_I() { }

        public M_I(M_I MusicalInstrument)
        {
            this.ownerName = MusicalInstrument.ownerName;
            this.producent = MusicalInstrument.producent;
            this.age = MusicalInstrument.age;
            this.serialNumber = MusicalInstrument.serialNumber;
            this.produsingDate = MusicalInstrument.produsingDate;
            this.typeOf = MusicalInstrument.typeOf;
            this.bitmap = MusicalInstrument.bitmap;
        }

        public bool WhereProducent(string phrase)
        {
            return producent.Contains(phrase);
        }

        public bool WhereSerNum(string phrase)
        {
            return serialNumber.Contains(phrase);
        }

        public bool WhereProdDate(string phrase)
        {
            return produsingDate.Contains(phrase);
        }
        [XmlElementAttribute("Picture")]
        public byte[]? PictureByteArray
        {
            get
            {
                if (Bitmap != null)
                {
                    TypeConverter BitmapConverter =
                         TypeDescriptor.GetConverter(Bitmap.GetType());
                    return (byte[]?)
                         BitmapConverter.ConvertTo(Bitmap, typeof(byte[]));
                }
                else
                    return null;
            }

            set
            {
                if (value != null)
                    Bitmap = new Bitmap(new MemoryStream(value));
                else
                    Bitmap = null;
            }
        }
    }
}
