using UnityEngine;
using System.Collections;
using System.Net;
using System.Text;

using System.Data;
using Mono.Data.SqliteClient;

public class Initial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		WebClient client = new WebClient();
		string url = "http://localhost/Server/init.php?type=abs";
		byte[] html = client.DownloadData (url);
		UTF8Encoding utf = new UTF8Encoding ();
		string mystring = utf.GetString (html);

		Debug.Log (mystring);


		SqliteConnection conn;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
