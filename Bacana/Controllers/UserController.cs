using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bacana.Context;
using Bacana.Models;

namespace Bacana.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        try
        {
            var user = _context.User.AsNoTracking().ToList();

            if (user is null)
            {
                return NotFound("user not found");
            }

            return user;
        }
        catch (Exception)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database"
            );
        }
    }

    [HttpGet("{id:int}", Name = "ObterEstudante")]
    public ActionResult<User> Get(int id)
    {
        var user = _context.User.FirstOrDefault(s => s.UserId == id);
        if (user is null)
        {
            return NotFound("user not found");
        }

        return user;
    }

    [HttpPost]
    public ActionResult Post(User user)
    {
        if (user is null)
        {
            return BadRequest("invalid user");
        }
        _context.User.Add(user);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetUser", new { id = user.UserId });
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, User user)
    {
        if (id != user.UserId)
        {
            return BadRequest("invalid id");
        }
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var student = _context.User.FirstOrDefault(user => user.UserId == id);
        if (student is null)
        {
            return NotFound("Estudante não encontrado");
        }
        _context.User.Remove(student);
        _context.SaveChanges();
        return Ok(student);
    }
}
