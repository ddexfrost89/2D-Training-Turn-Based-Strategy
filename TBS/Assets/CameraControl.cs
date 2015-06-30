using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Vector3 Step;
	private bool LS;//camera left step
	private bool RS;//camera right step
	private bool US;//camera up step
	private bool DS;//camera down step
	private const float SL = 1;// step length
	// Use this for initialization
	void Start () {
	
	}

	private void StepRight () {
		Step = new Vector3(SL, 0, 0);
	}
	
	private void StepLeft () {
		Step = new Vector3(-SL, 0, 0);
	}
	
	private void StepUp () {
		Step = new Vector3(0, SL, 0);
	}

	private void StepDown () {
		Step = new Vector3(0, -SL, 0);
	}
	
	// Update is called once per frame
	void Update () {
		LS = Input.GetKey(KeyCode.LeftArrow);
		RS = Input.GetKey(KeyCode.RightArrow);
		US = Input.GetKey(KeyCode.UpArrow);
		DS = Input.GetKey(KeyCode.DownArrow);
		if (LS)
			StepLeft ();
		else if (RS)
			StepRight ();
		else if (US)
			StepUp ();
		else if(DS)
			StepDown();
		transform.position = transform.position + Step*Time.fixedDeltaTime;
	}
}
