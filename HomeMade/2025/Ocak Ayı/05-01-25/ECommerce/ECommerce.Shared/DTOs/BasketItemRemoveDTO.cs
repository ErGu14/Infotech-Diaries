using System;

namespace ECommerce.Shared.DTOs;

public class BasketItemRemoveDTO
{
    public int BasketId { get; set; }
    public int ProductId { get; set; }
}
