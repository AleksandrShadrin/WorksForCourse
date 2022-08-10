#define FILE_RENDER
using AA.Generator.Services.Generator;
using AA.Generator.Services.Render;
using Microsoft.Extensions.DependencyInjection;


var container = new ServiceCollection();


#if FILE_RENDER

container.AddSingleton<IRender, FileRender>();

#else

container.AddSingleton<IRender, ConsoleRender>();

#endif


container.AddSingleton<IGenerator, Generator>();


var serviceProvider = container.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<IGenerator>();

service.Generate();

