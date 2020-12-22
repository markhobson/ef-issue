using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ef_issue
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        
        public int BlogId { get; set; }
        
        public virtual Blog Blog { get; set; }

        public string Title { get; set; }
        
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
