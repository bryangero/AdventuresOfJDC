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
				GameSparksManager.instance.GsLogEventResponseEvt += AttemptLoadPlayers;
				GameSparksManager.instance.LoadPlayers();
			} else {
				gameView.OnFinishNeedHelp();
			}
		}

		public void DisableNeedHelpUI() {
			holder.SetActive(false);
			helperHolder.SetActive(false);
		}

		public void OnClickYes() {
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
			
		public void AttemptLoadPlayers(LogEventResponse response) {
			GameSparksManager.instance.GsLogEventResponseEvt -= AttemptLoadPlayers;
			if (!response.HasErrors) {
				GSData[] data = response.ScriptData.GetGSDataList("playerData").ToArray();
				helpers = new Player[3];
				for (int i = 0; i < helpers.Length; i++) {
					helpers [i] = new Player((int)data[i].GetInt("playerLevel"),(WEAPON_TYPE)data[i].GetInt("playerWeapon"));
				}
				Debug.Log("Received Player Data From GameSparks...");
			} else {
				Debug.Log("Error Loading Player Data...");
			}
		}


	}

}

