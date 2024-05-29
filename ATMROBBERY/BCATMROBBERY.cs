using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using FivePD.API;
using FivePD.API.Utils;
using System.Diagnostics.Eventing.Reader;
using CitizenFX.Core.Native;
using System.Xml.Linq;

#pragma warning disable 1998

namespace ATMRobbery
{
    [CalloutProperties(name: "BCATMROBBERY", author: "Dispatch", version: "0.0.2")]

    public class BCATMROBBERY : Callout
    {
        Ped suspect;

        public BCATMROBBERY()
        {
            Random random = new Random();
            int location = random.Next(1, 90);
            if (location <= 10)
            {
                InitInfo(new Vector3(x: -2975.0969f, y: 380.1656f, z: 14.9990f));//Route 1 Rob's Liquor
            }
            else if (location <= 20 && location > 10)
            {
                InitInfo(new Vector3(x: -3241.2209f, y: 997.4071f, z: 12.5504f));//Barbareno Road 24/7
            }
            else if (location <= 30 && location > 20)
            {
                InitInfo(new Vector3(x: -3043.9734f, y: 594.6616f, z: 7.7367f));//Ineseno Road 24/7
            }
            else if (location <= 40 && location > 30)
            {
                InitInfo(new Vector3(x: -3144.3232f, y: 1127.5074f, z: 20.8554f));//Chumash Plaza Blaine County Savings
            }
            else if (location <= 50 && location > 40)
            {
                InitInfo(new Vector3(x: 155.7926f, y: 6642.8643f, z: 31.6023f));//Great Ocean HWY RON filling station
            }
            else if (location <= 60 && location > 50)
            {
                InitInfo(new Vector3(x: -283.0852f, y: 6226.0688f, z: 31.4932f));//Paleto Blvd
            }
            else if (location <= 70 && location > 60)
            {
                InitInfo(new Vector3(x: -95.3680f, y: 6456.6636f, z: 31.4580f));//Cascabel Avenue Blaine County Bank
            }
            else if (location <= 80 && location > 70)
            {
                InitInfo(new Vector3(x: 1778.1370f, y: 3638.2715f, z: 34.6352f));//Zancudo Avenue
            }
            else
            {
                InitInfo(new Vector3(x:1703.1388f, y: 4933.3867f, z: 42.0637f));//Grapeseed Main Street LTD Gas Station
            }
            ShortName = "ATM Robbery";
            CalloutDescription = "911 Caller reports a suspect trying to break into an ATM.";
            ResponseCode = 3;
            StartDistance = 200f;
        }
        public async override Task OnAccept()
        {
            InitBlip();
            UpdateData();
        }

        public override async void OnStart(Ped player)
        {
            suspect = await SpawnPed(RandomUtils.GetRandomPed(), Location);
            suspect.AlwaysKeepTask = true;
            suspect.BlockPermanentEvents = true;

            base.OnStart(player);
            suspect.Weapons.Give(WeaponHash.Crowbar, 1, true, true);
            await DoAnimation(suspect);
            suspect.Weapons.Give(WeaponHash.Pistol, 255, true, true);
            int chance = new Random().Next(1, 99);
            if (chance < 33)
            {
                suspect.Task.FleeFrom(player);
                suspect.AttachBlip();
            }
            else if (chance >= 33 && chance < 66)
            {
                suspect.Task.FightAgainst(player);
                suspect.AttachBlip();
            }
            else
            {
                suspect.Task.HandsUp(-1);
            }
        }

        public async Task DoAnimation(Ped ped)
        {
            suspect.Task.PlayAnimation("missheist_jewel@first_person", "smash_case_e", 1f, 30000, AnimationFlags.Loop);
            await BaseScript.Delay(30000);
        }
    }
}