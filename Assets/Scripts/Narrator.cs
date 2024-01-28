using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
	public string narratorName;
	public List<NarrativeEvent> narrativeEvents;
	public bool completedNarrator;
	private void Awake()
	{
		narrativeEvents = new List<NarrativeEvent>(GetComponentsInChildren<NarrativeEvent>());
	}
	public void Play()
	{
		for (int i = 0; i < narrativeEvents.Count; i++)
		{
			NarrativeEvent n = narrativeEvents[i];
			if (!n.completedNarrativeEvent)
			{
				if (i == narrativeEvents.Count - 1)
					n.isLastNarrativeEvent = true;
				else
					n.isLastNarrativeEvent = false;

				n.Play();
				return;
			}

			if (i == narrativeEvents.Count - 1)
			{
				completedNarrator = true;
				DialogueManager.instance.StopNarration();
			}
		}
	}
}
