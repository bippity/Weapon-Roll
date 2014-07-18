using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace RollWeapon
{
	[ApiVersion(1, 16)]
	public class RollWeapon : TerrariaPlugin
	{
		public override Version Version
		{
			get { return new Version(1, 0); }
		}

		public override string Name
		{
			get { return "Weapon Roll"; }
		}

		public override string Author
		{
			get { return "Bippity"; }
		}

		public override string Description
		{
			get { return "Rolls a random weapon"; }
		}

		public RollWeapon(Main game) : base(game)
		{
		}

        int[] normalItems = new int[] 
        {
            #region itemList
            -48, //Platinum Bow
            -45 //Platinum Shortsword
#endregion
        };

        int[] hardmodeItems = new int[]
        {
            #region itemList
            389, //Dao of Pow
            1259, //Flower Pow
            1297, //Golem Fist
            1314, //KO Cannon
            537, //Cobalt Naginata
            390, //Mythril Halberd
            406, //Adamantite Glaive
            550, //Gungnir
            1228, //Chlorophyte Partisan
            1193, //Orichalcum Halberd
            1200, //Titanium Trident
            1186, //Palladium Pike
            756, //Mushroom Spear
            435, //Cobalt Repeater
            436, //Mythril Repeater
            481, //Adamantite Repeater
            578, //Hallowed Repeater
            561, //Light disc
            1324, //Bananarang
            1122, //Possessed Hatchet
            1513, //Paladin's Hammer
            434, //Clockwork Assault Rifle
            533, //Megashark
            506, //Flamethrower
            534, //Shotgun
            679, //Tactical Shotgun
            1254, //Sniper Rifle
            1265, //Uzi
            905, //Coin Gun
            514, //Laser Rifle
            1255, //Venus Magnum
            1444, //Shadowbeam Staff
            1308, //Poison Staff
            1446, //Spectre Staff
            518, //Crystal Storm
            519, //Cursed Flames
            1266, //Magnet Sphere
            1336, //Golden Shower
            517, //Magic Dagger
            496, //Ice Rod
            495, //Rainbow Rod
            494, //Magical Harp
            -24, //Yellow Phasesaber
            -23, //White Phasesaber
            -22, //Purple Phasesaber
            -21 //Green Phasesaber
            -20, //Red Phasesaber
            -19, //Blue Phasesaber
            426, //Breaker Blade
            483, //Cobalt Sword
            484, //Mythril Sword
            482, //Adamantite Sword
            368, //Excalibur
            676, //Frostbrand
            672, //Cutlass
            1192, //Orichalcum Sword
            1199, //Titanium Sword
            674, //True Excalibur
            675, //True Night's Edge
            757, //Terra Blade
            1226, //Chlorophyte Claymore
            1227, //Chlorophyte Saber
            723, //Beam Sword
            671, //Keybrand
#endregion
        };

		public override void Initialize()
		{
			TShockAPI.Commands.ChatCommands.Add(new Command("rollweapon", Roll, "rollwep"));
		}

		private void Roll(CommandArgs args)
		{
			Random r = new Random();
            
            Item give = TShock.Utils.GetItemById(hardmodeItems[r.Next(0,hardmodeItems.Length-1)]);
            
            args.Player.GiveItem(give.type, give.name, give.width, give.height, 1);
            TSPlayer.All.SendInfoMessage(args.Player.Name + " rolled for a weapon and got a " + give.name + "!");
		}
	}
}
