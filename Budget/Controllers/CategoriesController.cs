using Budget.Data;
using Budget.Helpers;
using Budget.Models;
using Budget.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Budget.Controllers
{
    [RoutePrefix("api/categories")]
    [Auth]
    public class CategoriesController : ApiController
    {
        private readonly BudgetContext _context;

        public CategoriesController()
        {
            _context = new BudgetContext();
        }

        [HttpGet, Route("")]
        public IHttpActionResult List()
        {
            string token = Request.Headers.GetValues("token").First().ToString();

            User user = _context.Users.FirstOrDefault(u => u.Token == token);

            List<Category> categories = _context.Categories.Where(c => c.UserId == user.Id).ToList();

            var response = categories.Select(c => new
            {
                c.Id,
                c.Name
            }).ToList();

            return Ok(response);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(CategoryAction categoryAction)
        {
            string token = Request.Headers.GetValues("token").First().ToString();

            User user = _context.Users.FirstOrDefault(u => u.Token == token);

            if (_context.Categories.Any(c => c.Name == categoryAction.Name && c.UserId == user.Id))
            {
                ModelState.AddModelError("name", "Bu adda kateqoriyaniz artıq var");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category
            {
                UserId = user.Id,
                Name = categoryAction.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPut,Route("{id}")]
        public IHttpActionResult Edit(int id,CategoryAction categoryAction)
        {
            string token = Request.Headers.GetValues("token").First().ToString();

            User user = _context.Users.FirstOrDefault(u => u.Token == token);

            Category category = _context.Categories.FirstOrDefault(c => c.UserId == user.Id && c.Id == id);

            if (category == null)

            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            category.Name = categoryAction.Name;
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete, Route("{id}")]

        public IHttpActionResult Delete(int id)
        {
            string token = Request.Headers.GetValues("token").First().ToString();

            User user = _context.Users.FirstOrDefault(u => u.Token == token);

            Category category = _context.Categories.FirstOrDefault(c => c.UserId == user.Id && c.Id == id);

            if (category == null)

            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok();

        }


        [HttpGet, Route("{id}")]
        public IHttpActionResult Single(int id)
        {
            string token = Request.Headers.GetValues("token").First().ToString();

            User user = _context.Users.FirstOrDefault(u => u.Token == token);

            Category category = _context.Categories.FirstOrDefault(c => c.UserId == user.Id && c.Id == id);

            if (category == null)

            {
                return NotFound();
            }

            
            return Ok(new { 
            category.Id,
            category.Name
            });

        }
    }
}
