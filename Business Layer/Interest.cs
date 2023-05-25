using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }
        [StringLength(20, MinimumLength = 1,
      ErrorMessage = "Name should be minimum 1 characters and a maximum of 20 characters")]
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public Category Category { get; set; }

        public Interest( string name)
        {
            Name = name;
            List<User> Users = new   List<User>();
        }
        public Interest()
        {
            List<User> Users = new List<User>();

        }
    }
}
