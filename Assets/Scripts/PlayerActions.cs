using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerActions : MonoBehaviour
{
	public PlayerController playerController;
	bool waitingForWakeUp = true;
	void Start()
	{
		playerController = GetComponent<PlayerController>();
		UIManager.instance.SetBlackScreen(true);
		UIManager.instance.SetBlackScreen(false,5);
		DOTween.Sequence().AppendInterval(5).AppendCallback(() => {
		Prompt("Tap -Space- to wake up");
		});

		AudioManager.instance.Play("Sleeping");
		AudioManager.instance.Play("RadioMusic1");
	}

	// Update is called once per frame
	void Update()
	{
		if (waitingForWakeUp && Input.GetKeyDown(KeyCode.Space))
		{
			playerController.WakeUp();
			Prompt("");
			waitingForWakeUp = false;
		}
		//if(waitingForWakeUp && Input.get)
	}
	public void Prompt(string text)
	{
		UIManager.instance.prompt.SetText(text);
	}
}
