using Firebase.Database;
using Firebase.Database.Query;
using RickNotifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNotifications.Services
{
    public class UserService
    {
        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://ricknotifications-default-rtdb.firebaseio.com/"); 
        }

        public async Task<bool> IsUserExistis(string name)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>())
                .Where(u => u.Object.Username == name)
                .FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string name, string password)
        {
            if (await IsUserExistis(name) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        Username = name,
                        Password = password
                    });
                return true;
                    
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string name, string password)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>())
                .Where(u => u.Object.Username == name)
                .Where(u => u.Object.Password == password)
                .FirstOrDefault();

            return (user != null);
        }
    }
}
