using MediatR;

namespace Application.Operations.Commands.BugCreate
{
    public class BugCreateCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reproduce { get; set; }
        public string Environment { get; set; }
        public string SuggestionForFix { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int ProjectVersionId { get; set; }
    }
}