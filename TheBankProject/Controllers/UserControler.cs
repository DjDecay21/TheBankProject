using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheBankProject.Entities;
using TheBankProject.Models;

namespace TheBankProject.Controllers
{
    [Route("api/user")]
    public class UserControler : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BankDbContext _dbContext;

        public UserControler(BankDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult AddUser([FromBody] AddUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Created($"/api/user/{user.Id}",null);
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var users = _dbContext
                .Users
                .Include(r=>r.Accounts)
                .ToList();

            var usersDtos = _mapper.Map<List<UserDto>>(users);

            return Ok(usersDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get([FromRoute] int id)
        {
            var user = _dbContext
                .Users
                .Include(r => r.Accounts)
                .FirstOrDefault(u => u.Id == id);

            if(user == null)
            {
                return NotFound();
            }
            var usersDto = _mapper.Map<UserDto>(user);
            return Ok(usersDto);
        }
    }
}
