using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostmanRunnerTestWeb.Entities
{
    [Table("Test")]
    public class ETest
    {
        [Key]
        public int TestId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
