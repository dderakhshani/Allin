using Allin.Inventory.Application.Common;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allin.Inventory.Application.Commands.InventoryCategories.Create
{
    public class CreateCategoriesCommandHandler : InventoryCommandHandler<CreateCategoriesCommand, bool>
    {
        public CreateCategoriesCommandHandler(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<InventoryCategory>(request);

            DbContext.InventoryCategories.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
