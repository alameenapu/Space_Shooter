using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponController : MonoBehaviour {
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	private AudioSource ads;

	void Start ()
	{
		ads = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		ads.Play ();
	}

}
