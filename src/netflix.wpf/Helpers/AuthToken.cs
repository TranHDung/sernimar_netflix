using System;
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
        public static string getProfileId()
        {
            return Properties.Settings.Default.ProfileId;
        }
        public static void setProfileId(string id)
        {
            Properties.Settings.Default.ProfileId = id;
        }
        public static string getUserId()
        {
            return Properties.Settings.Default.UserId;
        }
        public static void setUserId(string id)
        {
            Properties.Settings.Default.UserId = id;
        }
    }
}
