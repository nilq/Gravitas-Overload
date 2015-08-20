/*
Modifies the speed of the gravitron-animation so the player can get an idea of the gravitron's force.
*/
using UnityEngine;
using System.Collections;

public class GravitronAnimationModifier : MonoBehaviour
{
	void Start ()
	{
		float resultingSpeed = 1;

		Gravitron gravitron = GetComponent<Gravitron> ();
		if (gravitron != null) {
		
			resultingSpeed = f (gravitron.force);   //Calculate resulting speed

		} else {
			Debug.LogError ("Did not find a gravitron script on this object. Speed not modified.");
		}

		Animator anim = GetComponent<Animator> ();
		if (anim != null) {

			anim.speed = resultingSpeed;   //Set resulting speed

		} else {
			Debug.LogError ("There is no animation-component attatched to this gravitron.");
		}
	}



	float f (float x)
	{   
		//f(x) = 4 - 4^(1 - 0.207519|x|)
		return 4 - Mathf.Pow (4, (1f - 0.207519f * Mathf.Abs (x))); 
		//looks like this: http://www.wolframalpha.com/input/?i=f%28x%29+%3D+4+-+4%5E%281+-+0.207519%7Cx%7C%29+from+-10+to+10
		//f(1) ≈ 1 
		//for x → ∞, y → 4
	}
}
