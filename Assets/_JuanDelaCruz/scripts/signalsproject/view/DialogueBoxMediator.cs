/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class DialogueBoxMediator : Mediator {
		
		[Inject]
		public DialogueBoxView view { get; set; }

		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		public override void OnRegister() {
			loadDialogueBoxSignal.AddListener (view.OnReceiveDialogue);
		}
		
		public override void OnRemove() {
			loadDialogueBoxSignal.RemoveListener (view.OnReceiveDialogue);
		}
			
	}
}

