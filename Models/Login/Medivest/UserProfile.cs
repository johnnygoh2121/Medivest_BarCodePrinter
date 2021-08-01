using System;

namespace Medivest_BarCodePrinter.Models.Login.Medivest
{
    public class UserProfile
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string whsCode { get; set; }
        public string active { get; set; }
        public string region { get; set; }
        public string division { get; set; }
        public string department { get; set; }
        public string role { get; set; }
        public string createUser { get; set; }
        public DateTime createDate { get; set; }
        public string lastUpdateUser { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public string cancelPO { get; set; }
        public string closePO { get; set; }
        public string escalate { get; set; }
        public string sapUser { get; set; }
        public string services { get; set; }
        public string viewPR { get; set; }
        public string viewPO { get; set; }
        public string storeClerk { get; set; }
    }
}
