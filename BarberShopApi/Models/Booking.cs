using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShopApi.Models;

public class Booking
{
    [Key]
    public int Id { get; set; }

    public required DateOnly Date { get; set; }

    public required TimeOnly Time { get; set; }

    [ForeignKey("Customer")]
    public int CustomerIdFk { get; set; }
    public virtual required Customer Customer { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeIdFk { get; set; }
    public virtual required Employee Employee { get; set; }
}