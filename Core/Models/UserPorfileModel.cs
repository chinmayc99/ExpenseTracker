using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserPorfileModel
    {
        
        public int UserId { get; set; }

      
        public string DisplayName { get; set; } = null!;

    
        public string FirstName { get; set; } = null!;

      
        public string LastName { get; set; } = null!;


        public string Email { get; set; } = null!;

      
        public string AdObjId { get; set; } = null!;

        public int? FamilyId { get; set; }
    }
}
