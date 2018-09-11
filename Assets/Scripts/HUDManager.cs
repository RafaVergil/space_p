using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	public Text txtReady;
	public MauroControl mauro;

	IEnumerator Start (){
		float timeToWait = 2f;

		txtReady.gameObject.SetActive (true);
		yield return new WaitForSeconds (timeToWait / 4);
		txtReady.gameObject.SetActive (false);
		yield return new WaitForSeconds (timeToWait / 4);
		txtReady.gameObject.SetActive (true);
		yield return new WaitForSeconds (timeToWait / 4);
		txtReady.gameObject.SetActive (false);
		yield return new WaitForSeconds (timeToWait / 4);
		txtReady.gameObject.SetActive (true);
		yield return new WaitForSeconds (timeToWait / 4);
		txtReady.text = "GO!!";
		yield return new WaitForSeconds (1f);
		txtReady.gameObject.SetActive (false);
	}

	void OnGUI() {
		if (GUI.Button (new Rect (0, 0, 30, 50), "<")) {
			if (mauro.shootInterval > 0) {
				mauro.shootInterval -= 0.1f;
			}
		}

		GUI.TextField (new Rect(30, 0, 100, 50), "Shoot Speed: \n" + mauro.shootInterval.ToString());

		if (GUI.Button (new Rect (130, 0, 30, 50), ">")) {
			if (mauro.shootInterval < 1f) {
				mauro.shootInterval += 0.1f;
			}
		}
	}
}
