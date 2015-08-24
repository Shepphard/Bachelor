using UnityEngine;
using System.Collections;

public class WaiterButton : MonoBehaviour, Button {
	
	public Color defaultColour;
	public Color selectedColour;
	
	public GameObject timePresenter;
	public GameObject[] messages = new GameObject[3];
	
	private Material mat;
	
	private System.DateTime startTime;
	private System.DateTime endTime;
	private int timeSinceLastCall;
	
	private bool messageSent = false;
	private System.DateTime lastMessageSent;
	
	
	void Start(){
		mat = GetComponent<Renderer>().material;
		lastMessageSent = new System.DateTime(1970,1,1);
		endTime = System.DateTime.UtcNow;
	}
	
	void Update(){
		timeSinceLastCall = (int)(endTime - lastMessageSent).TotalMinutes;
	}
	
	public void onTouchDown(){
		mat.color = selectedColour;
		startTime = System.DateTime.UtcNow;
		if (timeSinceLastCall >= 2) {
			timePresenter.SendMessage ("startAnimation");
		}
	}

	public void onTouchUp(){
		mat.color = defaultColour;
		messageSent = false;


		timePresenter.SendMessage ("abortAnimation");


	}
	
	public void onTouchStay(){
		endTime = System.DateTime.UtcNow;
		
		
		int timeLapsed = (int)(endTime - startTime).TotalSeconds;

		if (!messageSent && timeSinceLastCall >= 2 && timeLapsed >= 2) {
			deployMessage();
		}
		
		
	}
	
	public void onTouchExit(){
		mat.color = defaultColour;
		timePresenter.SendMessage ("abortAnimation");
		messageSent = false;
	}
	
	private bool deployMessage()
	{
		Debug.Log ("Deployed Message");
		timePresenter.SendMessage ("endAnimation");
		messages[0].SendMessage ("startAnimate");
		
		messageSent = true;
		lastMessageSent = System.DateTime.UtcNow;
		
		return messageSent;
	}
	
}
