namespace super_ticketing_backend.Dto_s;

public class TicketCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReportDate { get; set; }
    public string Status { get; set; }
    public string Country { get; set; }
    public string Priority { get; set; }
    public string Photo { get; set; }
    public string UserId { get; set; }
}
