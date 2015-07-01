using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {
	
	private Vector3 MP;//  mouse position
	private Vector3 SMP;// screen mouse position
	private Vector3 MMP;// mouse position in move function
	private Vector3 MSMP;// screen mouse position in move function
	private float energy;
	private const float maxenergy = 10;
	private float radius;
	private Vector3 MV; // move vector

	// Use this for initialization
	void Start () {
		energy = maxenergy;
		radius = transform.lossyScale.x / 2;
	}

	public void Move(){
		MMP = Input.mousePosition;
		MSMP = Camera.main.ScreenToWorldPoint(MP);
		MV = new Vector3 (MSMP.x, MSMP.y, transform.position.z);
		MV = MV - transform.position;
		RaycastHit help;
		if (!Physics.SphereCast(transform.position, radius, MV, out help, MV.magnitude)){
			transform.position = transform.position + MV;
		}
	}

	private bool IsMouseIn(){
		SMP = Camera.main.ScreenToWorldPoint(MP);
		Ray myray = new Ray (new Vector3(SMP.x, SMP.y, -9999), new Vector3(0, 0, 1));
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
