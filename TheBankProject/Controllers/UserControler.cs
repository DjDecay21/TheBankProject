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

        [HttpPost("/api/user/{id}/transaction")]
        public ActionResult AddTransaction([FromBody] TransferDto dto, int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u=> u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var newTransaction = _mapper.Map<Transaction>(dto);
            _dbContext.Transactions.Add(newTransaction);
            _dbContext.SaveChanges();
            return Created($"/api/transaction/{id}", null);
        }
        public UserControler(BankDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        [HttpPost("/api/user/{id}/create")]
        public ActionResult<Account> CreateAccount( int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("Użytkownik o podanym identyfikatorze nie istnieje.");
            }
            var newAccount = new Account
            {
                Value = 0.0m,
                UserId = id
            };
            var newAccountMapping = _mapper.Map<Account>(newAccount);
            _dbContext.Accounts.Add(newAccountMapping);
            _dbContext.SaveChanges();
            return Created($"/api/user/{user.Id}",null);
        }
        [HttpGet("/api/transaction/{id}")]
        public ActionResult<TransactionDto> Transaction([FromRoute] int id)
        {
            var transaction = _dbContext
                .Transactions
                .Where(u => u.FromAccountId == id || u.ToAccountId == id)
                .ToList();


            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
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
