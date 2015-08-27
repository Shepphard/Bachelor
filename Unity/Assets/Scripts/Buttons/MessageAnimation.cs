using UnityEngine;
using System.Collections;

public class MessageAnimation : MonoBehaviour {

	private float delta;

	private bool show = false;
	private bool wait = false;
	private bool unshow = false;

	private float cummulatedDelta;
	
	private Vector3 originalPosition;
	
	// Use this for initialization
	void Start () {
		originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		delta = Time.deltaTime;

		if (show) {
			Vector3 moveVector = new Vector3(0,10f*delta,0);

			if( this.transform.position.y > 5)
			{
				this.transform.position -= moveVector;
			}
			else
			{
				show = false;
				wait = true;
			}

		}
		if (wait) {
			cummulatedDelta += delta;
			if(cummulatedDelta >= 2)
			{
				wait = false;
				unshow = true;
			}
		}
		if (unshow) {
			Vector3 moveVector = new Vector3(0,10f*delta,0);

			if( this.transform.position.y < originalPosition.y)
			{
				this.transform.position += moveVector;
			}
			else
			{
				unshow = false;
			}

				

		}

		
	}

	public bool getUnshow()
	{
		return unshow;
	}

	public void startAnimate()
	{
		
		show = true;
	}
}
