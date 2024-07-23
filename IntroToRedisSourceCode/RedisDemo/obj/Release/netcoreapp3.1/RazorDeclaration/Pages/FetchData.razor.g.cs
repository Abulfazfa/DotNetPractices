// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RedisDemo.Pages
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using System.Net.Http

#nullable disable
    ;
#nullable restore
#line 2 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 3 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization

#nullable disable
    ;
#nullable restore
#line 4 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms

#nullable disable
    ;
#nullable restore
#line 5 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing

#nullable disable
    ;
#nullable restore
#line 6 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Web

#nullable disable
    ;
#nullable restore
#line 7 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using Microsoft.JSInterop

#nullable disable
    ;
#nullable restore
#line 8 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using RedisDemo

#nullable disable
    ;
#nullable restore
#line 9 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using RedisDemo.Shared

#nullable disable
    ;
#nullable restore
#line 10 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\_Imports.razor"
using Microsoft.Extensions.Caching.Distributed

#nullable disable
    ;
#nullable restore
#line 3 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
 using RedisDemo.Data

#nullable disable
    ;
#nullable restore
#line 4 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
 using RedisDemo.Extensions

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Components.RouteAttribute(
    // language=Route,Component
#nullable restore
#line 1 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
      "/fetchdata"

#line default
#line hidden
#nullable disable
    )]
    #nullable restore
    public partial class FetchData : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 49 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;
    private string loadLocation = "";
    private string isCacheData = "";

    private async Task LoadForecast()
    {
        forecasts = null;
        loadLocation = null;

        string recordKey = "WeatherForecast_" + DateTime.Now.ToString("yyyyMMdd_hhmm");

        forecasts = await cache.GetRecordAsync<WeatherForecast[]>(recordKey);

        if (forecasts is null)
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);

            loadLocation = $"Loaded from API at { DateTime.Now }";
            isCacheData = "";

            await cache.SetRecordAsync(recordKey, forecasts);
        }
        else
        {
            loadLocation = $"Loaded from the cache at { DateTime.Now }";
            isCacheData = "text-danger";
        }
    }

#line default
#line hidden
#nullable disable

        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 6 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
        IDistributedCache

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 6 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
                          cache

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 5 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
        WeatherForecastService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 5 "C:\Users\HP\source\DotNetPractices\IntroToRedisSourceCode\RedisDemo\Pages\FetchData.razor"
                               ForecastService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
    }
}
#pragma warning restore 1591