using UnityEngine;
using System.Collections;

public class WaiterButton : MonoBehaviour, Button {

	public GameObject timePresenter;
	public GameObject messageSuccess;
	public GameObject messageLonger;

	private System.DateTime startTime;
	private System.DateTime endTime;
	private int timeSinceLastCall;
	
	private bool messageSent = false;
	private bool messageLongerSent = false;
	private System.DateTime lastMessageSent;

	private System.DateTime startOfAction;
	private int amountOfTries = 0;
	
	
	void Start(){
		lastMessageSent = new System.DateTime(1970,1,1);
		startOfAction = new System.DateTime(1970,1,1);
		endTime = System.DateTime.UtcNow;
	}
	
	void Update(){
		timeSinceLastCall = (int)(endTime - lastMessageSent).TotalMinutes;

		if ((System.DateTime.UtcNow - startOfAction).TotalSeconds < 10 && amountOfTries >= 2 && !messageLongerSent && timeSinceLastCall >= 2) {
			messageLonger.SendMessage("startAnimate");
			messageLongerSent = true;
		}
	}
	
	public void onTouchDown(){
		startTime = System.DateTime.UtcNow;
		startOfAction = System.DateTime.UtcNow;

		if (timeSinceLastCall >= 2) {
			timePresenter.SendMessage ("startAnimation");
		}
	}

	public void onTouchUp(){
		timePresenter.SendMessage ("abortAnimation");
		messageSent = false;
		++amountOfTries;

	}
	
	public void onTouchStay(){
		endTime = System.DateTime.UtcNow;
		
		
		int timeLapsed = (int)(endTime - startTime).TotalSeconds;

		if (!messageSent && timeSinceLastCall >= 4 && timeLapsed >= 2) {
			deployMessage();
		}
		
		
	}
	
	public void onTouchExit(){
		timePresenter.SendMessage ("abortAnimation");
		messageSent = false;
		++amountOfTries;
	}
	
	private bool deployMessage()
	{
		Debug.Log ("Deployed Message");
		timePresenter.SendMessage ("endAnimation");
		messageSuccess.SendMessage ("startAnimate");
		//messageLonger.SendMessage("startAnimate");
		messageSent = true;
		lastMessageSent = System.DateTime.UtcNow;
		startOfAction = new System.DateTime(1970,1,1);

		amountOfTries = 0;
		
		return messageSent;
	}
	
}
