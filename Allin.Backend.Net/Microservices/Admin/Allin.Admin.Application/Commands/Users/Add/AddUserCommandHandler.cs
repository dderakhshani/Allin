using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allin.Common;
using Allin.Common.Data;
using Allin.Common.Utilities;
using Allin.Common.Web;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class AddUserCommandHandler : BaseCommandHandler<AddUserCommand>
    {

        public AddUserCommandHandler(
            BaseDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        {

        }

        public override async Task<GeneralApiResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
           
            // Add user logic goes here

            return GeneralApiResult.Ok();
        }

    }
}
