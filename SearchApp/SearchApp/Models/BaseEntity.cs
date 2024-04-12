namespace SearchApp.Models;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateUpdated { get; set; }
    public bool IsDeleted { get; set; }

}
