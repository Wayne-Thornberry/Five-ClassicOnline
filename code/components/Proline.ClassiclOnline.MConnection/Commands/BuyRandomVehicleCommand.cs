﻿using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CDataStream;
using Proline.ClassicOnline.CGameLogic;
using Proline.Resource.Framework;
using System;

namespace Proline.ClassicOnline.CNetConnection.Commands
{
    public class BuyRandomVehicleCommand : ResourceCommand
    {
        public BuyRandomVehicleCommand() : base("BuyRandomVehicle")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {

            if (CGameLogicAPI.GetCharacterBankBalance() > 250)
            {
                if (CGameLogicAPI.HasCharacter())
                {
                    if (CGameLogicAPI.GetPersonalVehicle() != null)
                    {
                        CGameLogicAPI.DeletePersonalVehicle();
                    }


                    CGameLogicAPI.SetCharacterBankBalance(250);
                    Array values = Enum.GetValues(typeof(VehicleHash));
                    Random random = new Random();
                    VehicleHash randomBar = (VehicleHash)values.GetValue(random.Next(values.Length));
                    var task = World.CreateVehicle(new Model(randomBar), World.GetNextPositionOnStreet(Game.PlayerPed.Position));
                    task.ContinueWith(e =>
                    {
                        var vehicle = e.Result;
                        CGameLogicAPI.SetCharacterPersonalVehicle(vehicle.Handle);

                        var id = "PlayerVehicle";
                        var dataAPI = new CDataStreamAPI();
                        dataAPI.CreateDataFile();
                        dataAPI.AddDataFileValue("VehicleHash", vehicle.Model.Hash);
                        dataAPI.AddDataFileValue("VehiclePosition", JsonConvert.SerializeObject(vehicle.Position));
                        vehicle.IsPersistent = true;
                        if (vehicle.AttachedBlips.Length == 0)
                            vehicle.AttachBlip();
                        dataAPI.SaveDataFile(id);

                    });
                }


            }
        }
    }
}
