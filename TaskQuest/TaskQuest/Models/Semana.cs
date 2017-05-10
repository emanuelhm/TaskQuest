using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TaskQuest.Models
{
    [Table("sem_semana")]
    public class Semana
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semana()
        {
            Quests = new HashSet<Quest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sem_id")]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column("sem_dia")]
        public string Dia { get; set; }

        [Required]
        [StringLength(1)]
        [Column("sem_sigla")]
        public string Sigla { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quest> Quests { get; set; }
    }
}