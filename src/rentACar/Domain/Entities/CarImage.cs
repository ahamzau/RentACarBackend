using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CarImage: Entity
{
    public string ImageUrl { get; set; }
    public int CarId { get; set; }
    public virtual Car Car { get; set; }
}
