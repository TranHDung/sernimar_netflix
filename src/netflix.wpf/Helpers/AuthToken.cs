﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.Models
{
    public class AuthToken
    {
        public static string getAccessToken()
        {
            return Properties.Settings.Default.AuthToken;
        }
        public static void setAccessToken(string token)
        {
            Properties.Settings.Default.AuthToken = token;
        }
    }
}