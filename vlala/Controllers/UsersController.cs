﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotherHood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Controllers
{
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: UsersController
        public async Task<ActionResult> IndexAsync()
        {
            var applicationDbContext = _context.Users.Include(user => user.Megye);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> DetailsAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(m => m.Megye)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}
