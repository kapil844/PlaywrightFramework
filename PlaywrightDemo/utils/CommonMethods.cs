using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomString4Net;
using System.Threading.Tasks;

namespace PlaywrightDemo.utils
{
    public class CommonMethods
    {

        public int getRandomNumber()
        {
            Random rnd = new Random(9);
            return rnd.Next();
        }

        public string getRandomString()
        {
            return RandomString.GetString(Types.ALPHABET_LOWERCASE, 15);

        }
    }
}
