using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton { get; set; }
        [Inject] TransientService transient { get; set; }
        [Inject] IJSRuntime js { get; set; }

        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount()
        {
            currentCount++;
            transient.Value = currentCount;
            singleton.Value = currentCount;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }

        private async Task IncrementCountJavaScript()
        {
            await js.InvokeVoidAsync("dotnetInstanceInvocation", 
                DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }


        private List<Movie> movies;
        // protected async override Task OnInitializedAsync()
        protected override void OnInitialized()
        {
            //await Task.Delay(3500);
            movies = new List<Movie>()
            {
                new Movie(){Taitel = "JOker", RilisDet = new DateTime(2019, 7,2)},
                new Movie(){Taitel = "Avengers", RilisDet = new DateTime(2016, 11,23)},
                new Movie(){Taitel = "Inception", RilisDet = new DateTime(2010,7,16)}
            };
        }
    }
}
