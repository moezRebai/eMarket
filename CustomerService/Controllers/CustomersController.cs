using AutoMapper;
using CustomerService.Dtos;
using CustomerService.Models;
using CustomerService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllCustomer()
        {
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(await _customerRepository.GetAll()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomerById(int id)
        {
            return Ok(_mapper.Map<CustomerReadDto>(await _customerRepository.GetCustomerById(id)));
        }

        [HttpPost]
        public ActionResult<CustomerReadDto> AddCustomer(CustomerCreateDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.AddCustomer(customer);
            _customerRepository.SaveChanges();

            var readDto = _mapper.Map<CustomerReadDto>(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { Id = readDto.Id }, readDto);
        }
    }
}
