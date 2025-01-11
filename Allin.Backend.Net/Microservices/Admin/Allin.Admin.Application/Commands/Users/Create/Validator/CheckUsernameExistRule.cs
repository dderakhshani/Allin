using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using Allin.CommonLibrary.Localizations;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class CheckUsernameExistRule : IBusinessRuleValidator<CreateUserCommand>
    {
        private readonly AdminDbContext _dbContext;
        private readonly ILocalizator _localizator;

        public CheckUsernameExistRule(AdminDbContext dbContext, ILocalizator localizator)
        {
            _dbContext = dbContext;
            _localizator = localizator;
        }

        public async Task<BusinessRuleResult> ValidateAsync(CreateUserCommand command)
        {
            var userExist = await _dbContext.Users.AnyAsync(x => x.Username == command.Username);

            return BusinessRuleResult.Create(!userExist, _localizator["UsernameIsDuplicated"]);

        }
    }

}