﻿using UnityEngine;
using System.Collections;


namespace JuanDelaCruz {
	
	public class EnemyDisplay : MonoBehaviour {
		public GameUIView gameUIView;

		public GameObject enemy;
		public Animator enemyAnimator;
		public GameObject[] EnemyGo;
		public SpriteRenderer enemyDisplay;
		public Sprite EnemySpt;

		public void ChangeEnemy(MONSTER_TYPE monsterType) {
			if (enemy != null) {
				Destroy(enemy);
			}
			int enemyIndex = 0;
			switch (monsterType) {
			case MONSTER_TYPE.ASWANG:
				enemyIndex = 1;
				break;
			case MONSTER_TYPE.DRACULA:
				enemyIndex = 2;
				break;
			case MONSTER_TYPE.DWENDE:
				enemyIndex = 3;
				break;
			case MONSTER_TYPE.KAPRE:
				enemyIndex = 4;
				break;
			case MONSTER_TYPE.PANIKI:
				enemyIndex = 5;
				break;
			case MONSTER_TYPE.TIKBALANG:
				enemyIndex = 6;
				break;
			case MONSTER_TYPE.TIYANAK:
				enemyIndex = 7;
				break;
			case MONSTER_TYPE.UWAK:
				enemyIndex = 8;
				break;
			case MONSTER_TYPE.WHITE_LADY:
				enemyIndex = 9;
				break;
			}
			enemy = Instantiate (EnemyGo [enemyIndex], Vector3.zero, Quaternion.identity) as GameObject;
			enemy.transform.parent = transform;
			enemy.transform.localPosition = EnemyGo [enemyIndex].transform.localPosition;
			enemyAnimator = enemy.GetComponent<Animator> () as Animator;
			enemy.GetComponent<EnemyAnim>().enemyDisplay = this;
		}


		public void AttackAnim() {
			enemyAnimator.SetTrigger("attack");
//			enemy.transform.localPosition = enemyAnimator.targetPosition;
		}

		public void OnFinishAttack() {
			gameUIView.DealDamage();
		}

		public void DeathAnim() {
			enemyAnimator.SetTrigger("death");
		}

		public void OnFinishDeath() {
			
		}


	}
}
