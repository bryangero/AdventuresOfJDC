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
		public Player helper;
		public Monster monster;
		[SerializeField] GameObject holder;
		public GameView gameView;
		public EnemyDisplay enemyDisplay;
		public Signal<int> animateAttack = new Signal<int>();
		public Signal<GAME_WINDOWS> showWindowSignal = new Signal<GAME_WINDOWS> ();
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
		public UILabel playerNameLbl;
		public UILabel playerLevelLbl;
		public UILabel enemyLevelLbl;
		public UILabel enemyNameLbl;
		private bool isTimesUp = false;
		public HeroAnim heroAnim;
		public bool isAttacking = false;
		public bool isActive = false;
		public UISprite weaponSpt;
		public UILabel pauseLbl;
		public GameObject pauseCover;

		public void EnableGameUI() {
			holder.SetActive(true);
		}

		public void DisableGameUI() {
			isActive = false;
			holder.SetActive(false);
		}

		internal void init(Monster monster, Player helper = null) {
			switch (player.weapon) {
			case WEAPON_TYPE.SHIELD:
				weaponSpt.spriteName = "shield";
				break;
			case WEAPON_TYPE.SWORD:
				weaponSpt.spriteName = "sword";
				break;
			case WEAPON_TYPE.BOW:
				weaponSpt.spriteName = "bow";
				break;
			case WEAPON_TYPE.SPEAR:
				weaponSpt.spriteName = "spear";
				break;
			case WEAPON_TYPE.WHIP:
				weaponSpt.spriteName = "whip";
				break;
			default:
				weaponSpt.spriteName = "shield";
				break;

			}
			StartCoroutine (WaitFrameEnd ());
			playerNameLbl.text = player.name;
			enemyNameLbl.text = monster.name;
			heroAnim.PlayIdle ();
			holder.SetActive(true);
			this.monster = monster;
			enemyDisplay.ChangeEnemy(monster.monsterType);
			this.helper = helper;
			if (helper != null) {
				playerHpHolder = player.hitPoints + helper.hitPoints;
			} else {
				playerHpHolder = player.hitPoints;
			}
			playerLevelLbl.text = "lvl " + player.level.ToString();
			enemyLevelLbl.text = "lvl " + monster.level.ToString();
			playerHp.fillAmount = 1;
			enemyHpHolder = monster.hitPoints;
			enemyHp.fillAmount = 1;
			enemyDamageTaken = 0;
			playerDamageTaken = 0;
			timeToCompleteVariable = 1;
			isTimesUp = false;
			isAttacking = false;
			StartCoroutine("UpdateTimer");
			winLoseLbl.gameObject.transform.localScale = Vector3.zero;
			winLoseTweenScale.ResetToBeginning ();
			MoveAttackBarUp();
		}

		public IEnumerator WaitFrameEnd() {
			yield return null;
			isActive = true;
		}

		public float timeToCompleteVariable = 1f;
		public void MoveAttackBarUp() {
			float barVal = scrollbar.value;
			float timeToComplete = timeToCompleteVariable - (barVal * timeToCompleteVariable);
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
			float timeToComplete = barVal * timeToCompleteVariable;
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
			AudioManager.instance.PlayAttackButton ();
			if(gameView.isRoundEnd == true) {
				return;
			}
			if (isAttacking == true) {
				return;
			}
			iTween.StopByName("MoveAttackBarUp");
			iTween.StopByName("MoveAttackBarDown");
			heroAnim.PlayAttack(player.weapon);
			isAttacking = true;
		}

		public void OnHeroFinishAttack() {
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
				if (test >= min && test <= max) {
					if (helper == null) {
						enemyDamageTaken += damageArray [j];
//						Debug.Log ("damageArray " + damageArray [j]);
					} else {
						enemyDamageTaken += (damageArray [j] + helper.maxDamage);
//						Debug.Log ("helper.maxDamage " + helper.maxDamage);
					}
					UpdateEnemyHpBar();
					return;
				}
			}
