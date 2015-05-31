using UnityEngine;
using System.Collections;

public class LaserPlayerDetection : MonoBehaviour
{
	private GameObject player;
	private LastPlayerSighting lastPlayerSighting;
	private Renderer meshRenderer;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag(Tags.player);
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
		meshRenderer = GetComponent<Renderer>();
	}

	void OnTriggerStay(Collider other)
	{
		if (meshRenderer.enabled)
		{
			if (other.gameObject == player)
			{
				lastPlayerSighting.position = other.transform.position;
			}
		}
	}
}
