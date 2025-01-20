using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FamilyModel
    {
        public int FamilyId { get; set; }

        public string FamilyName { get; set; } = null!;

    }
    public class FamilyMemberModel
    {
        public int FamilyId { get; set; }

        public string FamilyName { get; set; } = null!;
        public List<UserPorfileModel>? FamilyMembers { get; set; }
    }
}
