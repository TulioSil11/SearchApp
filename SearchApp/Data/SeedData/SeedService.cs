using Data.Models.Context;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace SearchApp.SeedData;

public class SeedService
{
    private readonly MyContext _myContext;

    public SeedService(MyContext myContext)
    {
        _myContext = myContext;
    }

    public async Task Seed()
    {
        if (!(_myContext.Question).Any())
        {
            var question1 = new Question("1. Qual sua faixa de Idade:", new List<QuestionOption>(), null);
            question1.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question1.Id, Option.A, "a. Até 30 Anos", false, null),
                new QuestionOption(question1.Id, Option.B, "b. De 30 a 50 anos", false, null),
                new QuestionOption(question1.Id, Option.C, "c. De 50 a 65 anos", false, null),
                new QuestionOption(question1.Id, Option.D, "d. Acima de 65 anos", false, null),
            };

            var question2 = new Question("2. Qual seu convênio:", new List<QuestionOption>(), null);
            question2.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question2.Id, Option.A, "a. INSS", false, null),
                new QuestionOption(question2.Id, Option.B, "b. SIAPE", false, null),
                new QuestionOption(question2.Id, Option.C, "c. Forças Armadas", false, null),
                new QuestionOption(question2.Id, Option.D, "d. Outros", false, null),
            };

            var question3 = new Question("3. Qual sua faixa salarial:", new List<QuestionOption>(), null);
            question3.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question3.Id, Option.A, "a. Até 2 SM", false, null),
                new QuestionOption(question3.Id, Option.B, "b. De 2 a 4 SM", false, null),
                new QuestionOption(question3.Id, Option.C, "c. De 4 a 6 SM", false, null),
                new QuestionOption(question3.Id, Option.D, "d. Acima de 6 SM", false, null),
            };

            var question4 = new Question("4. Por que você realizou o empréstimo:", new List<QuestionOption>(), null);
            question4.QuestionOptions = new List<QuestionOption>
            {
                new QuestionOption(question4.Id, Option.A, "a. Pagar contas", false, null),
                new QuestionOption(question4.Id, Option.B, "b. Reforma da Casa", false, null),
                new QuestionOption(question4.Id, Option.C, "c. Compra de Carro", false, null),
                new QuestionOption(question4.Id, Option.D, "d. Outras", false, null),
            };

            _myContext.Question.Add(question1);
            _myContext.Question.Add(question2);
            _myContext.Question.Add(question3);
            _myContext.Question.Add(question4);
            _myContext.SaveChanges();
        }
    }
}
