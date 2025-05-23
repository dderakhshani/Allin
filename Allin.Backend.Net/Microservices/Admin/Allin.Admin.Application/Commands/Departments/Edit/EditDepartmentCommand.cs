﻿using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditDepartmentCommand : IRequest<bool>, IMapFrom<Department, EditDepartmentCommand>
    {
        public required long Id { get; set; }
        public long? ParentId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public long BranchId { get; set; }
        public IEnumerable<long> PositionIds { get; set; }
    }
}
