using UnityEngine;
using System.Collections;

public class AnimationModifier : MonoBehaviour
{

	[Tooltip("1 is normal animation playback.")]
	public float
		speed;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Animator> ().speed = speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
