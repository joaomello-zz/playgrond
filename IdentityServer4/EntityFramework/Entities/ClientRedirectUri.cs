using System.ComponentModel.DataAnnotations;

namespace IndentityServer.EntityFramework.Entities
{
    public class ClientRedirectUri
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [StringLength(2000)]
        public virtual string Uri { get; set; }

        public virtual Client Client { get; set; }
    }
}
