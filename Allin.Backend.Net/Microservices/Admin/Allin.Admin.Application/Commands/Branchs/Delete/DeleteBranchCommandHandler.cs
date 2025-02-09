﻿using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteBranchCommandHandler : AdminCommandHandler<DeleteBranchCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteBranchCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var Branch = await DbContext.Departments.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.Departments.Remove(Branch);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
