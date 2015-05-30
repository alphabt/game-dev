using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
	public float fadeSpeed = 1.5f;
	private bool sceneStarting = true;
	GUITexture screenFader;

	void Awake()
	{
		screenFader = GetComponent<GUITexture>();
		screenFader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Update()
	{
		if (sceneStarting)
		{
			StartScene();
		}
	}

	void FadeToClear()
	{
		screenFader.color = Color.Lerp (screenFader.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack()
	{
		screenFader.color = Color.Lerp (screenFader.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene()
	{
		FadeToClear();

		if (screenFader.color.a <= 0.05f)
		{
			screenFader.color = Color.clear;
			screenFader.enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene()
	{
		screenFader.enabled = true;
		FadeToBlack();

		if (screenFader.color.a >= 0.95f)
		{
			Application.LoadLevel(0);
		}
	}
}
