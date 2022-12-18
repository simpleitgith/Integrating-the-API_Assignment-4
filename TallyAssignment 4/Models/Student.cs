using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallyAssignment_4.Models
{
    public partial class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Class { get; set; }

        public  List<Subject> Subject { get; set; }
    }

}
