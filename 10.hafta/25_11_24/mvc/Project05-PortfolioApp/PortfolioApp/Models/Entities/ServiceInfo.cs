using System;

namespace PortfolioApp.Models.Entities;

public class ServiceInfo
{
    public int Id {get;set;}
	public string? ServiceTitle {get;set;}
	public string? ServiceText {get;set;}
	public DateTime CreatedAt {get;set;}
	public DateTime UpdatedAt {get;set;}
}
