using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour
{
	public float fadeSpeed = 2f;
	public float highIntensity = 2f;
	public float lowIntensity = 0.5f;
	public float changeMargin = 0.2f;
	public bool alarmOn;

	private float targetIntensity;
	private Light mainLight;

	void Awake()
	{
		mainLight = GetComponent<Light>();
		mainLight.intensity = 0f;
		targetIntensity = highIntensity;
	}

	void Update()
	{
		if (alarmOn)
		{
			mainLight.intensity = Mathf.Lerp (mainLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
			CheckTargetIntensity();
		}
		else
		{
			mainLight.intensity = Mathf.Lerp (mainLight.intensity, 0f, fadeSpeed * Time.deltaTime);
		}
	}

	void CheckTargetIntensity()
	{
		if (Mathf.Abs (targetIntensity - mainLight.intensity) < changeMargin)
		{
			if (targetIntensity == highIntensity)
			{
				targetIntensity = lowIntensity;
			}
			else
			{
				targetIntensity = highIntensity;
			}
		}
	}
}
