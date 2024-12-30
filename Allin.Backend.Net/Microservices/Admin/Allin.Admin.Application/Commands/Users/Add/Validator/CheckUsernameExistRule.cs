using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;

namespace Allin.Admin.Application.Commands
{
    public class CheckUsernameExistRule : IBusinessRuleValidator<AddUserCommand>
    {
        protected readonly AdminDbContext _dbContext;

        public CheckUsernameExistRule(AdminDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BusinessRuleResult> ValidateAsync(AddUserCommand command)
        {
            var userExist = false;
            //var userExist=_dbContext.Users.AnyAsync(x=>x.Username==command.Username);

            return BusinessRuleResult.Create(userExist, $"Username is already exist");

        }
    }

}