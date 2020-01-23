using Budget.Data;
using Budget.Helpers;
using Budget.Models;
using Budget.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace Budget.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly BudgetContext _context;

        public AuthController()
        {
            _context = new BudgetContext();
        }

        [HttpPost, Route("register")]
        public IHttpActionResult Register(Register register)
        {
            if (_context.Users.Any(u => u.Email == register.Email))
            {
                ModelState.AddModelError("Email", "Bu E-poçt artıq qeydiyyatdan keçib");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User
            {
                Fullname = register.FullName,
                Password = Crypto.HashPassword(register.Password),
                Email = register.Email,
                CreatedAt = DateTime.Now,
                Token = Guid.NewGuid().ToString()
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new
            {
                user.Token
            });
        }

        [HttpPost, Route("login")]
        public IHttpActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = _context.Users.FirstOrDefault(f => f.Email == login.Email);

            if (user != null)
            {
                if (Crypto.VerifyHashedPassword(user.Password, login.Password))
                {
                    user.Token = Guid.NewGuid().ToString();

                    _context.SaveChanges();

                    return Ok(new
                    {
                        user.Token
                    });
                }
            }

            return NotFound();
        }

        [HttpGet, Route("logout")]
        [Auth]
        public IHttpActionResult Logout()
        {
            string token = Request.Headers.GetValues("token").First().ToString();

            User user = _context.Users.FirstOrDefault(u => u.Token == token);

            user.Token = null;

            _context.SaveChanges();

            return Ok();
        }

    }
}
