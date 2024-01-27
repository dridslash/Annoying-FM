using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ExtendedMonoBehaviour : MonoBehaviour
{
	#region Game Manager

	protected GManager GameManager => GManager.instance;

	protected GManager.OnGameStarted onGameStarted
	{
		get => GameManager.onGameStarted;
		set => GameManager.onGameStarted = value;
	}

	protected GManager.OnGameOver onGameOver
	{
		get => GameManager.onGameOver;
		set => GameManager.onGameOver = value;
	}

	protected GManager.OnGameCompleted onGameCompleted
	{
		get => GameManager.onGameCompleted;
		set => GameManager.onGameCompleted = value;
	}

	protected GManager.OnTransitionEnded onTransitionEnded
	{
		get => GameManager.onTransitionEnded;
		set => GameManager.onTransitionEnded = value;
	}

	protected bool IsGameOver => GameManager.isGameOver;
	protected bool IsGameCompleted => GameManager.isGameCompleted;
	protected bool IsGameStarted => GameManager.isGameStarted;

	#endregion

	#region Instances

	protected GameData GameData =>GameData.instance;

	#endregion

	public bool IsFirstTime()
	{
		const int TRUE_VAL = 1;
		const int FALSE_VAL = 0;
		var isFirstTime_Key = $"is-{this}-first-start";
		var res = PlayerPrefs.GetInt(isFirstTime_Key, FALSE_VAL);
		PlayerPrefs.SetInt(isFirstTime_Key, TRUE_VAL);
		return res == FALSE_VAL;
	}

	public void LoadScene(int sceneIndex, bool instant = false)
	{
		if (instant)
		{
			SceneManager.LoadScene(sceneIndex);
		}
		else
		{
			UIManager.instance.StartLoadingScene(sceneIndex);
		}
	}

	public void DestroyChilds(bool isEditor = false)
	{
		DestroyChilds(transform, isEditor);
	}

	public void DestroyChilds(Transform transform, bool isEditor)
	{
		for (int i = transform.childCount - 1; i >= 0; i--)
		{
			if (isEditor) Object.DestroyImmediate(transform.GetChild(i).gameObject);
			else Object.Destroy(transform.GetChild(i).gameObject);
		}
	}
}
