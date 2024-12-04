using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic;
using PortfolioApp.Areas.Admin.Models;
using PortfolioApp.Models.Entities;

namespace PortfolioApp.Models.Repositories
{
    public class ProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Project>> GetAllAsync()
        {
            List<Project> projects = await _context.Projects.ToListAsync();
            return projects;

        }
        public async Task<List<Project>> GetAllAsync(bool isDeleted)
        {
            List<Project?> projects = await _context.Projects.
                Where(p => p.IsDeleted == isDeleted).ToListAsync();
            return projects;

        }

        public async Task<Project> GetByIdAsync(int id)
        {
            Project project = await _context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
            return project;
        }
        public async Task<Project> GetByIdAsync(int id,bool isDeleted)
        {
            Project project = await _context.Projects.Where(p => p.Id == id && p.IsDeleted==isDeleted).FirstOrDefaultAsync();
            return project;
        }
        public async Task CreateAsync(AddProjectViewModel addProjectViewModel)
        {
            Project project = new()
            {

                CatgorieId = addProjectViewModel.CatgorieId,
                Description = addProjectViewModel.Description,
                GitHubUrl = addProjectViewModel.GitHubUrl,
                ImageUrl = addProjectViewModel?.ImageUrl,
                SubTitle = addProjectViewModel.SubTitle,
                Team = addProjectViewModel.Team,
                Title = addProjectViewModel.Title,
                Url = addProjectViewModel.Url,
                ZipFileUrl = addProjectViewModel.ZipFileUrl

            };
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateProjectViewModel updateProjectViewModel)
        {
            Project? project = await GetByIdAsync(updateProjectViewModel.Id);
            project.CatgorieId = updateProjectViewModel.CatgorieId;
            project.Description = updateProjectViewModel.Description;
            project.Url = updateProjectViewModel.Url;
            project.ImageUrl = updateProjectViewModel.ImageUrl;
            project.SubTitle= updateProjectViewModel.SubTitle;
            project.GitHubUrl = updateProjectViewModel.GitHubUrl;
            project.Title = updateProjectViewModel.Title;
            project.Team = updateProjectViewModel.Team;
            project.ZipFileUrl = updateProjectViewModel.ZipFileUrl;
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

        }

        public async Task SoftDeleteAsync(int id)
        {
            Project project = await GetByIdAsync(id);  // id ile getir
            project.IsDeleted = !project.IsDeleted; // false ise true yap true ise false yap
            _context.Projects.Update(project); //durumunu güncelle
            await _context.SaveChangesAsync(); //execute et
        }
        public async Task HardDeleteAsync(int id)
        {
            Project? project = await GetByIdAsync(id);  // id ile getir
            _context.Projects.Remove(project); // getirilen id li projeyi sil
            await _context.SaveChangesAsync(); // execute et
        }
    }
}
