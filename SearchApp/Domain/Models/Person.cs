namespace Domain.Models;

public class Person: BaseEntity
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Phone { get; set; }

    public Person()
    {
    }

    public Person(Guid id, string name, string cpf, string phone, DateTime? dateAdded)
    {
        Id = id;
        Name = name;
        CPF = cpf;
        Phone = phone;
        DateAdded = dateAdded ?? DateTime.UtcNow;
        DateUpdated = DateTime.UtcNow;
    }

    public Person(string name, string cpf, string phone, DateTime? dateAdded): this(Guid.NewGuid(), name, cpf, phone, dateAdded)
    {
    }
}
