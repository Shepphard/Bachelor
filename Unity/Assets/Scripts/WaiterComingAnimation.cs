using UnityEngine;
using System.Collections;

public class WaiterComingAnimation : MonoBehaviour {

	private bool show;
	private float delta;
	private bool wait;
	private bool unshow;
	private float cummulatedDelta;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		show = false;
		wait = false;
		cummulatedDelta = 0.0f;
		originalPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		delta = Time.deltaTime;

		if (show) {

			if(this.transform.localPosition.z > 0)
			{
				this.transform.localPosition -= new Vector3(0f,0f,10f*delta);
			}
			else
			{
				show = false;
				wait = true;
			}
		}

		if (wait) {
			if(cummulatedDelta < 2){
				cummulatedDelta += delta;
			}
			else
			{
				wait = false;
				unshow = true;
			}
		}

		if (unshow) {
			if(this.transform.localPosition.z < originalPosition.z)
			{
				this.transform.localPosition -= new Vector3(0f,0f,-10f*delta);
			}
			else
			{
				unshow = false;
			}
		}

	}

	public void startAnimate()
	{

		show = true;
	}
}
