using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Браузер
{
    class Serialization
    {
        public static void Save(object source, string filePath)
        {
            var bf = new BinaryFormatter();
            using (var fs = File.OpenWrite(filePath))
            {
                bf.Serialize(fs, source);
            }
        }

        public static T Get<T>(string filePath)
        {
            var bf = new BinaryFormatter();
            try
            {
                using (var fs = File.OpenRead(filePath))
                {
                    return (T)bf.Deserialize(fs);
                }
            }
            catch
            {
                return default;
            }
        }
    }
}
