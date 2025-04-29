using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dyfilm_client_v2._0.src
{
    internal class data_struct
    {
        public class VerifyToken
        {
            public int code { get; set; }
            public List<object> info { get; set; }
            public string message { get; set; }
        };

        public class FrameInfo
        {
            public int code { get; set; }
            public List<List<object>> info { get; set; }
            public string message { get; set; }
        };

        public class Frame
        {
            public Dictionary<string, object> canvas { get; set; }
            public List<Dictionary<string, object>> captures { get; set; }
        }
    }
}
