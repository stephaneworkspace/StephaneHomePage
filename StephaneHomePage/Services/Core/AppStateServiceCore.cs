using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Services.Core
{
    public class AppStateServiceCore
    {
        public Func<string, Task> OnChange;
        public string Title { get; set; }

        public async Task ChangeTitle(string title)
        {
            await OnChangeTitle(title);
        }

        private async Task OnChangeTitle(string title)
        {
            Title = title;
            await OnChange?.Invoke(title);
        }
    }
}
