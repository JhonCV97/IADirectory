using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CategoriesAI : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
