using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public static class GenerateOTP
    {  
            public static string RandomNumber(int min = 1000, int max = 9999)
            {
                Random _random = new Random();
                return Convert.ToString(_random.Next(min, max));
            }

            static string OTP = GenerateOTP.RandomNumber();
            
    }
    
}
