using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace Cinder;

public static class SwaggerExtensions
{
  public static void SaveSwaggerYaml(this IServiceProvider provider)
  {
    ISwaggerProvider sw = provider.GetRequiredService<ISwaggerProvider>();
    var doc = sw.GetSwagger("v1", null, "/");
    var swaggerFile = doc.SerializeAsYaml(Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0);
    File.WriteAllText("swaggerfile.yaml", swaggerFile);
  }
}
