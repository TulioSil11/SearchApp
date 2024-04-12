using SearchApp.Models;
using SearchApp.Models.Context;

namespace SearchApp.SeedData;

public class SeedService
{
    private readonly MyContext _myContext;

    public SeedService(MyContext myContext)
    {
        _myContext = myContext;
    }

    public void Seed()
    {
        if (!_myContext.Question.Any())
        {
            List<Question> questions = new();
            var question1 = new Question();
            question1.Id = Guid.NewGuid();
            question1.Description = "1. Qual sua faixa de Idade:";
            question1.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question1.Id, Option.A, "a. Até 30 Anos"),
                new QuestionOption(question1.Id, Option.B, "b. De 30 a 50 anos"),
                new QuestionOption(question1.Id, Option.C, "c. De 50 a 65 anos"),
                new QuestionOption(question1.Id, Option.D, "d. Acima de 65 anos"),
            };

            var question2 = new Question();
            question2.Id = Guid.NewGuid();
            question2.Description = "2. Qual seu convênio:";
            question2.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question2.Id, Option.A, "a. INSS"),
                new QuestionOption(question2.Id, Option.B, "b. SIAPE"),
                new QuestionOption(question2.Id, Option.C, "c. Forças Armadas"),
                new QuestionOption(question2.Id, Option.D, "d. Outros"),
            };

            var question3 = new Question();
            question3.Id = Guid.NewGuid();
            question3.Description = "3. Qual sua faixa salarial:";
            question3.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question3.Id, Option.A, "a. Até 2 SM"),
                new QuestionOption(question3.Id, Option.B, "b. De 2 a 4 SM"),
                new QuestionOption(question3.Id, Option.C, "c. De 4 a 6 SM"),
                new QuestionOption(question3.Id, Option.D, "d. Acima de 6 SM"),
            };

            var question4 = new Question();
            question4.Id = Guid.NewGuid();
            question4.Description = "4. Por que você realizou o empréstimo:";
            question4.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question4.Id, Option.A, "a. Pagar contas"),
                new QuestionOption(question4.Id, Option.B, "b. Reforma da Casa"),
                new QuestionOption(question4.Id, Option.C, "c. Compra de Carro"),
                new QuestionOption(question4.Id, Option.D, "c. Compra de Carro"),
            };

            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);
            questions.Add(question4);

            _myContext.Question.AddRange(questions);
            _myContext.SaveChanges();
        }
    }
}
