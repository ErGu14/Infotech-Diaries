using System;
using PortfolioApp.Models.Entities;

namespace PortfolioApp.Models;

public class Message : BaseEntity,IDatesEntity,IEntity
{
    
	public string? Name {get;set;}
	public string? Email {get;set;}
	public string? Subject {get;set;}
	public string? Content {get;set;}
	public bool IsDeleted {get;set;}
	public bool IsRead {get;set;}
	public DateTime SendingDate {get;set;}
	public DateTime ReadingDate {get;set;}
    public DateTime CreatedAt { get ; set ; }
    public DateTime UpdatedAt { get ; set ; }
}
