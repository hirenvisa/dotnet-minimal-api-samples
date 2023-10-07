namespace Customers.API.Contracts;
public record CustomerResponse(
     Guid Id,
     string FirstName,
     string LastName,
     string Email,
     DateOnly BirthDate
);
