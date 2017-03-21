/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class GameMediator : Mediator {
		[Inject]
		public GameView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		[Inject]
		public IPlayer player { get; set;}

		public override void OnRegister() {
			view.returnToMapSignal.AddListener(OnReturnToMapSignal);
			view.displayContinueSignal.AddListener(OnDisplayContinueSignal);
			view.showWindowSignal.AddListener (OnViewShowWindow);
		}
		
		public override void OnRemove() {
			view.returnToMapSignal.RemoveListener(OnReturnToMapSignal);
			view.displayContinueSignal.RemoveListener(OnDisplayContinueSignal);
			view.showWindowSignal.RemoveListener (OnViewShowWindow);
		}

		private void OnViewShowWindow(GAME_WINDOWS gameWindow) {
			showWindowSignal.Dispatch (gameWindow);
		}

		public void OnReturnToMapSignal() {
			showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
		}

		public void OnReturnToLandingPageSignal()
		{
			showWindowSignal.Dispatch(GAME_WINDOWS.LANDING_PAGE);
		}

		public void OnDisplayContinueSignal() {
			loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.CONTINUE,"Continue?\n10");
			if (player.lives <= 0) {
				DialogueBoxView.OnClickYesEvent += OnClickYesNoLife;
				DialogueBoxView.OnClickNoEvent += OnClickNoNoLife;
			} else {
				DialogueBoxView.OnClickYesEvent += OnClickYes;
				DialogueBoxView.OnClickNoEvent += OnClickNo;
			}
		}
		private void OnClickYes() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
//			OnReturnToMapSignal();
			view.RestartRound();
		}

		private void OnClickNo() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
			OnReturnToLandingPageSignal ();
//			OnReturnToMapSignal();
		}


			private void OnClickYesNoLife() {
				DialogueBoxView.OnClickYesEvent -= OnClickYesNoLife;
				DialogueBoxView.OnClickNoEvent -= OnClickNoNoLife;
				view.DisableGame ();
				OnReturnToMapSignal();
//				view.RestartRound();
			}

			private void OnClickNoNoLife() {
				DialogueBoxView.OnClickYesEvent -= OnClickYesNoLife;
				DialogueBoxView.OnClickNoEvent -= OnClickNoNoLife;
//				OnReturnToLandingPageSignal ();
				view.DisableGame ();
				OnReturnToMapSignal();
			}

	}
}

