using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace BetterUIAndStuff
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        private bool doSprint = false;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // print button presses to the console window
            this.CheckIfToggleSprint(e);
        }

        private void CheckIfToggleSprint(ButtonPressedEventArgs e)
		{
            //F9 is toggle sprint for now, hardcoded just to test how this all works
            if(e.Button == SButton.F9)
			{
                this.doSprint = !this.doSprint;
			}
		}


        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            this.Sprint(e);
        }

        private void Sprint(UpdateTickedEventArgs e)
		{
            this.Monitor.Log($"{Game1.player.Name} pressed reached Sprint() ${this.doSprint}", LogLevel.Debug);
            if (this.doSprint)
                Game1.player.addedSpeed = 15;
            else
                Game1.player.addedSpeed = 0;
		}
    }
}