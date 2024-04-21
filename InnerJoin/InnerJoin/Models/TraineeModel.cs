using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerJoin.Models
{
    public class TraineeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}