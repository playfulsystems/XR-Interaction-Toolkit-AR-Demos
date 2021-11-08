using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public Material ActiveMaterial;
	public Material InActiveMaterial;
	TargetManager mgr;
	bool isOn;

	void Start()
	{
		isOn = false;
		mgr = transform.parent.GetComponent<TargetManager>();
	}

	public void Toggle(bool newVal)
	{
		isOn = newVal;
		if (isOn)
		{
			GetComponent<MeshRenderer>().material = ActiveMaterial;
			GetComponent<CapsuleCollider>().enabled = true;
		}
		else
		{
			GetComponent<MeshRenderer>().material = InActiveMaterial;
			GetComponent<CapsuleCollider>().enabled = false;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		Toggle(false);
		Destroy(other.gameObject);
		mgr.SelectNewTarget(this);

		GetComponent<AudioSource>().Play();
	}

}
