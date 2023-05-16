using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
