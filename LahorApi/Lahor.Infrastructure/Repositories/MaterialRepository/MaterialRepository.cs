using AutoMapper;
using Lahor.Core.Dto.Material;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.MaterialRepository
{
    public class MaterialRepository : BaseRepository<Material, int>, IMaterialRepository
    {
        public MaterialRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<MaterialDto> GetByIdAsync(int id)
        {
            return await ProjectToFirstOrDefaultAsync<MaterialDto>(DatabaseContext.Material.Where(m => m.Id == id));

        }

        public async Task<List<MaterialDto>> GetByName(string name)
        {
            return await ProjectToListAsync<MaterialDto>(DatabaseContext.Material.Where(m => m.Name == name));
        }

        public async Task<List<MaterialDto>> GetAllOrdered(string sortCol, string sortDir, string? nameFilter = null)
        {
            IQueryable<Material> query = DatabaseContext.Material;

            sortCol = char.ToUpper(sortCol[0]) + sortCol.Substring(1);
            List<MaterialDto> materialDtos;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(m => m.Name.Contains(nameFilter));
            }


            _ = sortDir == "asc" ? materialDtos = await ProjectToListAsync<MaterialDto>(query.Where(m => !m.IsDeleted).OrderBy(m => EF.Property<object>(m, sortCol))) :
                materialDtos = await ProjectToListAsync<MaterialDto>(query.Where(m => !m.IsDeleted).OrderByDescending(m => EF.Property<object>(m, sortCol)));

            return materialDtos;

        }

        public async new Task<List<MaterialDto>> GetAllAsync()
        {
            return await ProjectToListAsync<MaterialDto>(DatabaseContext.Material.Where(m => !m.IsDeleted));
        }



    }
}
