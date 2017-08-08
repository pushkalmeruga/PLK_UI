using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PLK__
{
    public class Profile
    {
        public async Task<string> SaveProfile(ProfileViewModel userProfile)
        {
            try
            {
                SQLiteHelper sqliteHelper = new SQLiteHelper();

                string result = string.Empty;

                var jsonProfileDetails = JsonConvert.SerializeObject(
                    new
                    {
                        UserName = userProfile.UserName,
                        Password = userProfile.Password,
                        FirstName = userProfile.FirstName,
                        LastName = userProfile.LastName,
                        EmailId = userProfile.EmailId,
                        DefaultLocation = userProfile.DefaultLocation,
                        MobileNumber = userProfile.MobileNumber
                    });

                string response = await RESTServiceHelper.PostData("/signup", jsonProfileDetails);

                if (response == "false")
                    return "Username already exists. Try with different username.";

                ProfileViewModel profile = JsonConvert.DeserializeObject<ProfileViewModel>(response);                

                if (profile != null)
                {
                    profile.CanSaveAsNewUser = false;
                    sqliteHelper.InsertUserProfile(profile);
                    result = "true";
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Save profile failed..!!");
            }
        }

        public async Task<string> UpdateProfile(ProfileViewModel userProfile)
        {
            try
            {
                SQLiteHelper sqliteHelper = new SQLiteHelper();

                string result = string.Empty;

                var jsonProfileDetails = JsonConvert.SerializeObject(
                    new
                    {
                        UserName = userProfile.UserName,
                        Password = userProfile.Password,
                        FirstName = userProfile.FirstName,
                        LastName = userProfile.LastName,
                        EmailId = userProfile.EmailId,
                        DefaultLocation = userProfile.DefaultLocation,
                        MobileNumber = userProfile.MobileNumber
                    });

                string response = await RESTServiceHelper.PostData("/updateProfile", jsonProfileDetails);

                ProfileViewModel profile = JsonConvert.DeserializeObject<ProfileViewModel>(response);

                if (profile != null)
                {
                    profile.CanSaveAsNewUser = false;
                    sqliteHelper.InsertUserProfile(profile);
                    result = "true";
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Save profile failed..!!");
            }
        }


    }
}
