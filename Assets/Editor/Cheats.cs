using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Cheats : MonoBehaviour
{
	[MenuItem("Hoptimist/Cheats/Cheat1")]
	public static void Cheat1()
	{
		Debug.Log("Triggered Cheat1");
	}

	[MenuItem("Hoptimist/Cheats/Cheat2")]
	public static void Cheat2()
	{
		Debug.Log("Triggered Cheat2");
	}
}