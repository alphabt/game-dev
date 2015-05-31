using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour
{
	public float onTime;
	public float offTime;

	private float timer;
	private Renderer meshRenderer;
	private Light laserLight;

	void Awake()
	{
		meshRenderer = GetComponent<Renderer>();
		laserLight = GetComponent<Light>();
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (meshRenderer.enabled && timer >= onTime)
		{
			SwitchBeam();
		}

		if (!meshRenderer.enabled && timer >= offTime)
		{
			SwitchBeam();
		}
	}

	void SwitchBeam()
	{
		timer = 0f;

		meshRenderer.enabled = !meshRenderer.enabled;
		laserLight.enabled = !laserLight.enabled;
	}
}
