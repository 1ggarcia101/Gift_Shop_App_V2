using System;
using System.Threading.Tasks;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;


namespace SS.Template.Application.Features.Interviews.Commands
{
    internal static class InterviewsCommandHandlerExtensions
    {
        public static async Task<Interview> FindEnabledPosition(this IRepositoryBase repository, Guid id)
        {
            var entity = await repository.SingleAsync<Interview>(x => x.Id == id && x.Status == EnabledStatus.Enabled);
            if (entity == null)
            {
                throw EntityNotFoundException.For<Interview>(id);
            }

            return entity;
        }
    }
}
