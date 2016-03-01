using System.ComponentModel.DataAnnotations;

namespace IdentityServer.EntityFramework.Entities
{
    public class ClientScope
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string Scope { get; set; }

        public virtual Client Client { get; set; }
    }
}
