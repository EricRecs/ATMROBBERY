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
    [CalloutProperties(name: "LSATMROBBERY", author: "Dispatch", version: "0.0.2")]

    public class LSATMROBBERY : Callout
    {
        Ped suspect;

        public LSATMROBBERY()
        {
            Random random = new Random();
            int location = random.Next(1, 310);
            if (location <= 10)
            {
                InitInfo(new Vector3(x: -712.3093f, y: -819.6804f, z: 23.6312f));//Peaceful Street (Quik House Slaughter)
            }
            else if (location <= 20 && location > 10)
            {
                InitInfo(new Vector3(x: 1138.7665f, y: -469.1552f, z: 66.7283f));//Vespucci Boulevard (Lombank Tower)
            }
            else if (location <= 30 && location > 20)
            {
                InitInfo(new Vector3(x: -821.9233f, y: -1082.0966f, z: 11.1324f));//Vespucci Boulevard (FLEECA Branch)
            }
            else if (location <= 40 && location > 30)
            {
                InitInfo(new Vector3(x: -867.2330f, y: -187.1057f, z: 37.8409f));//San Andreas Ave (FIB HQ)
            }
            else if (location <= 50 && location > 40)
            {
                InitInfo(new Vector3(x: 128.5150f, y: -1292.2672f, z: 29.2695f));//San Andreas Ave (Maison Ricard)
            }
            else if (location <= 60 && location < 50)
            {
                InitInfo(new Vector3(x: -712.3093f, y: -819.6804f, z: 23.6312f));//Power Street (Union Deposit)
            }
            else if (location <= 70 && location > 60)
            {
                InitInfo(new Vector3(x: -202.9886f, y: -862.1551f, z: 30.2676f));//Alta Street 707 Vespucci
            }
            else if (location <= 80 && location > 70)
            {
                InitInfo(new Vector3(x: 119.9151f, y: -884.0469f, z: 31.1231f));//Elgin Avenue (Escapism Travel)
            }
            else if (location <= 90 && location > 80)
            {
                InitInfo(new Vector3(x: 295.0246f, y: -895.8438f, z: 29.1974f));//Strawberry Avenue (Robert Dazzler)
            }
            else if (location <= 100 && location > 90)
            {
                InitInfo(new Vector3(x: 380.8786f, y: 323.7162f, z: 103.5664f));//Clinton Avenue 24/7
            }
            else if (location <= 110 && location > 100)
            {
                InitInfo(new Vector3(x: 89.5884f, y: 2.1982f, z: 68.3198f));//Spanish Avenue (Pop's Pills)
            }
            else if (location <= 120 && location > 110)
            {
                InitInfo(new Vector3(x: -164.4775f, y: 234.8696f, z: 94.9220f));//Eclipse Boulevard (Hardcore Comic)
            }
            else if (location <= 130 && location > 120)
            {
                InitInfo(new Vector3(x: 1153.9471f, y: -326.6149f, z: 69.2051f));//West Mirror Drive (Limited Service)
            }
            else if (location <= 140 && location > 130)
            {
                InitInfo(new Vector3(x: 1077.9318f, y: -775.2810f, z: 58.1971f));//West Mirror Drive (Chico's Hypermarket)
            }
            else if (location <= 150 && location > 140)
            {
                InitInfo(new Vector3(x: 1139.2826f, y: -469.0848f, z: 66.7334f));//Mirror Park and Nikola Ave (Shopping Center)
            }
            else if (location <= 160 && location > 150)
            {
                InitInfo(new Vector3(x: -57.9385f, y: -92.8341f, z: 57.7902f));//Hawick Ave and Las Lagunas Blvd (Liquor Store)
            }
            else if (location <= 170 && location > 160)
            {
                InitInfo(new Vector3(x: 356.9993f, y: 173.4431f, z: 103.0665f));//Vinewood Blvd and Power St (Vineewood Mall)
            }
            else if (location <= 180 && location > 170)
            {
                InitInfo(new Vector3(x: 237.0706f, y: 217.7701f, z: 106.2868f));//Vinewood Blvd (Pacific Standard Public Bank)
            }
            else if (location <= 190 && location > 180)
            {
                InitInfo(new Vector3(x: -618.9652f, y: -706.8685f, z: 30.0528f));//Palomino Ave and San Andreas Ave (Little Seoul Tower)
            }
            else if (location <= 200 && location > 190)
            {
                InitInfo(new Vector3(x: -717.6184f, y: -915.6578f, z: 19.2156f));//Lindsay Circus (Limited Service)
            }
            else if (location <= 210 && location > 200)
            {
                InitInfo(new Vector3(x: - 711.2654f, y: -820.2313f, z: 23.6286f));//Vespucci Boulevard (Kayton and Arirang Plaza)
            }
            else if (location <= 220 && location > 210)
            {
                InitInfo(new Vector3(x: -537.6959f, y: -853.6614f, z: 29.2936f));//Vespucci Boulevard (Look-See and Blick stores)
            }
            else if (location <= 230 && location > 220)
            {
                InitInfo(new Vector3(x: -1304.7661f, y: -705.9509f, z: 25.3224f));//Prosperity Street (Astro Theaters)
            }
            else if (location <= 240 && location > 230)
            {
                InitInfo(new Vector3(x: -1316.2352f, y: -835.1520f, z: 16.9619f));//Bay City Ave (Maze Bank Branch)
            }
            else if (location <= 250 && location > 240)
            {
                InitInfo(new Vector3(x: -1205.3262f, y: -324.6671f, z: 37.8569f));//Boulevard Del Perro (FLEECA Bank)
            }
            else if (location <= 260 && location > 250)
            {
                InitInfo(new Vector3(x: - 1410.0259f, y: -98.4496f, z: 52.4489f));//Cougar Ave (International Online)
            }
            else if (location <= 270 && location > 260)
            {
                InitInfo(new Vector3(x: -865.7998f, y: -187.3371f, z: 37.7306f));//Mad Waynee Thunder Dr (Lombank Branch)
            }
            else if (location <= 280 && location > 270)
            {
                InitInfo(new Vector3(x: - 845.8298f, y: -341.2053f, z: 38.6803f));//Dorset Dr and Heritage Way (Internation Online Building)
            }
            else if (location <= 290 && location > 280)
            {
                InitInfo(new Vector3(x: -721.7416f, y: -415.6700f, z: 34.9833f));//Back entrance of Leopolds
            }
            else if (location <= 300 && location > 290)
            {
                InitInfo(new Vector3(x: -56.7010f, y: -1752.1820f, z: 29.4210f));//Grove St and Davis Avenue (Limited Services)
            }
            else
            {
                InitInfo(new Vector3(x: 129.2317f, y: -1292.0098f, z: 29.2695f));//Inside Purple Unicorn
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