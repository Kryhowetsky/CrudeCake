using Microsoft.AspNetCore.Http;
using System;

namespace CakeCrude.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        
    }
}