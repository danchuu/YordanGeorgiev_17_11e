using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [StringLength(20, MinimumLength = 1,
      ErrorMessage = "First Name should be minimum 1 characters and a maximum of 20 characters")]
        public string Name { get; set; }
        public List<User> Users { get; set;}
        public Category( string name)
        {
            
            Name = name;
            List<User> users = new List<User>();
        }
        public Category()
        {
            List<User> users = new List<User>();

        }
    }
}
