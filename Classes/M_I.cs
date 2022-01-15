using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace StoreofM_I
{
    public class M_I
    {
        private string _ownerName;
        public string OwnerName
        {
            get { return _ownerName; }
            set { _ownerName = value; }
        }

        private string _producent;
        public string Producent
        {
            get { return _producent; }
            set { _producent = value; }
        }

        private int? _age;
        public int? Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private string _serialNumber;
        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }

        private DateTime? _produsingDate;
        public DateTime? ProdusingDate
        {
            get { return _produsingDate; }
            set { _produsingDate = value; }
        }

        private string _typeOf;
        public string TypeOf
        {
            get { return _typeOf; }
            set { _typeOf = value; }
        }

        private BitmapSource? _image;
        [XmlIgnore]
        public BitmapSource? Image
        {
            get { return _image; }
            set { _image = value; }
        }

        [XmlElement("Image")]
        public byte[]? ImageBuffer
        {
            get
            {
                byte[]? imageBuffer = null;

                if (Image != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        var encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(Image));
                        encoder.Save(stream);
                        imageBuffer = stream.ToArray();
                    }
                }

                return imageBuffer;
            }
            set
            {
                if (value == null)
                {
                    Image = null;
                }
                else
                {
                    using (var stream = new MemoryStream(value))
                    {
                        var decoder = BitmapDecoder.Create(stream,
                            BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        Image = decoder.Frames[0];
                    }
                }
            }
        }

        static public List<M_I>? M_IList;

        public M_I(string ownerName, string producent, int age, string serialNumber, DateTime produsingDate, string tyOf, string image)
        {
            this._ownerName = ownerName;
            this._producent = producent;
            this._age = age;
            this._serialNumber = serialNumber;
            this._produsingDate = produsingDate;
            this._typeOf = tyOf;
            ImageBuffer = Encoding.ASCII.GetBytes(image);
        }

        public M_I() { }

        public M_I(M_I MusicalInstrument)
        {
            this._ownerName = MusicalInstrument.OwnerName;
            this._producent = MusicalInstrument.Producent;
            this._age = MusicalInstrument.Age;
            this._serialNumber = MusicalInstrument.SerialNumber;
            this._produsingDate = MusicalInstrument.ProdusingDate;
            this._typeOf = MusicalInstrument.TypeOf;
            this._image = MusicalInstrument.Image;
        }

        public bool WhereProducent(string phrase)
        {
            return Producent.Contains(phrase);
        }

        public bool WhereSerNum(string phrase)
        {
            return SerialNumber.Contains(phrase);
        }

        public bool WhereType(string phrase)
        {
            return TypeOf.Contains(phrase);
        }
    }
}
