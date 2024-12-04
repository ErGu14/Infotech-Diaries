using System;

namespace PortfolioApp.Models.Entities;

public interface IDatesEntity // date alanlarını eklemek istediğimiz entitylere eklicez
{
    public DateTime CreatedAt {get;set;}
	public DateTime? UpdatedAt {get;set;}
}
