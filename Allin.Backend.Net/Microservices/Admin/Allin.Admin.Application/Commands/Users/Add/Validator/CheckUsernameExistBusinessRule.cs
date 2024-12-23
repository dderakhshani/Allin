using FluentValidation;
using System;
using System.Linq;
using System.Threading.Tasks;
using Gradient.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Allin.Common.Validations;
using Allin.Common.Data;


namespace Allin.Admin.Application.Commands
{
    public class CheckUsernameExistBusinessRule : IBusinessRuleValidator<AddUserCommand>
    {
        protected readonly BaseDbContext _dbContext;

        public CheckUsernameExistBusinessRule(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BusinessRuleResult> ValidateAsync(AddUserCommand command)
        {
            var userExist=false;
            //var userExist=_dbContext.Users.AnyAsync(x=>x.Username==command.Username);

            return BusinessRuleResult.Create(userExist, $"Username is already exist");

        }
    }

}