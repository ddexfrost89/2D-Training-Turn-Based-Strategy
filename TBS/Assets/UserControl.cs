using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {
	
	private Vector3 MP;//  mouse position
	public Vector3 SMP;// screen mouse position
	private Vector3 Scale;
	private Vector3 teststep = new Vector3(1, 0, 0);
	public int number;
	public int type;

	// Use this for initialization
	void Start () {
	
	}

	private bool IsMouseIn(){
		SMP = Camera.main.ScreenToWorldPoint(MP);
		Scale = transform.lossyScale;
		Ray myray = new Ray (new Vector3(SMP.x, SMP.y, -9899), new Vector3(0, 0, 1));
		RaycastHit help;
		if (Physics.Raycast(myray, out help))
				if(help.collider.gameObject == gameObject)
						return true;
		return false;
	}

	private bool IsTargeted(){
		MP = Input.mousePosition;
		return Input.GetKeyDown(KeyCode.Mouse0) && IsMouseIn();
	}

	// Update is called once per frame
	void Update () {
		if (IsTargeted ())
			gameObject.GetComponentInParent<GameControl> ().targetchild = gameObject;
	}
}
