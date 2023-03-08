using CaseManagerApp.MVVM.Models;
using CaseManagerApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CaseManagerApp.MVVM.ViewModels;

public partial class CasesViewModel : ObservableObject
{

    [ObservableProperty]
    private string title = "Cases";

    [ObservableProperty]
    private ObservableCollection<CaseModel> caseList = new ObservableCollection<CaseModel>();

public async Task LoadMyData(CaseModel caseModel)
    {
        CaseList = (ObservableCollection<CaseModel>)await CaseService.GetAllAsync();
    }






}
