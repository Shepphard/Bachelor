using UnityEngine;
using System.Collections;

public interface Button{
	void onTouchDown ();
	void onTouchUp ();
	void onTouchStay ();
	void onTouchExit ();
}
