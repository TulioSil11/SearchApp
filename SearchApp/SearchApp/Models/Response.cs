namespace SearchApp.Models;

public class Response: BaseEntity
{
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    public Guid QuestionOptionId { get; set; }
    public QuestionOption QuestionOption { get; set; }

    public Response(Guid id, Guid personId, Guid questionId, Guid questionOptionId, DateTime? dateAdded)
    {
        Id = id;
        PersonId = personId;
        QuestionId = questionId;
        QuestionOptionId = questionOptionId;
        DateAdded = dateAdded ?? DateTime.UtcNow;
        DateUpdated = DateTime.UtcNow;
    }

    public Response(Guid personId, Guid questionId, Guid questionOptionId, DateTime? dateAdded) : this(Guid.NewGuid(), personId, questionId, questionOptionId, dateAdded)
    { }
}