//			Debug.Log ("NO DAMAGE");
			UpdateEnemyHpBar();
		}


		public void FinishedAnimation() {
			isAttacking = false;
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
				if (timer%5 == 0) {
					timeToCompleteVariable -= 0.05f;
				}
				timerLabel.text = timer.ToString("00");
				yield return new WaitForSeconds(1);
			}
			if(gameView.isRoundEnd != true) {
				StopCoroutine("UpdateTimer");
				gameView.isRoundEnd = true;
				winLoseLbl.text = "Times Up!";
				winLoseTweenScale.PlayForward();
				iTween.StopByName("MoveAttackBarUp");
				iTween.StopByName("MoveAttackBarDown");
				isTimesUp = true;
			}
		}

		private void UpdatePlayerHpBar() {
			if(playerDamageTaken >= playerHpHolder) {
				playerDamageTaken = playerHpHolder;
				heroAnim.PlayDeath ();
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
			AudioManager.instance.PlayHitPlayer ();
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
			if(enemyDamageTaken >= enemyHpHolder) {
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
			AudioManager.instance.PlayHitEnemy ();
		}

		public void UpdateEnemyHpBarFillAmount(float val) {
			enemyHp.fillAmount = val;
		}

		public void FinishedUpdateEnemyHpBarFillAmount() {
			if(enemyHp.fillAmount <= 0) {
				StartCoroutine(EnemyDeath());
			} else {
				StartCoroutine(EnemyAttack());
			}
		}

		public IEnumerator EnemyAttack() {
			yield return new WaitForSeconds (0.5f);
			enemyDisplay.AttackAnim();
		}

		public IEnumerator EnemyDeath() {
			yield return new WaitForSeconds (0.5f);
			enemyDisplay.DeathAnim();
			yield return new WaitForSeconds (0.5f);
			winLoseLbl.text = "You Win!";
			winLoseTweenScale.PlayForward();
			gameView.isRoundEnd = true;
		}


		public void DealDamage() {
			int enemyDamage = UnityEngine.Random.Range(monster.minDamage, monster.maxDamage);
			playerDamageTaken += enemyDamage;
//			Debug.Log ("ENEMY DAMAGE " + enemyDamage);
			UpdatePlayerHpBar();
		}

		public void FinishedWinLoseAnimation() {
			if (isTimesUp == true) {
				if (playerHp.fillAmount > enemyHp.fillAmount) {
					winLoseLbl.text = "You Win!";
					winLoseTweenScale.ResetToBeginning ();
					winLoseTweenScale.PlayForward ();
					isTimesUp = false;
//					gameView.OnFinishedRound (true);
				} else {
					winLoseLbl.text = "You Lose!";
					winLoseTweenScale.ResetToBeginning ();
					winLoseTweenScale.PlayForward ();
					isTimesUp = false;
//					gameView.OnFinishedRound (false);
				}
			} else {
				if (playerHp.fillAmount > enemyHp.fillAmount) {
					gameView.OnFinishedRound (true);
				} else {
					gameView.OnFinishedRound (false);
				}
				DisableGameUI();
			}
		}

		public int ApplyWeaponBonus() {
			switch (player.weapon) {
			case WEAPON_TYPE.SWORD:
				return 10;
			case WEAPON_TYPE.BOW:
				return 15;
			case WEAPON_TYPE.SPEAR:
				return 20;
			case WEAPON_TYPE.WHIP:
				return 30;
			default:
				return 0;
			}
		}

		public void PauseGame() {
			if (Time.timeScale == 0) {
				Time.timeScale = 1;
				pauseLbl.gameObject.SetActive(false);
				pauseCover.gameObject.SetActive(false);
			} else {
				Time.timeScale = 0;
				pauseLbl.gameObject.SetActive(true);
				pauseCover.gameObject.SetActive(true);
			}
		}

		public void OnApplicationPause() {
			if (isActive == true && Time.timeScale == 1) {
				Time.timeScale = 0;
				pauseLbl.gameObject.SetActive(true);
				pauseCover.gameObject.SetActive(true);
			}
		}

		public void FixedUpdate() {
			if(Input.GetKeyUp(KeyCode.Escape) && isActive) {
				showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
			}
		}


	}

}

