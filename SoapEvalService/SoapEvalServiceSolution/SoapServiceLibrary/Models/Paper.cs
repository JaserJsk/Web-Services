using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceLibrary
{
    [DataContract]
    public class Paper : Media
    {
        [DataMember]
        public string Category { get; set; }
    }
}
