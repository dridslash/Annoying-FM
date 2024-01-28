//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Narrator : MonoBehaviour
//{
//	public List<NarrativeEvent> narrativeEvents;
//	private void Start() {
//		narrativeEvents = new List<NarrativeEvent>(GetComponentsInChildren<NarrativeEvent>());
//	}

//	public void StartNarrativeEvent(string eventName)
//	{
//		// Find narrative event with the given name
//		NarrativeEvent narrativeEvent = narrativeEvents.Find(n => n.name == eventName);
//		if (narrativeEvent == null)
//		{
//			Debug.LogWarning($"Narrative event with name {eventName} not found");
//			return;
//		}

//		// Start narrative event
//		narrativeEvent.StartEvent();
//	}

//	public void EndNarrativeEvent(string eventName)
//	{
//		// Find narrative event with the given name
//		NarrativeEvent narrativeEvent = narrativeEvents.Find(n => n.name == eventName);
//		if (narrativeEvent == null)
//		{
//			Debug.LogWarning($"Narrative event with name {eventName} not found");
//			return;
//		}

//		// End narrative event
//		narrativeEvent.EndEvent();
//	}

//}
