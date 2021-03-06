﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceLibrary.Models
{
    [DataContract]
    public class Media
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int NbrOfPages { get; set; }
    }
}
