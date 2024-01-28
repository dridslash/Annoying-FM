using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFollow : MonoBehaviour
{
	public Transform player;
	public Transform radioTarget;

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, radioTarget.position, Time.deltaTime * 5);
		Vector3 playerPos = player.position;
		playerPos.y = transform.position.y;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(playerPos - transform.position), Time.deltaTime * 5);
	}
}
