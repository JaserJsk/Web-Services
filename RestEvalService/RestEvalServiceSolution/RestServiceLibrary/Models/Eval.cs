using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceLibrary.Models
{
    [DataContract]
    public class Eval
    {
        [DataMember]
        public string Id;
        [DataMember]
        public string Submitter;
        [DataMember]
        public DateTime TimeSent;
        [DataMember]
        public string Comments;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Id, Submitter, Comments, TimeSent);
        }
    }
}
