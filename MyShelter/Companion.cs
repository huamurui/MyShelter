using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShelter
{
    public class Companion
    {
        public string UID { get; }
        public string Owner{ get; set; }
        public string  email{ get; set; }
        public string password { get; set; }


        public string Number { get; }
        private static int companionNumberSeed = 0;
        public Companion(string name,string Email)
        {
            this.Owner = name;
            this.email = Email;
            this.Number = companionNumberSeed.ToString();
            companionNumberSeed++;
        }
        public void FaQ(DateTime data,string note) { }
    }
}
