using UnityEngine;
using System.Collections;

public class WaiterComingAnimation : MonoBehaviour {

	private bool show = false;
	private float opacity;
	private bool fading;

	private Color alphaOfText;

	// Use this for initialization
	void Start () {

		fading = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (show) {
			float delta = Time.deltaTime;
			//this.transform.position -= new Vector3(0f,Time.deltaTime*1f,0f);
			if(!fading)
			{
				Color color = this.GetComponent<Renderer>().material.color;
				color.a += 0.1f*delta;
				//this.GetComponent<Renderer>().material.SetColor(color);

				if(this.GetComponent<Renderer>().material.color.a >= 1.0f)
				{
					fading = true;
				}
			}else{
				//opacity -= 0.1f*delta;
				//alphaOfText = new Color(alphaOfText.r,alphaOfText.g,alphaOfText.b,opacity);
			}
		}
	}

	public void startAnimate()
	{
		show = true;
	}
}
