using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MauroControl : MonoBehaviour
{

	public Vector2 hiddenPosition = new Vector2 (0, -7f);
	public Vector2 startPosition = new Vector2 (0, -3f);

	public Rigidbody2D rb;
	public float speed = 5f;
	public float shootInterval = 1f;

	public GameObject shootPrefab;

	bool started = false;
	public bool isDead = false;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		transform.position = hiddenPosition;

		Hashtable args = new Hashtable ();
		args.Add ("delay", 1f);
		args.Add ("easetype", "easeOutBack");
		args.Add ("time", 2f);
		args.Add ("oncomplete", "Ready");
		args.Add ("y", startPosition.y);
		//args.Add ("position", startPosition);
		args.Add ("looptype", "none");
		args.Add ("speed", 2.5f);
		iTween.MoveTo (gameObject, args);
	}

	void Ready ()
	{
		started = true;
		StartCoroutine (Shoot());
	}

	IEnumerator Shoot () {
		while (true) {
			if (!isDead) {
				SoundManager.getInstance ().Play (SoundManager.getInstance ().sfxSthoot, SoundManager.getInstance ().sfxSource, false);

				GameObject.Instantiate (shootPrefab, transform.position, Quaternion.identity);
			
				yield return new WaitForSeconds (shootInterval);
				if (shootInterval <= 0) {
					yield return null;
				}
			}
		}
	}

	void FixedUpdate ()
	{
		if (!started) {
			return;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.MovePosition (transform.position + (-transform.right) * Time.deltaTime * speed);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.MovePosition (transform.position + transform.right * Time.deltaTime * speed);
		}

		#if UNITY_EDITOR

		if (Input.GetMouseButton (0)) {
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			rb.MovePosition (worldPoint - transform.position * Time.deltaTime * speed);
		}
		#else
		if(Input.touchCount > 0){
			Touch t = Input.touches[0];

			Vector3 worldPoint = Camera.main.ScreenToWorldPoint (t.position);
			rb.MovePosition (worldPoint - transform.position * Time.deltaTime * speed);

		}
		#endif
	}
}
