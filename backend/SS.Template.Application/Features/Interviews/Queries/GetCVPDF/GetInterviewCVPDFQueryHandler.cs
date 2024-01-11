using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SS.Template.Application.Queries;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.Interviews.Queries.GetCVPDF
{
    public class GetInterviewCVPDFQueryHandler : IQueryHandler<GetInterviewCVPDFQuery, MemoryStream>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;


        public GetInterviewCVPDFQueryHandler(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;

        }

        public async Task<MemoryStream> Handle(GetInterviewCVPDFQuery request, CancellationToken cancellationToken)
        {
            var query = await _readOnlyRepository.FirstAsync<Interview>(x => x.Id == request.Id);
            var filePath = Path.Combine(Directory.GetCurrentDirectory()+"\\Resources\\CV", query.CV);
            if (!File.Exists(filePath))
            {
                throw new ObjectValidationException("User doesn't exist");

            }

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;


            return memory;
        }
    }
}
