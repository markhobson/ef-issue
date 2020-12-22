using System.ComponentModel.DataAnnotations;

namespace ef_issue
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Post Post { get; set; }
    }
}
