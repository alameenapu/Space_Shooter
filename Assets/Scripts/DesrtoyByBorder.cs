using UnityEngine;
using System.Collections;

public class DesrtoyByBorder : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
