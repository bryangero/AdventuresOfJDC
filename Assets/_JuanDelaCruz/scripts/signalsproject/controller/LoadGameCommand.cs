using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace JuanDelaCruz {

	public class LoadGameCommand : Command {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView { get; set; }

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public IRoutineRunner rr { get; set; }

		public override void Execute() {
			rr.StartCoroutine(ExecuteInOrder());
		}

		public IEnumerator ExecuteInOrder() {
			player.LoadPlayer();
			yield return null;
			showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
		}

	}

}

