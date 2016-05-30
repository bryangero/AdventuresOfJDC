using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class GameUIView : View {

		[Inject]
		public IPlayer player { get; set; }

//		[Inject("ActiveStage")]
//		public IStage stage { get; set; }




		[SerializeField] GameObject holder;
		public GameView gameView;
		public Signal endBattleSignal = new Signal();
		public Signal<int> animateAttack = new Signal<int>();

		public UIScrollBar scrollbar;
		private bool isDirUp = true;
		public bool isAttackReady = false;

		public UISprite playerHp;
		public int playerHpHolder;
		public int playerDamageTaken;
		public float playerConvertedHp;
		public UISprite enemyHp;
		public int enemyHpHolder;
		public int enemyDamageTaken;

		internal void init() {
			player = new Player();
			Debug.Log(player.hitPoints);
			playerHpHolder = player.hitPoints;
			playerConvertedHp = playerDamageTaken / playerHpHolder;
			MoveAttackBarUp();
		}

		public void MoveAttackBarUp() {
			float barVal = scrollbar.value;
			float timeToComplete = 1 - barVal;
			isDirUp = true;
			iTween.ValueTo(gameObject, iTween.Hash(
				"name", "MoveAttackBarUp",
				"from", barVal,
				"to", 1, 
				"onupdatetarget", gameObject, 
				"onupdate", "UpdateScollValue",
				"oncompletetarget", gameObject, 
				"oncomplete", "CompleteMoveUpValue",
				"time", timeToComplete));
		}

		public void MoveAttackBarDown() {
			float barVal = scrollbar.value;
			float timeToComplete = barVal;
			isDirUp = false;
			iTween.ValueTo(gameObject, iTween.Hash(
				"name", "MoveAttackBarDown",
				"from", barVal,
				"to", 0, 
				"onupdatetarget", gameObject, 
				"onupdate", "UpdateScollValue",
				"oncompletetarget", gameObject, 
				"oncomplete", "CompleteMoveDownValue",
				"time", timeToComplete));
		}

		public void UpdateScollValue(float val) {
			scrollbar.value = val;
		}

		public void CompleteMoveUpValue() {
			MoveAttackBarDown();
		}

		public void CompleteMoveDownValue() {
			MoveAttackBarUp();
		}

		public void EnableGameUI() {
			holder.SetActive(true);
		}

		public void DisableGameUI() {
			holder.SetActive(false);
		}

		public void OnClickBattle() {
			endBattleSignal.Dispatch();
			Debug.Log("Clicked END BATTLE");
		}

		public void ClickAttack() {
			iTween.StopByName("MoveAttackBarUp");
			iTween.StopByName("MoveAttackBarDown");
			StartCoroutine("AnimateAttack");
		}

		public IEnumerator AnimateAttack() {
			yield return new WaitForSeconds(1);
			if (isDirUp) {
				MoveAttackBarUp();
			} else {
				MoveAttackBarDown();
			}
			Debug.Log("FINISHED ANIMATION");
		}

	}

}

