using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

namespace JuanDelaCruz {

	public class NeedHelpUIView : View {

		[Inject]
		public IPlayer player {get;set;}

		public Player[] helpers;
		public PlayerHelper[] playerHelpers;
		public GameView gameView;

		[SerializeField] GameObject holder;
		[SerializeField] GameObject helperHolder;

		public void EnableNeedHelpUI() {
			holder.SetActive(true);
			if (GameSparksManager.instance.isConnected) {
				if (GameSparksManager.instance.isAvailable) {
					LoadPlayers();
				} else {
					
				}
			} else {
				gameView.OnFinishNeedHelp();
			}
		}

		public void DisableNeedHelpUI() {
			holder.SetActive(false);
			helperHolder.SetActive(false);
		}

		public void OnClickYes() {
			helpers = new Player[3];
			helpers[0] = new Player(3,WEAPON_TYPE.SHIELD);
			helpers[1] = new Player(5,WEAPON_TYPE.NONE);
			helpers[2] = new Player(4,WEAPON_TYPE.SWORD);
			Debug.Log (helpers[0].level);
			playerHelpers[0].Init(helpers[0].level);
			playerHelpers[1].Init(helpers[1].level);
			playerHelpers[2].Init(helpers[2].level);
			helperHolder.SetActive(true);
		}

		public void OnClickNo() {
			gameView.OnFinishNeedHelp();
		}

		public void OnChosenHelper(int id) {
			gameView.OnFinishNeedHelp(helpers[id]);
		}

		public void AuthenticatePlayer() {
			new GameSparks.Api.Requests.AuthenticationRequest().SetUserName("Juan").SetPassword("password").Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Authenticated...");
				} else {
					Debug.Log("Error Authenticating Player...");
				}
			});	
		}



		public void LoadPlayers() {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("GET_PLAYERS").
			SetEventAttribute("PLAYER_LEVEL", 1).
			Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Received Player Data From GameSparks...");
					GSData[] data = response.ScriptData.GetGSDataList("playerData").ToArray();
					Debug.Log(data.Length);
				} else {
					Debug.Log("Error Loading Player Data...");
				}
			});
		}


	}

}

