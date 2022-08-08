﻿using CitizenFX.Core;
using CitizenFX.Core.UI;
using Newtonsoft.Json;
using Proline.ClassicOnline.CGameLogic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Proline.CFXExtended.Core;
using CitizenFX.Core.Native;


namespace Proline.ClassicOnline.SClassic
{
    public class SaveNow
    {

        public async Task Execute(object[] args, CancellationToken token)
        {
            // Dupe protection
            if (CCoreSystem.CCoreSystemAPI.GetInstanceCountOfScript("SaveNow") > 1)
                return;
            Screen.LoadingPrompt.Show("Saving...", LoadingSpinnerType.SocialClubSaving); 
            await CDataStream.API.SendSaveToCloud();
            await BaseScript.Delay(1000);
            Screen.LoadingPrompt.Hide();
        }
    }
}
