using UnityEngine;
using System.Collections;

public class KasseDummy : MonoBehaviour {

	private Dictionary<Article, int> articles;
	private int tableID;

	public void Start()
	{
		articles = new ArrayList ();
	}

	public void addArticle(int id, float preis)
	{
		articles.Add (new Article (id, preis));
	}
}
