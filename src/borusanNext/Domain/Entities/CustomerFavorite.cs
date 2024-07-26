namespace Domain.Entities;

public class CustomerFavorite
{
    public string CollectionName { get; set; }
    public Guid CustomerId { get; set; }
    public Guid FavoriteId { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Favorite Favorite { get; set; }
}