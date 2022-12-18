using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallyAssignment_4.Models
{
    public partial class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public int MaxMarks { get; set; }

        public int MarksObtained { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
}
