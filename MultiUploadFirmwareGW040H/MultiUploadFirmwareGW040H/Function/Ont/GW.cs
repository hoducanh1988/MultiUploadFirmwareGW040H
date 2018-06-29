using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiUploadFirmwareGW040H.Function.Protocol;

namespace MultiUploadFirmwareGW040H.Function.Ont {
    public class GW : Serial  {

        public GW(string _port) : base (_port) { }

    }
}
