using System;

namespace ECommerce.Shared.DTOs;

public class BasketItemChangeQuantityDTO
{
    public int BasketItemId { get; set; }
    public int Quantity { get; set; }
}
