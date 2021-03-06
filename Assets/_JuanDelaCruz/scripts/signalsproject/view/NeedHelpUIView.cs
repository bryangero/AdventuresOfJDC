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

		public Signal<DIALOGUE_TYPE, string> loadDialogueBoxSignal = new Signal<DIALOGUE_TYPE, string>();

		public Player[] helpers;
		public PlayerHelper[] playerHelpers;
		public GameView gameView;

		[SerializeField] GameObject holder;
		[SerializeField] GameObject helperHolder;

		public Transform grid;
		public Vector3 grid3Pos;
		public Vector3 grid2Pos;
		public Vector3 grid1Pos;

		public GameObject cover;
		public UILabel coverLbl;

		public void EnableNeedHelpUI() {
			holder.SetActive(true);
			if (GameSparksManager.instance.isConnected) {
				GameSparksManager.instance.GsLogEventResponseEvt += AttemptLoadPlayers;
				GameSparksManager.instance.LoadPlayers();
			} else {
				cover.SetActive (false);
				coverLbl.gameObject.SetActive (false);
				DialogueBoxView.OnClickOKEvent += OnClickOK;
				loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.OK, "Need Internet Connection to use this Feature.");
			}
		}

		private void OnClickOK() {
			DialogueBoxView.OnClickOKEvent -= OnClickOK;
			gameView.OnFinishNeedHelp();
		}

		public void DisableNeedHelpUI() {
			holder.SetActive(false);
			helperHolder.SetActive(false);
		}

		public void OnClickYes() {
			AudioManager.instance.PlayButton ();
			int nullHelperCtr = 0;
			for (int i = 0; i < helpers.Length; i++) {
				playerHelpers[i].gameObject.SetActive(true);
				if (helpers [i] == null) {
					nullHelperCtr++;
					playerHelpers[i].gameObject.SetActive(false);
				}
			}
			if (nullHelperCtr == 3) {
				DialogueBoxView.OnClickOKEvent += OnClickOK;
				loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.OK, "No available helper");
			} else if (nullHelperCtr == 2) {
				grid.transform.localPosition = grid1Pos;
				playerHelpers[0].Init(helpers[0]);
			} else if (nullHelperCtr == 1) {
				grid.transform.localPosition = grid2Pos;
				playerHelpers[0].Init(helpers[0]);
				playerHelpers[1].Init(helpers[1]);
			} else {
				grid.transform.localPosition = grid3Pos;
				playerHelpers[0].Init(helpers[0]);
				playerHelpers[1].Init(helpers[1]);
				playerHelpers[2].Init(helpers[2]);
			}

			helperHolder.SetActive(true);
		}

		public void OnClickNo() {
			AudioManager.instance.PlayButton ();
			gameView.OnFinishNeedHelp();
		}

		public void OnChosenHelper(int id) {
			AudioManager.instance.PlayButton ();
			gameView.OnFinishNeedHelp(helpers[id]);
		}
			
		public void AttemptLoadPlayers(LogEventResponse response) {
			GameSparksManager.instance.GsLogEventResponseEvt -= AttemptLoadPlayers;
			if (!response.HasErrors) {
				GSData[] data = response.ScriptData.GetGSDataList("playerData").ToArray();
				helpers = new Player[3];

				for (int t = 0; t < data.Length; t++ )
				{
					GSData tmp = data[t];
					int r = UnityEngine.Random.Range(t, data.Length);
					data[t] = data[r];
					data[r] = tmp;
				}

				int helpersIdx = 0;
				for (int i = 0; i < data.Length; i++) {
					string playerName = data [i].GetString ("playerName");
					int playerLevel = (int)data [i].GetInt ("playerLevel");
					WEAPON_TYPE playerWeapon = (WEAPON_TYPE)data [i].GetInt ("playerWeapon");
					if (playerLevel > player.level - 2 && playerLevel < player.level + 2 && player.name != playerName) {
						helpers [helpersIdx] = new Player (playerName, playerLevel, playerWeapon);
						helpersIdx++;
						if (helpersIdx >= helpers.Length) {
							break;
						}
					}
				}
				Debug.Log("Received Player Data From GameSparks...");
				cover.SetActive (false);
				coverLbl.gameObject.SetActive (false);
			} else {
				Debug.Log("Error Loading Player Data...");
			}
		}



	}

}

