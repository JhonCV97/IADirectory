using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class ArtificialIntelligence : Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public int CategoriesAIId { get; set; }
        [ForeignKey("CategoriesAIId")]
        public CategoriesAI CategoriesAI { get; set; }
    }
}
