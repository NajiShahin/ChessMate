using FluentValidation;
using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Validators
{
    class GameValidator : AbstractValidator<Game>
    {

        public GameValidator()
        {
            RuleFor(game => game.Name)
                .NotEmpty()
                    .WithMessage("Game name cannot be empty");
            RuleFor(game => game.Moves)
                .NotNull()
                    .WithMessage("PGN cannot be empty");

        }

    }
}
