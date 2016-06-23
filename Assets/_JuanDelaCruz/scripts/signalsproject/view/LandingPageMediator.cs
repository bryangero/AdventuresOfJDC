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
		public LoadGameSignal loadGameSignal { get; set; }

		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		[Inject]
		public LoadEnterNameSignal loadEnterNameSignal { get; set; }
		
		public override void OnRegister() {
//			showWindowSignal.AddListener(OnShowWindow);
//			loadEnterNameSignal.AddListener (OnLoadEnterNameSignal);
			view.clickLoadGameSignal.AddListener(ClickLoadGame);
			view.showWindowSignal.AddListener (OnViewShowWindow);
			view.loadDialogueBoxSignal.AddListener (OnViewLoadDialogueBox);
		}
		
		public override void OnRemove() {
//			showWindowSignal.RemoveListener(OnShowWindow);
//			loadEnterNameSignal.RemoveListener (OnLoadEnterNameSignal);
			view.clickLoadGameSignal.RemoveListener(ClickLoadGame);
			view.showWindowSignal.RemoveListener (OnViewShowWindow);
			view.loadDialogueBoxSignal.RemoveListener (OnViewLoadDialogueBox);
		}
			
		private void ClickLoadGame() {
			loadGameSignal.Dispatch();
		}

		private void OnViewShowWindow(GAME_WINDOWS gameWindow) {
			showWindowSignal.Dispatch (gameWindow);
		}

		private void OnViewLoadDialogueBox(DIALOGUE_TYPE dialogueType, string dialogue) {
			loadDialogueBoxSignal.Dispatch (dialogueType, dialogue);
		}

	}
}

