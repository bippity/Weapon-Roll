using System;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace RollWeapon
{
	[ApiVersion(2, 1)]
	public class ItemRoll : TerrariaPlugin
	{
		public override Version Version
		{
			get { return new Version(1, 0); }
		}

		public override string Name
		{
			get { return "Item Roll"; }
		}

		public override string Author
		{
			get { return "Bippity"; }
		}

		public override string Description
		{
			get { return "Rolls a random weapon"; }
		}

		public ItemRoll(Main game) : base(game)
		{
		}

		public override void Initialize()
		{
			TShockAPI.Commands.ChatCommands.Add(new Command("itemroll", Roll, "itemroll"));
		}

		private void Roll(CommandArgs args)
		{
            
			Random r = new Random();

            Item give = TShock.Utils.GetItemById(r.Next(-48, Main.maxItemTypes));
            while (TShock.Itembans.ItemIsBanned(give.Name))
            {
                args.Player.SendErrorMessage("Rolled a banned item. Rerolling...");
                give = TShock.Utils.GetItemById(r.Next(-48, Main.maxItemTypes));
            }

            int stack = r.Next(1, (give.maxStack / 2)+1);
            args.Player.GiveItem(give.type, give.Name, args.TPlayer.width, args.TPlayer.height, 1);
            TSPlayer.All.SendSuccessMessage(args.Player.Name + " rolled for an item and got a " + give.Name + "!");
		}
	}
}
