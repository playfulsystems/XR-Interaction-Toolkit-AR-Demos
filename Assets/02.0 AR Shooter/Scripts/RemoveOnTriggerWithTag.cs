using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnTriggerWithTag : MonoBehaviour
{
	public string strTag;
	public AudioClip hitClip;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == strTag)
		{
			// turn off so we don't see it but still play audio when hit
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;

			// play clip if there is one
			if (hitClip != null) GetComponent<AudioSource>().PlayOneShot(hitClip);

			// destroy after 1 second to play sound
			Destroy(gameObject, 1);     

			// destroy projectile
			Destroy(other.gameObject);
		}
	}
}
