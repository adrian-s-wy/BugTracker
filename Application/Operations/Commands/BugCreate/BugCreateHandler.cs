using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Operations.Commands.BugCreate
{
    public class BugCreateHandler : IRequestHandler<BugCreateCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public BugCreateHandler(IApplicationDbContext context, IMediator mediator, ICurrentUserService currentUserService)
        {
            _context = context;
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(BugCreateCommand request, CancellationToken cancellationToken)
        {
            Bug bug = new Bug
            {
                Title = request.Title,
                Description = request.Description,
                Reproduce = request.Reproduce,
                Environment = request.Environment,
                SuggestionForFix = request.SuggestionForFix,
                CreatedAt = DateTime.Now,
                StatusId = request.StatusId,
                PriorityId = request.PriorityId,
                ProjectVersionId = request.ProjectVersionId,
                CreatedById = _currentUserService.UserId
            };

            _context.Bugs.Add(bug);

            await _context.SaveChangesAsync(cancellationToken);

            return bug.Id;
        }
    }
}