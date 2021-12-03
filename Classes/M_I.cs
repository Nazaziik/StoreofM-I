using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace StoreofM_I
{
    public class M_I
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
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
        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }

        static public List<M_I> PersonsList;

        public M_I(string name, string producent, int age, string serialNumber, string produsingDate, string tyOf, Bitmap bitmap)
        {
            this.name = name;
            this.producent = producent;
            this.age = age;
            this.serialNumber = serialNumber;
            this.produsingDate = produsingDate;
            this.typeOf = tyOf;
            this.bitmap = bitmap;

            PersonsList.Add(this);
        }

        public M_I() { }

        public M_I(M_I MusicalInstrument)
        {
            this.name = MusicalInstrument.name;
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
    }
}
