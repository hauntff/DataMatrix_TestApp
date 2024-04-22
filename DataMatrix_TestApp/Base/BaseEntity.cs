using System.ComponentModel.DataAnnotations;

namespace DataMatrix_TestApp.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
