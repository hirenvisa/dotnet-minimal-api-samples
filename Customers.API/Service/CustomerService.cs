using Customers.API.Domain;
using Customers.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Customers.API.Service;

public class CustomerService
{
    private readonly CustomerDbContext _customerDbContext;

    public CustomerService(CustomerDbContext customerDbContext) =>
        this._customerDbContext = customerDbContext;


    public async Task<bool> CreateAsync(Customer customer)
    {
        var existingCustomer = await _customerDbContext.Customers.FindAsync(customer.Id);
        if(existingCustomer is not null)
        {
            var message = $"A user with Id {existingCustomer.Id} is already exists.";
            //Todo: inner exception
            throw new ValidationException(message);
        }

        await _customerDbContext.Customers.AddAsync(customer);
        var changes = await _customerDbContext.SaveChangesAsync();

        return changes > 0;
    }

    public async Task<Customer> GetAsync(Guid id)
    {
        var customer = await _customerDbContext.Customers.FindAsync(id);

        if(customer is null) {
            var message = $"Customer with Id {id} is not exists.";
        }

        return customer;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        var customers = await _customerDbContext.Customers.ToListAsync();
        return customers;
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        var existingCustomer = await _customerDbContext.Customers.FindAsync(customer.Id);
        if (existingCustomer is null)
        {
            var message = $"A user with Id {existingCustomer.Id} is not exists.";
            //Todo: inner exception
            throw new ValidationException(message);
        }
        _customerDbContext.Customers.Update(customer);
        var changes = await _customerDbContext.SaveChangesAsync();

        return changes > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingCustomer = await _customerDbContext.Customers.FindAsync(id);
        if (existingCustomer is null)
        {
            var message = $"A user with Id {existingCustomer.Id} is not exists.";
            //Todo: inner exception
            throw new ValidationException(message);
        }
        _customerDbContext.Customers.Remove(existingCustomer);
        var changes = await _customerDbContext.SaveChangesAsync();

        return changes > 0;
    }
}
