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

		public Monster monster;

		[SerializeField] GameObject holder;
		public GameView gameView;
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
		public float enemyConvertedHp;
		public UILabel timerLabel;

		public UILabel winLoseLbl;
		public TweenScale winLoseTweenScale;
		private bool isTimesUp = false;

		public void EnableGameUI() {
			holder.SetActive(true);
		}

		public void DisableGameUI() {
			holder.SetActive(false);
		}

		internal void init(Monster monster) {
			holder.SetActive(true);
			this.monster = monster;
			playerHpHolder = player.hitPoints;
			playerHp.fillAmount = 1;
			enemyHpHolder = monster.hitPoints;
			enemyHp.fillAmount = 1;
			StartCoroutine("UpdateTimer");
			winLoseLbl.gameObject.transform.localScale = Vector3.zero;
			winLoseTweenScale.ResetToBeginning ();
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

		public void ClickAttack() {
			if(gameView.isRoundEnd == true) {
				return;
			}
			iTween.StopByName("MoveAttackBarUp");
			iTween.StopByName("MoveAttackBarDown");
			float test = Math.Abs(0.5f - scrollbar.value);
			int range = player.maxDamage - player.minDamage;
			float rangeDifference = 0.5f /(float)range;
			int[] damageArray = new int[range];
			for(int i = 0; i < damageArray.Length; i++) {
				damageArray[i] = player.maxDamage - i;
			}
			float max = 0; 
			for(int j = 0; j < damageArray.Length; j++) {
				float min = max;
				max = rangeDifference * j;
				if(test >= min && test <= max) {
					enemyDamageTaken += damageArray[j];
					UpdateEnemyHpBar();
					return;
				}
			}
			UpdateEnemyHpBar();
		}

		public void FinishedAnimation() {
			if(isDirUp) {
				MoveAttackBarUp();
			} else {
				MoveAttackBarDown();
			}
		}

		private IEnumerator UpdateTimer() {
			int timer = 99;
			while(timer > 0 && gameView.isRoundEnd == false) {
				timer--;
				timerLabel.text = timer.ToString("00");
				yield return new WaitForSeconds(1);
			}
			if(gameView.isRoundEnd != true) {
				gameView.isRoundEnd = true;
				winLoseLbl.text = "Times Up!";
				winLoseTweenScale.PlayForward();
				iTween.StopByName("MoveAttackBarUp");
				iTween.StopByName("MoveAttackBarDown");
				isTimesUp = true;
			}
		}

		private void UpdatePlayerHpBar() {
			if(playerDamageTaken > playerHpHolder) {
				playerDamageTaken = playerHpHolder;
			}
			playerConvertedHp =((float)playerHpHolder -(float)playerDamageTaken) /(float)playerHpHolder;
			iTween.ValueTo(gameObject, iTween.Hash(
				"name", "MoveAttackBarUp",
				"from", playerHp.fillAmount,
				"to", playerConvertedHp, 
				"onupdatetarget", gameObject, 
				"onupdate", "UpdatePlayerHpBarFillAmount",
				"oncompletetarget", gameObject, 
				"oncomplete", "FinishedUpdatePlayerHpBarFillAmount",
				"time", 0.5f));
		}

		public void UpdatePlayerHpBarFillAmount(float val) {
			playerHp.fillAmount = val;
		}

		public void FinishedUpdatePlayerHpBarFillAmount() {
			if(playerHp.fillAmount <= 0) {
				winLoseLbl.text = "You Lose!";
				winLoseTweenScale.PlayForward();
				gameView.isRoundEnd = true;
			} else {
				FinishedAnimation();
			}
		}

		private void UpdateEnemyHpBar() {
			enemyDamageTaken += ApplyWeaponBonus();
			if(enemyDamageTaken > enemyHpHolder) {
				enemyDamageTaken = enemyHpHolder;
			}
			enemyConvertedHp =((float)enemyHpHolder -(float)enemyDamageTaken)/(float)enemyHpHolder;
			iTween.ValueTo(gameObject, iTween.Hash(
				"name", "MoveAttackBarUp",
				"from", enemyHp.fillAmount,
				"to", enemyConvertedHp, 
				"onupdatetarget", gameObject, 
				"onupdate", "UpdateEnemyHpBarFillAmount",
				"oncompletetarget", gameObject, 
				"oncomplete", "FinishedUpdateEnemyHpBarFillAmount",
				"time", 0.5f));
		}

		public void UpdateEnemyHpBarFillAmount(float val) {
			enemyHp.fillAmount = val;
		}

		public void FinishedUpdateEnemyHpBarFillAmount() {
			if(enemyHp.fillAmount <= 0) {
				winLoseLbl.text = "You Win!";
				winLoseTweenScale.PlayForward();
				gameView.isRoundEnd = true;
			} else {
				EnemyAttack();
			}
		}

		public void EnemyAttack() {
			int enemyDamage = UnityEngine.Random.Range(monster.minDamage, monster.maxDamage);
			playerDamageTaken += enemyDamage;
			UpdatePlayerHpBar();
		}

		public void FinishedWinLoseAnimation() {
			if (isTimesUp == true) {
				if (playerHp.fillAmount > enemyHp.fillAmount) {
					winLoseLbl.text = "You Win!";
					winLoseTweenScale.PlayForward ();
					gameView.OnFinishedRound (true);
				} else {
					winLoseLbl.text = "You Lose!";
					winLoseTweenScale.PlayForward ();
					gameView.OnFinishedRound (false);
				}
			} else {
				if (playerHp.fillAmount > enemyHp.fillAmount) {
					gameView.OnFinishedRound (true);
				} else {
					gameView.OnFinishedRound (false);
				}
			}
			DisableGameUI();
		}

		public int ApplyWeaponBonus() {
			switch (player.weapon) {
			case WEAPON_TYPE.SWORD:
				return 25;
			case WEAPON_TYPE.BOW:
				return 30;
			case WEAPON_TYPE.WHIP:
				return 40;
			case WEAPON_TYPE.SPEAR:
				return 45;
			case WEAPON_TYPE.SHIELD:
				return 60;
			default:
				return 0;
			}
		}
	}

}

