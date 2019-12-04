using MatBlazor;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using StephaneHomePage.Model;
using StephaneHomePage.Services.Http;
using StephaneHomePage.Struct.ImportJson;
using System.Net;
using System.Threading.Tasks;

namespace StephaneHomePage.Pages
{
public partial class AstrologiePrint : ComponentBase
{
    [Inject]
    private IAstrologieServiceHttp AstrologieServiceHttp
    {
        get;
        set;
    }
    [Inject]
    private NavigationManager NavigationManager
    {
        get;
        set;
    }
    [Inject]
    private IMatToaster MatToaster
    {
        get;
        set;
    }

    [Parameter]
    public string YearMonthDay
    {
        get;
        set;
    }
    [Parameter]
    public string HourMin
    {
        get;
        set;
    }
    [Parameter]
    public string Lat
    {
        get;
        set;
    }
    [Parameter]
    public string Lng
    {
        get;
        set;
    }

    public ThemeAstralModel Model
    {
        get;
        set;
    }
    public ImportJson data
    {
        get;
        set;
    }

    public bool swLoaded
    {
        get;
        set;
    }

    protected override void OnInitialized()
    {
        this.swLoaded = false;
    }

    protected override async Task OnParametersSetAsync()
    {
        this.Model = new ThemeAstralModel();
        this.Model.year_month_day = YearMonthDay.Replace('-', '/');
        this.Model.hour_min = HourMin;
        this.Model.lat = Lat;
        this.Model.lng = Lng;
        await this.LoadDatas();
    }

    private async Task LoadDatas()
    {
        var response = await AstrologieServiceHttp.GetThemeAstral(Model);
        switch (response.StatusCode)
        {
        case HttpStatusCode.OK:
            string content = await response.Content.ReadAsStringAsync();
            this.data = JsonConvert.DeserializeObject<ImportJson>(content);
            this.swLoaded = true;
            break;
        default:
            this.MatToaster.Add("Impossible de recevoir les données du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
            this.NavigationManager.NavigateTo("/");
            break;
        }
    }
}
}
