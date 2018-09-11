using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootControl : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();	
	}

	void FixedUpdate() {
		rb.MovePosition (transform.position + Vector3.up * Time.deltaTime * speed);
	}

}

