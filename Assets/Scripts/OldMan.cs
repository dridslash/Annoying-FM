using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour
{
	public static OldMan instance;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
	}
	public void StartDialogue()
	{
		//DialogueManager.instance.StartDialogue("OldMan");
	}

	// Update is called once per frame
	void Update()
	{

	}
}