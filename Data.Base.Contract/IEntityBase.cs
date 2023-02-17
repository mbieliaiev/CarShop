using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Base.Contract
{
    public interface IEntityBase
    {
        int Id { get; set; }

        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}