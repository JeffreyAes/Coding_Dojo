#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

// if your page requires more than one model
public class MyViewModel
{
public User User {get;set;}

public Wedding Wedding {get;set;}


}