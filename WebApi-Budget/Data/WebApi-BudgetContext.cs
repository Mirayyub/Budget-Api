using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using WebApi_Budget.Models;

namespace WebApi_Budget.Data
{
    public class WebApi_BudgetContext:DbContext
    {
        public WebApi_BudgetContext() : base("WebApi_BudgetContext")
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}