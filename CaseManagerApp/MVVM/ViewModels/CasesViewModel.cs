using CaseManagerApp.MVVM.Models;
using CaseManagerApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CaseManagerApp.MVVM.ViewModels;

public partial class CasesViewModel : ObservableObject
{



    [ObservableProperty]
    private string title = "Cases";

    [ObservableProperty]
    private CaseModel selectedCase = null!;


    private ObservableCollection<CaseModel> caseList = null!;

    public CasesViewModel()
    {
        _ = LoadAllCasesAsync();
    }

    public async Task LoadAllCasesAsync()
    {
        IEnumerable<CaseModel> cases = await CaseService.GetAllAsync();
        CaseList = new ObservableCollection<CaseModel>(cases);
    }

    public ObservableCollection<CaseModel> CaseList
    {
        get { return caseList; }
        set { SetProperty(ref caseList, value); }
    }


    [ObservableProperty]
    private string? comment;

    [RelayCommand]
    private async Task AddComment()
    {
        var caseId = selectedCase.CaseId;

        await CaseService.AddCommentAsync(new CaseCommentEntity
        {
            CaseId = caseId,
            Text = comment
        });

        selectedCase.Comments?.Add(new CaseCommentEntity
        {
            Text = comment,
        });

        Comment = string.Empty;
    }


}
