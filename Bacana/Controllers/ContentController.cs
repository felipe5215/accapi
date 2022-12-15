using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bacana.Context;
using Bacana.Models;

namespace Bacana.Controllers;

[Route("[controller]")]
public class ContentController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Post>> Get()
    {
        var content = _context.Post.AsNoTracking().Take(10).ToList();
        if (content is null)
        {
            return NotFound("No content found");
        }
        return content;
    }

    [HttpGet("{id:int}", Name = "GetContent")]
    public ActionResult<Post> Get(int id)
    {
        var content = _context.Post.FirstOrDefault(p => p.PostId == id);
        if (content is null)
        {
            return NotFound("Content not found");
        }
        return content;
    }

    [HttpGet("User")]
    public ActionResult<IEnumerable<Post>> GetPostsByStudentId(int id)
    {
        var content = _context.Post.Where(x => x.UserId == id).AsNoTracking().ToList();
        if (content is null)
        {
            return NotFound("No posts found");
        }
        return content;
    }

    [HttpPost]
    public ActionResult Post(Post content)
    {
        if (content is null)
        {
            return BadRequest("invalid content");
        }
        _context.Post.Add(content);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetContent", new { id = content.PostId }, content);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Post content)
    {
        if (id != content.PostId)
        {
            return BadRequest("invalid id");
        }

        _context.Entry(content).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(content);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var content = _context.Post.FirstOrDefault(p => p.PostId == id);
        if (content is null)
        {
            return NotFound("Content not found");
        }
        _context.Post.Remove(content);
        _context.SaveChanges();
        return Ok(content);
    }
}
