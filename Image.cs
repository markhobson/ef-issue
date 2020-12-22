using System.ComponentModel.DataAnnotations;

namespace ef_issue
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        
        public int PostId { get; set; }
        
        public virtual Post Post { get; set; }

        public string Url { get; set; }
    }
}
