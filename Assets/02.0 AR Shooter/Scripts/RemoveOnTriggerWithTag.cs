using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnTriggerWithTag : MonoBehaviour
{
	public string strTag;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == strTag)
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
