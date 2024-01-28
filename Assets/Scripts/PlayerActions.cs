using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerActions : MonoBehaviour
{
	public PlayerController playerController;
	bool waitingForWakeUp = true;
	bool waitingForGameEnd = true;
	bool canStartNarrator = false;
	void Start()
	{
		playerController = GetComponent<PlayerController>();
		UIManager.instance.SetBlackScreen(true);
		UIManager.instance.SetBlackScreen(false, 5);
		DOTween.Sequence().AppendInterval(5).AppendCallback(() =>
		{
			Prompt("(Tap -Space- to wake up)");
		});

		AudioManager.instance.Play("Sleeping");
		AudioManager.instance.Play("RadioMusic1");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (waitingForWakeUp)
			{
				playerController.WakeUp();
				Prompt("");
				waitingForWakeUp = false;
			}
			else if (canStartNarrator)
			{
				DialogueManager.instance.PlayNarrator(currentNarrator);
			}
			else if (waitingForGameEnd)
			{
				waitingForGameEnd = false;
			}
		}
		//if(waitingForWakeUp && Input.get)
	}
	public void Prompt(string text)
	{
		UIManager.instance.prompt.SetText(text);
	}
	string currentNarrator;
	public void CanStartNarrator(bool canStart, string narratorname)
	{
		canStartNarrator = canStart;
		currentNarrator = narratorname;
	}
}
