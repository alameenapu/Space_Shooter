using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

    public float tumble;
	public float speed;
	private Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
		rb.velocity = transform.forward * speed;
	}
}
