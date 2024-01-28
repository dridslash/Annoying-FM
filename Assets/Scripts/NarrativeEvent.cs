using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeEvent : MonoBehaviour
{
	public List<MessageEvent> messageEvents;
	public bool completedNarrativeEvent;
	public bool isLastNarrativeEvent;
	void Awake()
	{
		messageEvents = new List<MessageEvent>(GetComponentsInChildren<MessageEvent>());
	}

	public void Play()
	{
		for (int i = 0; i < messageEvents.Count; i++)
		{
			MessageEvent m = messageEvents[i];
			if (!m.completedMessageEvent)
			{
				if(i==messageEvents.Count-1)
					m.isLastMessageEvent = true;
				else
					m.isLastMessageEvent = false;
				m.Play();
				return;
			}

			if(i == messageEvents.Count - 1)
			{
				DialogueManager.instance.enableAfterTalkingToOldMan.SetActive(true);
				DialogueManager.instance.disableAfterTalkingToOldMan.SetActive(false);
				completedNarrativeEvent = true;
				DialogueManager.instance.StopNarration();
			}
		}
	}
}
