//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseEntities
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    [Serializable]
    public partial class Product
    {
        private string v1;
        private int v2;
        private string v3;

        public Product()
        {
            Name = "empty";
            Photo = new Bitmap(ConfigurationManager.AppSettings.Get("defaultPhotoPath"));
            Ingridients = "empty";
        }

        public Product(string name, decimal cost, string ingridients)
        {
            Name = name;
            Cost = cost;
            Ingridients = ingridients;
            Photo = new Bitmap(ConfigurationManager.AppSettings.Get("defaultPhotoPath"));
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public Bitmap Photo { get; set; }
        public byte[] BinaryPhoto
        {
            get
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(ms, Photo);
                    return ms.ToArray();
                }
            }
            set
            {
                using (MemoryStream ms = new MemoryStream(value))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    Photo = binaryFormatter.Deserialize(ms) as Bitmap;
                }
            }
        }
        public string Ingridients { get; set; }
    }
}
