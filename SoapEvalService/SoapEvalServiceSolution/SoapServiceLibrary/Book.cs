using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceLibrary
{
    [DataContract]
    public class Book : Media
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}
