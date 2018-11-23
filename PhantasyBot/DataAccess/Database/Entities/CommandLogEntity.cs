using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhantasyBot.DataAccess.Database.Entities
{
    [Table("CommandLogs")]
    public class CommandLogEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CommandLogId { get; set; }

        [Required]
        public string CommandName { get; set; }
        
        public string CommandParams { get; set; }

        [NotMapped]
        private string _userId { get; set; }

        [Required]
        public ulong UserId
        {
            get => ulong.Parse(_userId);
            set => _userId = value.ToString();
        }

        [Required]
        public string UserDisplayName { get; set; }

        [Required]
        public DateTime CommandTimestamp { get; set; }
    }
}
