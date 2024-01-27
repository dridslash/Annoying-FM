using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
	public static GameAssets _i;

	public static GameAssets instance
	{
		get
		{
			if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
			return _i;
		}
	}

	public GameObject gObject;
}