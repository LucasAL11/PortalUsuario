using PortalUsuario.Shared;

namespace PortalUsuario.Api;

internal static class ApiUtils
{
    internal static string GetConnectionString(IConfiguration iConfiguration)
    {
        var connectionString =
            iConfiguration.GetSection("AppConfiguration")
                .Get<AppConfigurations>();

        return connectionString?.ConnectionString;
    }
}