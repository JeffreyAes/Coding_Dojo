﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFPractice.Models;

namespace EFPractice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    // Add a private variable of type MyContext (or whatever you named your context file)
    private MyContext _context;         
    // Here we can "inject" our context service into the constructor 
    // The "logger" was something that was already in our code, we're just adding around it   
    public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;    
    }         
    [HttpGet("")]    
    public IActionResult Index()    
    {     
        // Now any time we want to access our database we use _context   
        List<Monster> AllMonsters = _context.Monsters.ToList();
        return View();    
    } 

    [HttpPost("monsters/create")]
public IActionResult CreateMonster(Monster newMon)
{    
    if(ModelState.IsValid)
    {
        // We can take the Monster object created from a form submission
        // and pass the object through the .Add() method  
        // Remember that _context is our database  
        _context.Add(newMon);    
        // OR _context.Monsters.Add(newMon); if we want to specify the table
        // EF Core will be able to figure out which table you meant based on the model  
        // VERY IMPORTANT: save your changes at the end! 
        _context.SaveChanges();
        return RedirectToAction("SomeAction");
    } else {
        // Handle unsuccessful validations
        return RedirectToAction("Index");
    }
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
