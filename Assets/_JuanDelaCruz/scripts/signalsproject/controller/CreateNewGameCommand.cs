using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

namespace JuanDelaCruz {

	public class CreateNewGameCommand : Command {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView { get; set; }

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		public override void Execute() {
			player = new Player();
			player.SavePlayer();
			if (GameSparksManager.instance.isAvailable) {
				RegisterPlayer();
			} else {
				showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
			}
		}

		public void RegisterPlayer() {
			new GameSparks.Api.Requests.RegistrationRequest().SetDisplayName("Juan").SetPassword("password").SetUserName(GameSparksManager.instance.DEVICE_ID).Send((response) => {
				if (!response.HasErrors) {
					SavePlayer();
					Debug.Log("Player Registered");
				} else {
					SavePlayer();
					Debug.Log("Error Registering Player");
				}
			});
		}

		public void SavePlayer() {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("SET_PLAYER").
			SetEventAttribute("NAME", player.name).
			SetEventAttribute("LEVEL", player.level).
			SetEventAttribute("STAGE", player.stage).
			SetEventAttribute("WEAPON_TYPE", (int)player.weapon).
			SetEventAttribute("GOLD", player.gold).
			SetEventAttribute("CURRENT_EXP", player.currentExperience).Send((response) => {
				if (!response.HasErrors) {
					showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
					Debug.Log("Player Saved To GameSparks...");
				} else {
					Debug.Log("Error Saving Player Data...");
				}
			});
		}


	}

}

