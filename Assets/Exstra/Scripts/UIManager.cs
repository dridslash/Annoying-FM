using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using DG.Tweening;

namespace Exstra
{
    public class UIManager : ExtendedMonoBehaviour
    {
        public static UIManager instance;

        public float UISpeed = 0.3f;

        [Header("Coin UI")]
        [SerializeField] TextMeshProUGUI coinText;
        [SerializeField] string startValue = "";
        [SerializeField] string endValue = "";

        [Header("Buttons")]
        [SerializeField] public Button startButton;
        [SerializeField] public Button restartButton;
        [SerializeField] public Button nextButton;

        [Header("Load Scene")]
        [SerializeField] public bool sceneLoadTransition;
        [SerializeField] public RectTransform rabbitTransition;
        [SerializeField] public TMP_Text loadingText;


        private void Awake()
        {
            if (instance == null) { instance = this; }
            else { Destroy(this.gameObject); }

            if (sceneLoadTransition)
            {
                EndLoadingScene();
            }
            else
            {
                rabbitTransition.gameObject.SetActive(false);
            }
        }

        private void OnValidate()
        {
            if (!Application.isPlaying)
            {
                coinText.text = $"{startValue}{0}{endValue}";
            }
        }

        void Start()
        {
            SetupUI();

            base.GameData.onCoinsChanged += CoinsUI;
            base.GameData.onCoinsChanged?.Invoke();

            base.onGameStarted += GameStartedUI;
            base.onGameOver += GameOverUI;
            base.onGameCompleted += GameCompletedUI;
            base.onTransitionEnded += StartUI;
        }

        private void OnDisable()
        {
            base.GameData.onCoinsChanged -= CoinsUI;
        }

        public void StartLoadingScene(int sceneIndex)
        {
            if (sceneLoadTransition)
            {
                rabbitTransition.gameObject.SetActive(true);
                rabbitTransition.transform.localPosition = Vector3.left * 4000;
                rabbitTransition.DOLocalMove(Vector3.zero, 1f).SetEase(Ease.InSine).OnComplete(() =>
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
                });
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
            }
        }

        public void EndLoadingScene()
        {
            rabbitTransition.gameObject.SetActive(true);
            rabbitTransition.transform.localPosition = Vector3.zero;

            loadingText.SetText("Loading\n");
            DOVirtual.DelayedCall(0.2f, () =>
            {
                loadingText.SetText("Loading\n.");
                DOVirtual.DelayedCall(0.2f, () =>
                {
                    loadingText.SetText("Loading\n..");
                    DOVirtual.DelayedCall(0.2f, () =>
                    {
                        loadingText.SetText("Loading\n...");
                    });
                });
            });
            DOVirtual.DelayedCall(0.5f, () =>
            {
                rabbitTransition.DOLocalMove(Vector3.right * 4000, 1f).SetEase(Ease.InSine).OnComplete(() =>
                {
                    onTransitionEnded?.Invoke();
                });
            });
        }

        void SetupUI()
        {
            if (!IsGameStarted)
            {
                startButton.gameObject.SetActive(true);
            }
            restartButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);

            coinText.transform.parent.localScale = Vector3.zero;

            if (!sceneLoadTransition)
            {
                coinText.transform.parent.DOScale(Vector3.one, UISpeed);
            }
        }

        void StartUI()
        {
            coinText.transform.parent.DOScale(Vector3.one, UISpeed);
        }

        private void GameStartedUI()
        {
            startButton.gameObject.SetActive(false);
        }

        void GameOverUI()
        {
            restartButton.gameObject.SetActive(true);
            restartButton.transform.localScale = Vector3.zero;
            restartButton.transform.DOScale(Vector3.one, UISpeed);
        }

        void GameCompletedUI()
        {
            nextButton.gameObject.SetActive(true);
            nextButton.transform.localScale = Vector3.zero;
            nextButton.transform.DOScale(Vector3.one, UISpeed);
        }

        private void CoinsUI() => UpdateCoins($"{base.GameData.Coins}");

        private void UpdateCoins(string value)
        {
            coinText.text = $"{startValue}{value}{endValue}";
            coinText.transform.localScale = Vector3.one * 1.5f;
            DOTween.Kill(coinText.transform);
            coinText.transform.DOScale(Vector3.one, UISpeed);
        }
    }
}