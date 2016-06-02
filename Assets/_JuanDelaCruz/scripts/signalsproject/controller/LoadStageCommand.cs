using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace JuanDelaCruz {

	public class LoadStageCommand : Command {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView { get; set; }

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public IStage stage { get; set; }

		[Inject]
		public int stageId { get; set; }

		[Inject]
		public IRoutineRunner rr { get; set; }

		public override void Execute() {
			rr.StartCoroutine(ExecuteInOrder());
		}

		public IEnumerator ExecuteInOrder() {
			stage.LoadStage (stageId);
			yield return null;
			GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
			GameObject.FindObjectOfType<MapView>().DisableMap();
			GameView gv = GameObject.FindObjectOfType (typeof(GameView)) as GameView;
			gv.init ();
		}

	}

}

