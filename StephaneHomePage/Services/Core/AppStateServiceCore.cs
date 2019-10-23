using StephaneHomePage.Struct.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Services.Core
{
    public class AppStateServiceCore
    {
        public Func<AppBarStruct, Task> OnChange;
        public AppBarStruct AppBarStruct { get; set; }

        public async Task ChangeStruct(AppBarStruct appBarStruct)
        {
            await OnChangeStruct(appBarStruct);
        }

        private async Task OnChangeStruct(AppBarStruct appBarStruct)
        {
            AppBarStruct = appBarStruct;
            await OnChange?.Invoke(appBarStruct);
        }
    }
}
