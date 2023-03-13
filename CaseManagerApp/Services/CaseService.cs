using CaseManagerApp.Contexts;
using CaseManagerApp.MVVM.Models;
using CaseManagerApp.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagerApp.Services;

public static class CaseService
{

    static CaseService()
    {
        
    }

    private static DataContext _context = new DataContext();


    public static async Task SaveAsync(CaseModel caseModel)
    {
        var _caseEntity = new CaseEntity
        {
            Description = caseModel.Description,
            Created = caseModel.Created,
            Status = caseModel.Status
        };

        var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == caseModel.StreetName && x.PostalCode == caseModel.PostalCode && x.City == caseModel.City);
        var _tenantEntity = await _context.Tenants.FirstOrDefaultAsync(t => t.Email == caseModel.Email);

        if (_addressEntity == null)
        {
            _addressEntity = new AddressEntity
            {
                StreetName = caseModel.StreetName,
                PostalCode = caseModel.PostalCode,
                City = caseModel.City
            };
            _context.Add(_addressEntity);
            await _context.SaveChangesAsync();
        }

        if (_tenantEntity != null)
        {
            _caseEntity.TenantId = _tenantEntity.TenantId;
            _tenantEntity.AddressId = _addressEntity.Id;
        }
        else
        {
            _caseEntity.Tenant = new TenantEntity
            {
                FirstName = caseModel.FirstName,
                LastName = caseModel.LastName,
                Email = caseModel.Email,
                PhoneNumber = caseModel.PhoneNumber,
                AddressId = _addressEntity.Id
            };
        }

        _context.Add(_caseEntity);
        await _context.SaveChangesAsync();
      
    }

    // BACKUP METHOD
/*    public static async Task SaveAsync(CaseModel caseModel)
    {
        var _caseEntity = new CaseEntity
        {
            Description = caseModel.Description,
            Created = caseModel.Created,
            Status = caseModel.Status
        };

        var _tenantEntity = await _context.Tenants.FirstOrDefaultAsync(t => t.Email == caseModel.Email);
        if (_tenantEntity != null)
        {
            _caseEntity.TenantId = _tenantEntity.TenantId;
        }
        else
        {
            _caseEntity.Tenant = new TenantEntity
            {
                FirstName = caseModel.FirstName,
                LastName = caseModel.LastName,
                Email = caseModel.Email,
                PhoneNumber = caseModel.PhoneNumber
            };
        }

        _context.Add(_caseEntity);
        await _context.SaveChangesAsync();
    }*/


    public static async Task AddCommentAsync(CaseCommentEntity caseComment)
    {
            _context.Add(caseComment);
            _context.SaveChanges();
        
    }


    /*    public static async Task<IEnumerable<CaseModel>> GetAllAsync()
        {
            var cases = new List<CaseModel>();

            foreach (var x in await _context.Cases.Include(y => y.Tenant).ToListAsync())
                cases.Add(new CaseModel
                {
                    CaseId = x.CaseId,
                    Description = x.Description,
                    Created = x.Created,
                    Status = x.Status,
                    FirstName = x.Tenant.FirstName,
                    LastName = x.Tenant.LastName,
                    Email = x.Tenant.Email,
                    PhoneNumber = x.Tenant.PhoneNumber
                });

            return cases;


        }*/

    //testing with LINQ. same as above
    public static async Task<IEnumerable<CaseModel>> GetAllAsync()
    {
        return await _context.Cases.Include(y => y.Tenant)
            .Select(x => new CaseModel
            {
                CaseId = x.CaseId,
                Description = x.Description,
                Created = x.Created,
                Status = x.Status,
                FirstName = x.Tenant.FirstName,
                LastName = x.Tenant.LastName,
                Email = x.Tenant.Email,
                PhoneNumber = x.Tenant.PhoneNumber,
                Comments = x.Comments.ToList<CaseCommentEntity>()
            })
            .ToListAsync();
    }

    public static Task<CaseModel> UpdateAsync()
    {
        return null!;
    }


}



