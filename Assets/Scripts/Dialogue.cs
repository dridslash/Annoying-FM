//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Dialogue : MonoBehaviour
//{
//	public List<Narrator> narrators;
	
//	public List<MessageEvent> messageEvents;

//	private void Start()
//	{
//		narrators = new List<Narrator>(GetComponentsInChildren<Narrator>());
//		messageEvents = new List<MessageEvent>(GetComponentsInChildren<MessageEvent>());
//	}

//	public void StartDialogue(string narratorName)
//	{
//		// Find narrator with the given name
//		Narrator narrator = narrators.Find(n => n.name == narratorName);
//		if (narrator == null)
//		{
//			Debug.LogWarning($"Narrator with name {narratorName} not found");
//			return;
//		}

//		// Start dialogue
//		narrator.StartDialogue();
//	}

//	public void EndDialogue(string narratorName)
//	{
//		// Find narrator with the given name
//		Narrator narrator = narrators.Find(n => n.name == narratorName);
//		if (narrator == null)
//		{
//			Debug.LogWarning($"Narrator with name {narratorName} not found");
//			return;
//		}

//		// End dialogue
//		narrator.EndDialogue();
//	}

//	public void StartMessageEvent(string eventName)
//	{
//		// Find message event with the given name
//		MessageEvent messageEvent = messageEvents.Find(n => n.name == eventName);
//		if (messageEvent == null)
//		{
//			Debug.LogWarning($"Message event with name {eventName} not found");
//			return;
//		}

//		// Start message event
//		messageEvent.StartEvent();
//	}

//	public void EndMessageEvent(string eventName)
//	{
//		// Find message event with the given name
//		MessageEvent messageEvent = messageEvents.Find(n => n.name == eventName);
//		if (messageEvent == null)
//		{
//			Debug.LogWarning($"Message event with name {eventName} not found");
//			return;
//		}

//		// End message event
//		messageEvent.EndEvent();
//	}

//	//public void StartDialogueEvent(string narratorName, string eventName)
//	//{
//	//	// Find narrator with the given name
//	//	Narrator narrator = narrators.Find(n => n.name == narratorName);
//	//	if (narrator == null)
//	//	{
//	//		Debug.LogWarning($"Narrator with name {narratorName} not found");
//	//		return;
//	//	}

//	//	// Find dialogue event with the given name
//	//	DialogueEvent dialogueEvent = narrator.dialogueEvents.Find(n => n.name == eventName);
//	//	if (dialogueEvent == null)
//	//	{
//	//		Debug.LogWarning($"Dialogue event with name {eventName} not found");
//	//		return;
//	//	}

//	//	// Start dialogue event
//	//	dialogueEvent.StartEvent();
//	//}

//	//public void EndDialogueEvent(string narratorName, string eventName)
//	//{
//	//	// Find narrator with the given name
//	//	Narrator narrator = narrators.Find(n => n.name == narratorName);
//	//	if (narrator == null)
//	//	{
//	//		Debug.LogWarning($"Narrator with name {narratorName} not found");
//	//		return;
//	//	}

//	//	// Find dialogue event with the given name
//	//	DialogueEvent dialogueEvent = narrator.dialogueEvents.Find(n => n.name == eventName);
//	//	if (dialogueEvent == null)
//	//	{
//	//		Debug.LogWarning($"Dialogue event with name {eventName} not found");
//	//		return;
//	//	}

//	//	// End dialogue event
//	//	dialogueEvent.EndEvent();
//	//}

//	//public void StartDialogueEvent(string narratorName, string eventName, string message)
//	//{
//	//	// Find narrator with the given name
//	//	Narrator narrator = narrators.Find(n => n.name == narratorName);
//	//	if (narrator == null)
//	//	{
//	//		Debug.LogWarning($"Narrator with name {narratorName} not found");
//	//		return;
//	//	}

//	//	// Find dialogue event with the given name
//	//	DialogueEvent dialogueEvent = narrator.dialogueEvents.Find(n => n.name == eventName);
//	//	if (dialogueEvent == null)
//	//	{
//	//		Debug.LogWarning($"Dialogue event with name {eventName} not found");
//	//		return;
//	//	}

//	//	// Start dialogue event
//	//	dialogueEvent.StartEvent(message);
//	//}

//	//public void EndDialogueEvent(string narratorName, string eventName, string message)
//	//{
//	//	// Find narrator with the given name
//	//	Narrator narrator = narrators.Find(n => n.name == narratorName);
//	//	if (narrator == null)
//	//	{
//	//		Debug.LogWarning($"Narrator with name {narratorName} not found");
//	//		return;
//	//	}

//	//	// Find dialogue event with the given name
//	//	DialogueEvent dialogueEvent = narrator.dialogueEvents.Find(n => n.name == eventName);
//	//	if (dialogueEvent == null)
//	//	{
//	//		Debug.LogWarning($"Dialogue event with name {eventName} not found");
//	//		return;
//	//	}

//	//	// End dialogue event
//	//	dialogueEvent.EndEvent(message);
//	//}
//}
