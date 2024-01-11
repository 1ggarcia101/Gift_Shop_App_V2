using System;
using System.Threading.Tasks;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;


namespace SS.Template.Application.Features.Positions.Commands
{
    internal static class PositionsCommandHandlerExtensions
    {
        public static async Task<Position> FindEnabledPosition(this IRepositoryBase repository, Guid id)
        {
            var entity = await repository.SingleAsync<Position>(x => x.Id == id && x.Status == EnabledStatus.Enabled);
            if (entity == null)
            {
                throw EntityNotFoundException.For<Position>(id);
            }

            return entity;
        }
    }
}
