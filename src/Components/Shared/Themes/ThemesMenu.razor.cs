using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Practic5.Auth;
using Practic5.Models;

namespace Practic5.Components.Shared.Themes;

public partial class ThemesMenu
{
    private readonly List<string> _primaryColors = new()
    {
        Colors.Green.Default,
        Colors.Blue.Default,
        Colors.BlueGrey.Default,
        Colors.Purple.Default,
        Colors.Orange.Default,
        Colors.Red.Default
    };

    [EditorRequired][Parameter] public bool ThemingDrawerOpen { get; set; }
    [EditorRequired][Parameter] public EventCallback<bool> ThemingDrawerOpenChanged { get; set; }
    [EditorRequired][Parameter] public ThemeManagerModel ThemeManager { get; set; }
    [EditorRequired][Parameter] public EventCallback<ThemeManagerModel> ThemeManagerChanged { get; set; }

    [Inject] private CustomAuthenticationStateProvider AuthStateProvider { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var themeSettings = await AuthStateProvider.GetThemeSettingsAsync();
        if (themeSettings != null)
        {
            ThemeManager.IsDarkMode = themeSettings.IsDarkMode;
            ThemeManager.PrimaryColor = themeSettings.PrimaryColor;
        }
    }

    private async Task UpdateThemePrimaryColor(string color)
    {
        ThemeManager.PrimaryColor = color;
        await AuthStateProvider.UpdateThemeSettingsAsync(ThemeManager);
        await ThemeManagerChanged.InvokeAsync(ThemeManager);
    }

    private async Task ToggleDarkLightMode(bool isDarkMode)
    {
        ThemeManager.IsDarkMode = isDarkMode;
        await AuthStateProvider.UpdateThemeSettingsAsync(ThemeManager);
        await ThemeManagerChanged.InvokeAsync(ThemeManager);
    }
}
