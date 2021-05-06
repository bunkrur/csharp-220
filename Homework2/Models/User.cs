using System;
using System.Collections.Generic;
using System.Text;

namespace Homework2.Models
{
    class User
    {

        private string name = string.Empty;
        private string password = string.Empty;


        public string Name { get; internal set; }
        public string Password { get; internal set; }
    }
}
