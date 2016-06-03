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
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public LoadStageSignal loadStageSignal {get;set;}
		
		public override void OnRegister() {
			view.loadStage.AddListener (OnLoadStage);
			view.init();
		}
		
		public override void OnRemove() {
			view.loadStage.RemoveListener (OnLoadStage);
		}

		public void OnLoadStage(int stageId) {
			loadStageSignal.Dispatch (stageId);
		}

	}
}

