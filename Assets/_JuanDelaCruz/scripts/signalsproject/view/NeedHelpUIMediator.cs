/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class NeedHelpUIMediator : Mediator {
		[Inject]
		public NeedHelpUIView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		public override void OnRegister() {
			view.loadDialogueBoxSignal.AddListener (OnViewLoadDialogueBox);
		}
		
		public override void OnRemove() {
			view.loadDialogueBoxSignal.RemoveListener (OnViewLoadDialogueBox);
		}

		private void OnViewLoadDialogueBox(DIALOGUE_TYPE dialogueType, string dialogue) {
			loadDialogueBoxSignal.Dispatch (dialogueType, dialogue);
		}
	}
}

