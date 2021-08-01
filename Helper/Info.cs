using System;
using System.Collections.Generic;
using System.Text;

namespace Medivest_BarCodePrinter.Helper
{
    public class Info
    {
        public string CurrentCompany { get; set; } = "Medivest Sdn Bhd. (224192-H)";
        public string BaseAdd { get; set; } //= @"http://www.ftsap.com:82/medivest";

        public string Post_LoginEnPoint { get; set; } = @"/api/medivestusers/";
        public string Get_Whsitem { get; set; } = @"/api/medivestoitm/whscode/"; // {whscode}

        public Info()
        {
            BaseAdd = Program.SvrBaseAddress;
        }
    }
}
