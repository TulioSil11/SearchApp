using SearchApp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace SearchApp.ViewModels;

public class ConsignedCreditFormViewModel
{
    [Required(ErrorMessage = "Name is required!")]
    public string NameOfUser { get; set; }
    [Required(ErrorMessage = "CPF is required!")]
    public string CPF { get; set; }
    [Required(ErrorMessage = "Phone is required!")]
    public string Phone { get; set; }
    public List<QuestionViewModel> Questions { get; set; }

    public (bool, string) IsValid()
    {
        if (string.IsNullOrEmpty(NameOfUser)) return (false, "Name is required!");
        if (string.IsNullOrEmpty(CPF)) return (false, "CPF is required!");
        if (!CPFExtensions.IsValidCPF(CPF)) return (false, "CPF is invalid!");
        if (string.IsNullOrEmpty(Phone)) return (false, "Phone is required!");
        if (!PhoneExtensions.IsValidPhone(Phone)) return (false, "Phone is invalid!");
        else return (true, "");
    }
}
