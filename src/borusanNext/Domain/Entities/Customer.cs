using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Customer : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public bool IsPhoneVerified { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public CustomerType CustomerType { get; set; }
    public Guid AddressId { get; set; }
    public string AddressLine { get; set; }

    public virtual User User { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<CustomerAdvertLog> CustomerAdvertLogs { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
    public virtual ICollection<CustomerFavorite> CustomerFavorites { get; set; }

}
