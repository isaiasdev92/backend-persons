using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExameSoftware.Models
{
	[Table("DataPeople")]
	public class People
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(50), Required]
		public string Name { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

	}
}

