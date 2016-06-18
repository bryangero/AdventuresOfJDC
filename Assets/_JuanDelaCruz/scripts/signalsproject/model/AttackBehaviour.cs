using UnityEngine;

namespace JuanDelaCruz {

	public class AttackBehaviour : StateMachineBehaviour
	{
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.transform.localPosition = animator.GetComponent<EnemyAnim> ().targetPos;
		}
		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.GetComponent<EnemyAnim>().OnFinishAttack();
			animator.transform.localPosition = animator.GetComponent<EnemyAnim> ().currPosition;
			Debug.Log("On Attack Done ");
		}
		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Debug.Log("On Attack Update ");
		}
		override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Debug.Log("On Attack Move " + stateInfo);
		}
		override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Debug.Log("On Attack IK ");
		}
	}
}