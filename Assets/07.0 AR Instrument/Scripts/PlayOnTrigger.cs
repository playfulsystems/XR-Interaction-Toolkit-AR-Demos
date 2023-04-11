using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		GetComponent<AudioSource>().Play();
		GetComponent<Material>().SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
	}
}