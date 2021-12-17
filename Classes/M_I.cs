using System;
using System.Collections.Generic;
using System.IO;
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

        public M_I(string ownerName, string producent, int age, string serialNumber, DateTime produsingDate, string tyOf)
        {
            this._ownerName = ownerName;
            this._producent = producent;
            this._age = age;
            this._serialNumber = serialNumber;
            this._produsingDate = produsingDate;
            this._typeOf = tyOf;
        }

        public M_I() { }

        public M_I(M_I MusicalInstrument)
        {
            this._ownerName = MusicalInstrument._ownerName;
            this._producent = MusicalInstrument._producent;
            this._age = MusicalInstrument._age;
            this._serialNumber = MusicalInstrument._serialNumber;
            this._produsingDate = MusicalInstrument._produsingDate;
            this._typeOf = MusicalInstrument._typeOf;
            this._image = MusicalInstrument._image;
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
