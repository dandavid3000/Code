using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QuanLy_IO
{
    public class Users
    {
        //Ability & Property
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private string _group;

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        //Phương Thức
        public Users(string userName)
        {
            StreamReader reader = new StreamReader("../../users/" + userName + ".txt");
            // doc dong 1 la username
            this.UserName = reader.ReadLine();
            // doc dong 2 la password
            this.Password = reader.ReadLine();
            // doc dong 3 la full name
            this.FullName = reader.ReadLine();
            // doc dong 4 la group
            this.Group = reader.ReadLine();
            // dong file
            reader.Close();
        }

        public static bool Authentication(string userName, string password)
        {
            // kiem tra xem file user co ton tai
            if (File.Exists("../../users/" + userName + ".txt"))
            {
                StreamReader reader = new StreamReader("../../users/" + userName + ".txt");
                // doc dong 1 la username
                string dong1 = reader.ReadLine();
                // doc dong 2 la password
                string dong2 = reader.ReadLine();
                // dong file
                reader.Close();
                // kiem tra co dung password
                if (password == dong2) return true;
                else return false;
            }
            else // file user khong ton tai
            {
                return false;
            }
        }
    }
}
