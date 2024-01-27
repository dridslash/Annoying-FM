using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables instance;

    [Header("CPI Variables")]
    public bool CPIEnabled;

    // [Header("Change these")]

    // [Header("Don't change these")]

    // [Header("Don't change these, They're dynamically set On GamePlay")]

    void Awake()
    {
        instance = this;
    }
}
