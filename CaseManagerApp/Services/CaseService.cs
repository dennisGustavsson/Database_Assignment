using CaseManagerApp.Contexts;
using CaseManagerApp.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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
        var caseEntity = new CaseEntity
        {
            Description = caseModel.Description,
            Created = caseModel.Created,
            Status = caseModel.Status
        };

        var _tenantEntity = await _context.Tenants.FirstOrDefaultAsync(t => t.Email == caseModel.Email);
        if(_tenantEntity != null) 
        { 
            caseEntity.TenantId = _tenantEntity.TenantId;
        } else
        {
            caseEntity.Tenant = new TenantEntity
            {
                FirstName = caseModel.FirstName,
                LastName = caseModel.LastName,
                Email = caseModel.Email,
                PhoneNumber = caseModel.PhoneNumber
            };
        }




        _context.Add(caseEntity);
        await _context.SaveChangesAsync();
    }



    public static async Task<IEnumerable<CaseModel>> GetAllAsync()
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


    }

    public static Task<CaseModel> UpdateAsync()
    {
        return null!;
    }


}



