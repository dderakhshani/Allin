using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;

namespace Allin.Admin.Application.Commands.Users.Add.Validator
{
    public class CheckUsernameExistBusinessRule : IBusinessRuleValidator<AddUserCommand>
    {
        protected readonly AdminDbContext _dbContext;

        public CheckUsernameExistBusinessRule(AdminDbContext dbContext)
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