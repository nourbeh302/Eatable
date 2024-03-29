﻿using AutoMapper;
using Eatable.Areas.Identity.Data;
using Eatable.Repository;
using Eatable.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eatable.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepositoryBase<ApplicationUser, string> _userRepository;
        private readonly IMapper _mapper;
        public UserController(IRepositoryBase<ApplicationUser, string> userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        // GET: UserController
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            List<ApplicationUser> users = _userRepository.List().Where(x => !x.Email.Contains("admin")).ToList();
            List<UserTable> usersTable = _mapper.Map<List<UserTable>>(users);
            return View(usersTable);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
