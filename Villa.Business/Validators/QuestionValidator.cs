using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class QuestionValidator:AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Quest).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Quest).MaximumLength(200).WithMessage("Maksimum 200 Karakter Soru girin ");
            RuleFor(x => x.Answer).MaximumLength(200).WithMessage("Maksimum 200 Karakter Cevap girin ");
            RuleFor(x => x.Quest).MinimumLength(10).WithMessage("Minimum 10 Karakter Soru girin ");
            RuleFor(x => x.Answer).MinimumLength(10).WithMessage("Minimum 10 Karakter Cevap girin ");
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");

        }
    }
}
