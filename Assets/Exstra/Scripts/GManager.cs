using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
// using GameAnalyticsSDK;

namespace Exstra
{
    public class GManager : MonoBehaviour//, IGameAnalyticsATTListener
    {
        public static GManager instance;

        public delegate void OnGameStarted();
        public delegate void OnGameOver();
        public delegate void OnGameCompleted();
        public delegate void OnGameRestarted();
        public delegate void OnTransitionEnded();

        public OnGameStarted onGameStarted; //onGameStarted?.Invoke(); to start game
        public OnGameOver onGameOver; //onGameOver?.Invoke(); to lose game
        public OnGameCompleted onGameCompleted; //onGameCompleted?.Invoke(); to win game
        public OnGameRestarted onGameRestarted;
        public OnTransitionEnded onTransitionEnded;

        [Header("Status")]
        [SerializeField] public bool isGameStarted = false;
        [SerializeField] public bool isGameCompleted = false;
        [SerializeField] public bool isGameOver = false;

        [Header("Events")]
        [SerializeField] protected UnityEvent AwakeEvent;
        [SerializeField] protected UnityEvent GameStartEvent;
        [SerializeField] protected UnityEvent GameCompletedEvent;
        [SerializeField] protected UnityEvent GameOverEvent;

        [Header("EDITOR ONLY")]
        [SerializeField] KeyCode startKeyCode = KeyCode.S;
        [SerializeField] KeyCode restartKeyCode = KeyCode.R;
        [SerializeField] KeyCode gameCompletedKeyCode = KeyCode.Z;
        [SerializeField] KeyCode gameOverKeyCode = KeyCode.L;

        void Awake()
        {
            if (instance == null) { instance = this; }
            else { Destroy(this.gameObject); }

            Application.targetFrameRate = 60;
            AwakeEvent?.Invoke();

            // if (Application.platform == RuntimePlatform.IPhonePlayer)
            // {
            //     GameAnalytics.RequestTrackingAuthorization(this);
            // }
            // else
            // {
            //     GameAnalytics.Initialize();
            // }
        }

        // public void GameAnalyticsATTListenerNotDetermined()
        // {
        //     GameAnalytics.Initialize();
        // }
        // public void GameAnalyticsATTListenerRestricted()
        // {
        //     GameAnalytics.Initialize();
        // }
        // public void GameAnalyticsATTListenerDenied()
        // {
        //     GameAnalytics.Initialize();
        // }
        // public void GameAnalyticsATTListenerAuthorized()
        // {
        //     GameAnalytics.Initialize();
        // }

        public virtual void Start()
        {
            UIManager.instance.startButton.onClick.AddListener(GameStartBtn);
            UIManager.instance.restartButton.onClick.AddListener(Restart);
            UIManager.instance.nextButton.onClick.AddListener(Next);
        }

        public virtual void Update()
        {
            EDITOR_ONLY();
        }

        private void OnEnable()
        {
            onGameStarted += GameStarted;
            onGameCompleted += LvlCompleted;
            onGameOver += GameOver;
        }

        private void OnDisable()
        {
            onGameStarted -= onGameStarted;
            onGameCompleted -= LvlCompleted;
            onGameOver -= GameOver;
        }

        public void GameStartBtn()
        {
            onGameStarted?.Invoke();
        }

        private void GameStarted()
        {
            if (isGameStarted)
                return;

            Debug.Log("Game Started GManager");

            isGameStarted = true;
            GameStartEvent?.Invoke();
        }

        public void LvlCompleted()
        {
            if (isGameCompleted)
                return;

            Debug.Log("level completed GManager");

            //add level to save
            isGameCompleted = true;
            GameCompletedEvent?.Invoke();
        }

        private void GameOver()
        {
            if (isGameOver)
                return;

            Debug.Log("Game Over GManager");

            isGameOver = true;
            GameOverEvent?.Invoke();
        }

        public void Restart()
        {
            onGameRestarted?.Invoke();
            LevelManager.instance.RestartLevel();
        }

        public void Next()
        {
            LevelManager.instance.NextLvl();
        }

        public void EDITOR_ONLY()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(startKeyCode))
                onGameStarted?.Invoke();

            if (Input.GetKeyDown(restartKeyCode))
                Restart();

            if (Input.GetKeyDown(gameCompletedKeyCode))
                onGameCompleted?.Invoke();

            if (Input.GetKeyDown(gameOverKeyCode))
                onGameOver?.Invoke();
#endif
        }
    }
}