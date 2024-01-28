using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEvent : MonoBehaviour
{
	public bool isPlayerMessage;
	[TextAreaAttribute]
	public string message;
	[Header("insert same sound name used in AudioManager")]
	public string speechClipName;
	public bool completedMessageEvent;
	public bool isLastMessageEvent;

	public void Play()
	{
		AudioManager.instance.Play(speechClipName);
		DialogueManager.instance.DisplayMessage(message, isLastMessageEvent,isPlayerMessage);
		completedMessageEvent = true;
	}
}
