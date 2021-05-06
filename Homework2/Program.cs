using System;
using System.Collections.Generic;
using System.Linq;
namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();
            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            Console.WriteLine($"Password is eq to hello \n-----\n\r{string.Join("\n\r", users.Where(x => x.Password == "hello").Select(x => x.Name))}");
            users.RemoveAll(x => x.Name.ToLower() == x.Password);
            users.Remove(users.FirstOrDefault(x => x.Password == "hello"));
            Console.WriteLine($"\nRemaining User(s):\n-----\n{string.Join("\n\r", users.Select(x => new { Name = x.Name, PassWord = x.Password }))}");
        }

    }
      
}
