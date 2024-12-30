using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using Allin.CommonLibrary.Localizations;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class CheckUniqueNameRule : IBusinessRuleValidator<AddRoleCommand>
    {
        private readonly AdminDbContext _dbContext;
        private readonly ILocalizator _localizator;

        public CheckUniqueNameRule(AdminDbContext dbContext, ILocalizator localizator)
        {
            _dbContext = dbContext;
            _localizator = localizator;
        }

        public async Task<BusinessRuleResult> ValidateAsync(AddRoleCommand command)
        {
            var roleExist = await _dbContext.Roles.AnyAsync(x => x.UniqueName == command.UniqueName);

            return BusinessRuleResult.Create(!roleExist, _localizator["RoleNameUnique"]);
        }
    }
}
