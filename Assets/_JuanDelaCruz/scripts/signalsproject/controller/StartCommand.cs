/// The only change in StartCommand is that we extend Command, not EventCommand

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace JuanDelaCruz {

	public class StartCommand : Command {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		public override void Execute() {
			Player player = new Player();
			string strSerializedPlayer = JsonFx.Json.JsonWriter.Serialize(player);
			Debug.Log(strSerializedPlayer);

			Player deserializedPlayer = JsonFx.Json.JsonReader.Deserialize<Player>(strSerializedPlayer);
			Debug.Log(deserializedPlayer.weapon);
		}

	}

}
