﻿using CitizenFX.Core; 
using Proline.ClassicOnline.CCoreSystem.Events;
using Proline.ClassicOnline.CCoreSystem.Internal;
using Proline.ClassicOnline.CScriptObjs.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CScriptObjs.Scripts
{
    public class InitSession
    {
        public async Task Execute()
        {
            var gc = new ProcessScriptObjs();
            while (true)
            {
                var task = Task.Factory.StartNew(gc.Execute);
                await BaseScript.Delay(1000);
            }
        }
    }
}
