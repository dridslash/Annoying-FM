using UnityEngine;
using System;
using System.IO;

namespace Exstra
{
    public class GameData : ExtendedMonoBehaviour
    {
        #region Singletone

        public static GameData instance { get; private set; }

        #endregion

        public static Action onInitialized;

        [HideInInspector] public bool initialized = false;

        [SerializeField] KeyCode coinKeyCode = KeyCode.C;
        [SerializeField] int coinsGiveAmount = 100;

        [Space]

        public Action onCoinsChanged;
        public Action onLvlChanged; //might be useful for checking special levels

        [SerializeField] int coins = 0;
        [SerializeField] int level = 0;

        public int Coins
        {
            get => PlayerPrefs.GetInt("COINS", coins);
            set
            {
                coins = value;
                PlayerPrefs.SetInt("COINS", value);
                onCoinsChanged?.Invoke();
            }
        }

        public int Level
        {
            get => PlayerPrefs.GetInt("LEVEL", level);
            set
            {
                level = value;
                PlayerPrefs.SetInt("LEVEL", value);
                onLvlChanged?.Invoke();
            }
        }

        private void Awake()
        {
            if (instance == null) { instance = this; }
            else { Destroy(this.gameObject); }

            if (IsFirstTime())
                SaveData();

            LoadData();

            initialized = true;
            onInitialized?.Invoke();
        }

        private void SaveData()
        {
            coins = Coins;
            level = Level;
        }

        private void LoadData()
        {
            coins = Coins;
            level = Level;
        }

        private void Update()
        {
            EDITOR_ONLY();
        }

        void EDITOR_ONLY()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(coinKeyCode))
            {
                Coins += coinsGiveAmount;
            }
#endif
        }
    }
}