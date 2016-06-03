/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class LandingPageMediator : Mediator {
		[Inject]
		public LandingPageView view{ get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public CreateNewGameSignal createNewGameSignal { get; set; }

		[Inject]
		public LoadGameSignal loadGameSignal { get; set; }

		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }
		
		public override void OnRegister() {
			showWindowSignal.AddListener(OnShowWindow);
			view.clickNewGameSignal.AddListener(ClickNewGame);
			view.clickLoadGameSignal.AddListener(ClickLoadGame);
		}
		
		public override void OnRemove() {
			showWindowSignal.RemoveListener(OnShowWindow);
			view.clickNewGameSignal.RemoveListener(ClickNewGame);
			view.clickLoadGameSignal.RemoveListener(ClickLoadGame);
		}

		private void ClickNewGame() {
			if (PlayerPrefs.HasKey ("PLAYER")) {
				DialogueBoxView.OnClickYesEvent += OnClickYes;
				DialogueBoxView.OnClickNoEvent += OnClickNo;
				loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.YES_NO, "There is currently a saved game. Continuing will erase all saved data. Proceed?");
			} else {
				createNewGameSignal.Dispatch();
			}
		}

		private void ClickLoadGame() {
			loadGameSignal.Dispatch();
		}

		private void OnShowWindow(GAME_WINDOWS gameWindow) {
//			Debug.Log(name + " " + gameWindow);
		}

		private void OnClickYes() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			createNewGameSignal.Dispatch();
		}

		private void OnClickNo() {
			DialogueBoxView.OnClickYesEvent -= OnClickNo;

		}
	}
}

