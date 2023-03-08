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



    [ObservableProperty]
    private ObservableCollection<CaseModel> caseList = CaseService.CasesList;



}
