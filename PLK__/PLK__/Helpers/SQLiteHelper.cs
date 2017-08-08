using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;

namespace PLK__
{
    public class SQLiteHelper
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public SQLiteHelper()
        {
            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
        }

        public bool InsertUserProfile(ProfileViewModel profile)
        {
            _sqLiteConnection.DropTable<ProfileViewModel>();
            _sqLiteConnection.CreateTable<ProfileViewModel>();
            return _sqLiteConnection.Insert(profile) > 0;
        }

        public ProfileViewModel GetUserProfile(string userName = "")
        {
            if (TableExists<ProfileViewModel>())
            {
                if (userName != "")
                    return _sqLiteConnection.Table<ProfileViewModel>().Where(x => x.UserName == userName).FirstOrDefault();
                else
                    return _sqLiteConnection.Table<ProfileViewModel>().FirstOrDefault();
            }
            return null;
        }

        public bool WipeOffUserData()
        {
            bool result = false;
            if (TableExists<ProfileViewModel>())
            {
                result = _sqLiteConnection.DropTable<ProfileViewModel>() > 0;
            }
            return result;
        }

        private bool TableExists<T>()
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
            var cmd = _sqLiteConnection.CreateCommand(cmdText, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }

    }
}
