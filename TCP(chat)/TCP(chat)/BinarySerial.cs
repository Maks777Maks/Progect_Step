using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TCP_chat_
{
    public static class BinarySerial
    {

        public static byte[] Serialize(object Object)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, Object);
                return memoryStream.ToArray();
            }
        }

        public static object Deserialize(byte[] arr)
        {
            using (var memoryStream = new MemoryStream(arr))
                return (new BinaryFormatter()).Deserialize(memoryStream);
        }

    }
}
