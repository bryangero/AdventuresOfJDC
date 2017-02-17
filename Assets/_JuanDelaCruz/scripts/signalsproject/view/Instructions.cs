using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {
	
	public class Instructions : Credits {

		[SerializeField] private GameObject goInstruction1;
		[SerializeField] private GameObject goInstruction2;
		[SerializeField] private GameObject goInstruction3;

		public void ShowInstruction() {
			ShowInstructions1();
			goInstruction.SetActive(true);
			goNonInstruction.SetActive(false);
		}

		public void HideInstruction() {
			goInstruction.SetActive(false);
			goNonInstruction.SetActive(true);
		}

		public void EndInstructions() {
			HideInstruction ();
		}

		public void ShowInstructions1() {
			goInstruction1.SetActive (true);
			goInstruction2.SetActive (false);
			goInstruction3.SetActive (false);

		}
		public void ShowInstructions2() {
			goInstruction2.SetActive (true);
			goInstruction1.SetActive (false);
			goInstruction3.SetActive (false);

		}
		public void ShowInstructions3() {
			goInstruction3.SetActive (true);
			goInstruction2.SetActive (false);
			goInstruction1.SetActive (false);

		}
	}

}