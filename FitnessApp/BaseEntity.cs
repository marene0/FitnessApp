using System.ComponentModel.DataAnnotations;

namespace FitnessApp
{
    public class BaseEntity
    {

        [Key]
        public Guid Id { get; set; }
    }
}
