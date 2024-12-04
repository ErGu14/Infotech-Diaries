using System;

namespace PortfolioApp.Models.Entities;

public interface IEntity
{
    public bool IsDeleted {get;set;}
}
