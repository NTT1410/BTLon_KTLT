using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Markup;
using System.Text.Json;

namespace QuanLyKhoHang
{
    public class ListAccount
    {
        public static List<Account> readFile(string path)
        {
            List<Account> accounts = new List<Account>();
            try
            {                
                var content = System.IO.File.ReadAllText(path);
                JsonDocument doc = JsonDocument.Parse(content);
                JsonElement root = doc.RootElement;

                for (int i = 0; i < root.GetArrayLength(); i++)
                {
                    Account acc = new Account();
                    acc.Name = root[i].GetProperty("Name").ToString();
                    acc.UserName = root[i].GetProperty("UserName").ToString();
                    acc.Password = root[i].GetProperty("Password").ToString();
                    accounts.Add(acc);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return accounts;
        }
    }
}
