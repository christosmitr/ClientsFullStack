using ClientsAPI.Data;
using ClientsAPI.Models.Domain;
using ClientsAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientDbContext _dbContext;

        public ClientController(ClientDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       

         // GET api/clients
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Client>>> GetClients()
         {
            var clients = await _dbContext.Clients.Include(c => c.Phones).ToListAsync();
            return Ok(clients);
         }

         // GET api/clients/{id}
         [HttpGet("{id}")]
         public async Task<ActionResult<Client>> GetClient(Guid id)
         {
            var client = await _dbContext.Clients.Include(c => c.Phones).FirstOrDefaultAsync(c => c.Id == id);
            
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
         }

         // POST api/clients
         [HttpPost]
         public async Task<ActionResult<Client>> CreateClient(ClientDTO clientDto)
         {
            var id = new Guid();

            var client = new Client
            {
                Id = id,
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Phones = new Phones
                {
                    Id = id,
                    HomePhone = clientDto.Phones.HomePhone,
                    WorkPhone = clientDto.Phones.WorkPhone,
                    MobilePhone = clientDto.Phones.MobilePhone

                },
                Address = clientDto.Address,
                Email = clientDto.Email
            };

             _dbContext.Clients.Add(client);
             await _dbContext.SaveChangesAsync();

            return Ok(client);
         }

         // PUT api/clients/{id}
         [HttpPut("{id}")]
         public async Task<IActionResult> UpdateClient(Guid id, ClientDTO clientDto)
         {
            var client = await _dbContext.Clients.FindAsync(id);
            var phones = await _dbContext.Phones.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            phones.HomePhone = clientDto.Phones.HomePhone;
            phones.WorkPhone = clientDto.Phones.WorkPhone;
            phones.MobilePhone = clientDto.Phones.MobilePhone;
            
            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.Phones = phones;
            client.Address = clientDto.Address;
            client.Email = clientDto.Email;

            await _dbContext.SaveChangesAsync();
            return Ok(client);
         }

         // DELETE api/clients/{id}
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteClient(Guid id)
         {
            var client = await _dbContext.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
            return NoContent();
         }
        

    }
}
