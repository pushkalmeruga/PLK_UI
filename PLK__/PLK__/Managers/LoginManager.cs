using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PLK__
{
    public class LoginManager
    {
        public async Task<bool> GetProfile(string userName, string password)
        {
            try
            {
                SQLiteHelper sqliteHelper = new SQLiteHelper();
                bool result = false;
                var jsonLoginDetails = JsonConvert.SerializeObject(new { UserName = userName, Password = password });

                var response = await RESTServiceHelper.PostData("/signin", jsonLoginDetails);

                ProfileViewModel profile = JsonConvert.DeserializeObject<ProfileViewModel>(response);

                if (profile != null)
                {
                    profile.CanSaveAsNewUser = false;

                    sqliteHelper.InsertUserProfile(profile);

                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

        public async Task<bool> Logout()
        {
            SQLiteHelper sqlite = new SQLiteHelper();
            return sqlite.WipeOffUserData();
        }
    }
}
