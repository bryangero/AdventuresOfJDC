/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class MapMediator : Mediator {
		
		[Inject]
		public MapView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public LoadStageSignal loadStageSignal {get;set;}
		
		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		public override void OnRegister() {
			view.loadStage.AddListener(OnLoadStage);
			view.showWindowSignal.AddListener (OnViewShowWindow);
		}
		
		public override void OnRemove() {
			view.loadStage.RemoveListener(OnLoadStage);
			view.showWindowSignal.RemoveListener (OnViewShowWindow);
		}

		private void OnViewShowWindow(GAME_WINDOWS gameWindow) {
			showWindowSignal.Dispatch (gameWindow);
		}

		public void OnLoadStage(int stageId) {
			if (player.stage >= stageId) {
				loadStageSignal.Dispatch(stageId);
			} else {
				loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.OK, "Stage is still Locked");
			}
		}

	}
}

