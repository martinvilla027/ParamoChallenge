using System.Collections.Generic;
using System.IO;
using Sat.Recruitment.Api.Contract.Response;

namespace Sat.Recruitment.Api.Helper
{
    public class UserFileHelper
    {
        public static StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            var fileStream = new FileStream(path, FileMode.Open);
            var reader = new StreamReader(fileStream);

            return reader;
        }

        public static List<UserResponse> TransformUsersFromFile(StreamReader reader)
        {
            var usersFromFile = new List<UserResponse>();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                if (line != null)
                {
                    var user = new UserResponse
                    {
                        Name = line.Split(',')[0],
                        Email = line.Split(',')[1],
                        Phone = line.Split(',')[2],
                        Address = line.Split(',')[3],
                        UserType = line.Split(',')[4],
                        Money = decimal.Parse(line.Split(',')[5])
                    };
                    usersFromFile.Add(user);
                }
            }
            reader.Close();
            return usersFromFile;
        }
    }
}
