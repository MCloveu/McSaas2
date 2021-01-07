using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using McSaas.Authorization;

namespace McSaas.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class McSaasNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                            )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"
                    )
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "Control",
                        L("Control"),
                        icon: "fas fa-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            "WorkDesk",
                            L("WorkDesk"),
                            icon: "far fa-circle"
                        )
                    )
                )
                .AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "OwnerManagement",
                        L("OwnerManagement"),
                        icon: "fas fa-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            "Community",
                            new FixedLocalizableString("Community"),
                           // L("Community"),
                            icon: "far fa-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "Gallery",
                            L("Gallery"),
                            icon: "far fa-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "House",
                            L("House"),
                            icon: "far fa-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "Owner",
                            L("Owner"),
                            icon: "far fa-circle"
                        )
                    )
                );
        }
        
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, McSaasConsts.LocalizationSourceName);
        }
    }
}