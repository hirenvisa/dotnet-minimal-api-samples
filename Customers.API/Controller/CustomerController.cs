using Customers.API.Contracts;
using Customers.API.Domain;
using Customers.API.Service;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controller;

[ApiController]
[Route("/api")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService customerService;
    private readonly IMapper mapper;

    public CustomerController(CustomerService customerService, IMapper mapper)
    {
        this.customerService = customerService;
        this.mapper = mapper;
    }

    [HttpGet("customers/{id:guid}")]
    public async Task<IActionResult> Get([FromRoute]Guid id)
    {
        var customer = await customerService.GetAsync(id);
        return Ok(customer);
    }

    [HttpGet("customers")]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var customers = await customerService.GetAllAsync();
        var customerResponse = mapper.Map<List<CustomerResponse>>(customers);
        return Ok(customerResponse);
    }


    [HttpPost("customers")]
    public async Task<IActionResult> CreateAsync([FromBody] CustomerRequest customerRequest)
    {
        var customer = mapper.Map<Customer>(customerRequest);
        var created = await customerService.CreateAsync(customer);
        var customerResponse = mapper.Map<CustomerResponse>(customer);
        return CreatedAtAction("Create", new { customerResponse });
    }

    [HttpPut("customers/{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerRequest customerRequest)
    {
        var existingCustomer = await customerService.GetAsync(customerRequest.Id);
        if(existingCustomer is null)
        {
            return NotFound();
        }
        var customer = mapper.Map<Customer>(customerRequest);
        var created = await customerService.UpdateAsync(customer);
        var customerResponse = mapper.Map<CustomerResponse>(customer);
        return Ok(customerResponse);
    }

    [HttpDelete("customers/{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
    {
        var deleted = await customerService.DeleteAsync(id);
        if(!deleted) return NotFound();
        return Ok();
    }
}
