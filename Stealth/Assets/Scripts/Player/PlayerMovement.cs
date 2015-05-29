using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public AudioClip shoutingClip;
	public float turnSmoothing = 15f;
	public float speedDampTime = 0.1f;

	private Animator anim;
	private HashIDs hash;
	private Rigidbody playerRigidbody;
	private AudioSource playerAudio;

	void Awake()
	{
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		anim.SetLayerWeight (1, 1f);
		playerRigidbody = GetComponent<Rigidbody>();
		playerAudio = GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		bool sneak = Input.GetButton ("Sneak");

		MovementManagement(h, v, sneak);
	}

	void Update()
	{
		bool shout = Input.GetButtonDown ("Attract");
		anim.SetBool (hash.shoutingBool, shout);
		AudioManagement(shout);
	}

	void MovementManagement(float horizontal, float vertical, bool sneaking)
	{
		anim.SetBool (hash.sneakingBool, sneaking);

		if (horizontal != 0f || vertical != 0f)
		{
			Rotation (horizontal, vertical);
			anim.SetFloat (hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
		}
		else
		{
			anim.SetFloat (hash.speedFloat, 0f);
		}
	}

	void Rotation(float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		Quaternion targetQuaternion = Quaternion.LookRotation (targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp (playerRigidbody.rotation, targetQuaternion, turnSmoothing * Time.deltaTime);
		playerRigidbody.MoveRotation(newRotation);
	}

	void AudioManagement(bool shout)
	{
		if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == hash.locomotionState)
		{
			if (!playerAudio.isPlaying)
			{
				playerAudio.Play();
			}
		}
		else
		{
			playerAudio.Stop();
		}

		if (shout)
		{
			AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
		}
	}
}
