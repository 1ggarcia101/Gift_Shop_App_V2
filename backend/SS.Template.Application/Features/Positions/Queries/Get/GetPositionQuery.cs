using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Queries;

namespace SS.Template.Application.Features.Positions.Queries.Get
{
    public class GetPositionQuery : IQuery<PositionsModel>
    {
        public Guid Id { get; }

        public GetPositionQuery(Guid id)
        {
            Id = id;
        }
    }
}
