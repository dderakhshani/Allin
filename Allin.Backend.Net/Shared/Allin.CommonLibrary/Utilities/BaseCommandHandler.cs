using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allin.Common.Data;
using Allin.Common.Web;
using AutoMapper;
using MediatR;

namespace Allin.Common.Utilities
{

    public abstract class BaseCommandHandler<TRequest> : IRequestHandler<TRequest, GeneralApiResult> where TRequest : IRequest<GeneralApiResult>
    {

        protected readonly BaseDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseCommandHandler(
            BaseDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public abstract Task<GeneralApiResult> Handle(TRequest request, CancellationToken cancellationToken);
    }

}
