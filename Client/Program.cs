global using DTHApplication.Shared.Common;
global using DTHApplication.Shared;
global using DTHApplication.Client.Services.ProductServices;
global using DTHApplication.Client.Services.LocalStorageServices;
global using DTHApplication.Client.Services.AuthServices;
global using Microsoft.AspNetCore.Components.Authorization;
using DTHApplication.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ILocalStorageServices, LocalStorageServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, DTHAuthorizationStateProvider>();

await builder.Build().RunAsync();
