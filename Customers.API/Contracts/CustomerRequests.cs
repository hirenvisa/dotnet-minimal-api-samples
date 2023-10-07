using System.ComponentModel.DataAnnotations;

namespace Customers.API.Contracts;

 
public record UpdateCustomerRequest(
     Guid Id,
     string FirstName, 
     string LastName, 
     string Email,
     DateOnly BirthDate
);

public record CustomerRequest(
     string FirstName,
     string LastName,
     string Email,
     DateOnly BirthDate
);