using CaseManagerApp.MVVM.Models;
using CaseManagerApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CaseManagerApp.MVVM.ViewModels;

public partial class CasesViewModel : ObservableObject
{
    [ObservableProperty]
    private string title = "Cases";




    /* 

Error	CS0029	Cannot implicitly convert type 'System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<CaseManagerApp.MVVM.Models.CaseModel>>' to 'System.Collections.ObjectModel.ObservableCollection<CaseManagerApp.MVVM.Models.CaseModel>'
     */

    [ObservableProperty]
    private ObservableCollection<CaseModel> casesList = null!;

    private async Task LoadCasesAsync()
    {
        var cases = await CaseService.GetAllAsync();
        CasesList = new ObservableCollection<CaseModel>(cases);
    }


}
