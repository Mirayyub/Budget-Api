using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Budget.Data;
using WebApi_Budget.Models;
using WebApi_Budget.ViewModel;

namespace WebApi_Budget.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        
        private readonly WebApi_BudgetContext _context;

        public AuthController()
        {
            _context = new WebApi_BudgetContext();
        }

        [HttpPost,Route("register")]
        public IHttpActionResult Register(Register register)
        {
            return Ok("auth/register");
        }
    }
}
