using UnityEngine;

namespace JuanDelaCruz {

	public class HeroAttackBehaviour : StateMachineBehaviour
	{
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			HeroAnim heroAnim = animator.GetComponent<HeroAnim> ();
			switch (heroAnim.weaponType) {

			case WEAPON_TYPE.SWORD:
				animator.transform.localPosition = heroAnim.targetPosSword;
				break;
			case WEAPON_TYPE.BOW:
				animator.transform.localPosition = heroAnim.targetPosWhip;
				break;
			case WEAPON_TYPE.SPEAR:
				animator.transform.localPosition = heroAnim.targetPosSpear;
				break;
			case WEAPON_TYPE.SHIELD:
				animator.transform.localPosition = heroAnim.targetPosShield;
				break;
			case WEAPON_TYPE.WHIP:
				animator.transform.localPosition = heroAnim.targetPosWhip;
				break;
			default:
				animator.transform.localPosition = heroAnim.targetPosShield;
				break;
			}

//			animator.transform.localPosition = animator.GetComponent<HeroAnim> ().targetPos;
		}
		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.GetComponent<HeroAnim>().OnFinishAttack();
			animator.transform.localPosition = animator.GetComponent<HeroAnim> ().currPosition;
//			Debug.Log("On Attack Done ");
		}
		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
//			Debug.Log("On Attack Update ");
		}
		override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
//			Debug.Log("On Attack Move " + stateInfo);
		}
		override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
//			Debug.Log("On Attack IK ");
		}
	}
}