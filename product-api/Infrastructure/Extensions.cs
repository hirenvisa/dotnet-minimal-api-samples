using product_api.Model;
using System.Security.Cryptography;
using static product_api.Infrastructure.ProductEndpointDefinition;

namespace product_api.Infrastructure;

public static class Extensions
{
    public static void AddEndpointDefinitions(this IServiceCollection services, params Type[] scanMarkers)
    {
        var endpointDefinitions = new List<IEndpointDefinition>();

        foreach ( var marker in scanMarkers )
        {
            endpointDefinitions.AddRange(
                marker.Assembly.ExportedTypes
                    .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsInterface)
                    .Select(Activator.CreateInstance).Cast<IEndpointDefinition>());

            
        }
        foreach( var endpointDef in endpointDefinitions)
        {
            endpointDef.DefineServices(services);
        }

        services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
        foreach ( var def in definitions )
        {
            def.DefineEndpoints(app);
        }
    }
}
