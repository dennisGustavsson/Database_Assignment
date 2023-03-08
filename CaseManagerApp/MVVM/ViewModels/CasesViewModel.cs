using CaseManagerApp.MVVM.Models;
using CaseManagerApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.ObjectModel;


namespace CaseManagerApp.MVVM.ViewModels;

public partial class CasesViewModel : ObservableObject
{
    [ObservableProperty]
    private string title = "Cases";



/*    [ObservableProperty]
    private ObservableCollection<CaseModel> casesList = CaseService.GetAllAsync();*/


}
