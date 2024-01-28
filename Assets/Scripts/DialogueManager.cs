using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager instance;
	public List<Narrator> narrators;

	public bool talkedToOldMan = false;
	public bool talkedToBikeRacer = false;
	public GameObject enableAfterTalkingToOldMan;
	public GameObject disableAfterTalkingToOldMan;
	public GameObject enableAfterTalkingToBikeRacer;
	public GameObject disableAfterTalkingToBikeRacer;
	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		narrators = new List<Narrator>(GetComponentsInChildren<Narrator>());
	}

	public void DisplayMessage(string message, bool isLastMessageEvent, bool isPlayerMessage)
	{
		if (isPlayerMessage)
		{
			UIManager.instance.DisplayMessage("You:\n\n" + message, isLastMessageEvent);
		}
		else
		{
			UIManager.instance.DisplayMessage(currentNarrator + ":\n\n" + message, isLastMessageEvent);
		}
	}

	string currentNarrator;
	public void PlayNarrator(string name)
	{
		UIManager.instance.messageBox.SetActive(true);
		Narrator n = narrators.Find(narrator => narrator.name == name);

		if (n == null) // debugging
		{
			Debug.LogWarning("Narrator:" + name + " missing.");
			return;
		}

		currentNarrator = name;
		n.Play();
	}

	public int NarratorNarrationsLeft(string narratorName)
	{
		Narrator n = narrators.Find(narrator => narrator.name == narratorName);

		if (n == null) // debugging
		{
			Debug.LogWarning("Narrator:" + name + " missing.");
			return 0;
		}

		int narrationCounter = 0;
		for (int i = 0; i < n.narrativeEvents.Count; i++)
		{
			if (!n.narrativeEvents[i].completedNarrativeEvent)
				narrationCounter++;
		}
		return narrationCounter;
	}

	public void StopNarration()
	{
		UIManager.instance.messageText.SetText("");
		UIManager.instance.messageBox.gameObject.SetActive(false);
	}
}

