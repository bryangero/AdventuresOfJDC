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

		public override void OnRegister() {
			view.returnToMapSignal.AddListener(OnReturnToMapSignal);
			view.displayContinueSignal.AddListener(OnDisplayContinueSignal);
		}
		
		public override void OnRemove() {
			view.returnToMapSignal.RemoveListener(OnReturnToMapSignal);
			view.displayContinueSignal.RemoveListener(OnDisplayContinueSignal);
		}

		public void OnReturnToMapSignal() {
			showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
		}

		public void OnDisplayContinueSignal() {
			DialogueBoxView.OnClickYesEvent += OnClickYes;
			DialogueBoxView.OnClickNoEvent += OnClickNo;
			loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.CONTINUE,"Continue?\n10");
		}

		private void OnClickYes() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
			view.RestartRound();
		}

		private void OnClickNo() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
			OnReturnToMapSignal();
		}

	}
}

