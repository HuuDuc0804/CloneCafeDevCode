using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthor, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteAuthorHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResult> Handle(DeleteAuthor request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();
            try
            {
                var author = database.Authors.FirstOrDefault(x => x.Id == request.Id);
                if (author != null)
                {
                    author.MaskDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Authors.Update(author);
                    database.SaveChanges();
                    result.Success = true;
                }
                else
                {
                    result.Messages = $"Can't find author ID is {request.Id}";
                }
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
