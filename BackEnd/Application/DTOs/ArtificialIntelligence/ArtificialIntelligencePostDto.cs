using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ArtificialIntelligence
{
    public class ArtificialIntelligencePostDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public int CategoriesAIId { get; set; }
    }
}
