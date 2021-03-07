using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Bug> Bugs { get; set; }
        DbSet<DomainTask> Tasks { get; set; }
        DbSet<Note> Notes { get; set; }
        DbSet<Priority> Priorities { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectGroup> ProjectGroups { get; set; }
        DbSet<ProjectVersion> ProjectVersions { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<UserGroup> UserGroups { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}