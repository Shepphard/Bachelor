﻿using UnityEngine;
using System.Collections;

public class ButtonTimer : MonoBehaviour {

	private bool animating = false;
	private bool aborted = false;
	private bool success = false;


	private Vector3 originalSize;
	// Use this for initialization
	void Start () {
		originalSize = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float delta = Time.deltaTime;

		if (animating) {
			if (!aborted && !success) {
				this.transform.localScale += new Vector3 (delta * 0.1f, delta * 0.1f, delta * 0.1f);
			}else if(aborted){
				finishUp (false, delta);
			}else if(success){
				finishUp (true, delta);
			}
		}
	}

	public void startAnimation()
	{
		animating = true;
	}

	public void abortAnimation()
	{
		aborted = true;
	}

	public void endAnimation()
	{
		success = true;
	}

	private float degree = 70;

	private void finishUp(bool wasSuccessfull, float delta)
	{
		if(wasSuccessfull && this.transform.localScale.x >= originalSize.x){
			//finishing when was succesfull

			this.transform.localScale += new Vector3 (delta * Mathf.Cos(degree++/180f*Mathf.PI) * 5f, delta * Mathf.Cos(degree++/180f*Mathf.PI) *5f, delta *Mathf.Cos(degree++/180f*Mathf.PI) * 5f);

		}
		else if(!wasSuccessfull && this.transform.localScale.x >= originalSize.x){
			this.transform.localScale += new Vector3 (-delta * 1f, -delta * 1f, -delta * 1f);
		}else{
			animating = false;
			aborted = false;
			success = false;
		}
	}

}
