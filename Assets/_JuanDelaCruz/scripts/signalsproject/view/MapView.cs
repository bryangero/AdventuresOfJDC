using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class MapView : View {

		[Inject]
		public IPlayer player { get; set; }
		public Signal<int> loadStage = new Signal<int>();
		public Signal<GAME_WINDOWS> showWindowSignal = new Signal<GAME_WINDOWS> ();
		[SerializeField] GameObject holder;
        [SerializeField] GameObject mapCamera;
        public UISprite[] stageSprites;
		public bool isActive;
		public UITexture script;
		public Texture[] scriptsTextures;
		public GameObject instructions1;
		public GameObject instructions2;
		public GameObject instructions3;

		public UILabel scriptLbl;

		public void EnableMap() {
			StartCoroutine (WaitFrameEnd());
			holder.SetActive(true);
            mapCamera.SetActive(true);

            for (int i = 0; i < stageSprites.Length; i++) {
				if (Int32.Parse (stageSprites [i].name) > player.stage) {
					stageSprites [i].color = Color.gray;
				} else {
					stageSprites [i].color = Color.white;
				}
			}

		}

		int scriptIndex = 0;
		public void UpdateScriptTextures() {
			scriptIndex++;
			switch (scriptIndex) {
			case 1:
				scriptLbl.text = "You have to kill the \"aswangs\" to be able to protect the humans and your hometown";
				break;
			case 2:
				scriptLbl.text = "Every stage you will meet different kinds of \"aswangs\". You will be provided with proper weapon to defeat them.";
				break;
			case 3:
				scriptLbl.text = "The game has 5 stages. You will encounter 4 minions and 1 Boss per stage.";
				break;
			default:
				scriptLbl.transform.parent.gameObject.SetActive (false);
				instructions1.SetActive (true);
				break;
			}
		}

		public void ShowInstructions2() {
			instructions1.SetActive (false);
			instructions2.SetActive (true);
		}
		public void ShowInstructions3() {
			instructions2.SetActive (false);
			instructions3.SetActive (true);
		}
		public void CloseInstructions() {
			instructions3.SetActive (false);
		}

		public IEnumerator WaitFrameEnd() {
			yield return null;
			isActive = true;
			if (!PlayerPrefs.HasKey ("First")) {
				scriptLbl.text = "Hi! " + player.name + "!\nYou are half-human and half-aswang";
				scriptLbl.transform.parent.gameObject.SetActive (true);
				PlayerPrefs.SetInt ("First", 1);
			} else {
				if (PlayerPrefs.GetInt ("First") == 0) {
					scriptLbl.text = "Hi! " + player.name + "!\nYou are half-human and half-aswang";
					scriptLbl.transform.parent.gameObject.SetActive (true);
					PlayerPrefs.SetInt ("First", 1);
				}
			}
		}

		public void FixedUpdate() {
			if(Input.GetKeyUp(KeyCode.Escape) && isActive) {
				showWindowSignal.Dispatch(GAME_WINDOWS.LANDING_PAGE);
			}
		}

		public void DisableMap() {
			isActive = false;
			holder.SetActive(false);
            mapCamera.SetActive(false);
        }

        public void LoadStage(int stageId) {
			loadStage.Dispatch (stageId);
		}

	}

}

