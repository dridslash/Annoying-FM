#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class Replacer : EditorWindow
{
    [MenuItem("Hoptimist/Replacer")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Replacer>("Replace GameObject");
    }

    GameObject pref;
    bool ignoreScale;

    private void OnGUI()
    {
        GUI.skin.label.wordWrap = true;

        string instructions = "Select GameObjects to be replaced, script will go through each selected " +
           " GameObject and check it is active in Hierarchy, then find path to the asset and instansiate " +
           "it - set Position and Parent to be same as selection and destroy the old one.\n\n" +
           "Known issues: \n" +
           "   - Only works if GameObject hasn't been renamed.\n";

        // GUILayout.Label("Instructions", EditorStyles.boldLabel);
        // GUILayout.Label(instructions);
        pref = (GameObject)EditorGUILayout.ObjectField("To Instantiate", pref, typeof(GameObject));
        if (pref == null)
        {
            return;
        }

        GUILayout.Space(10);
        // GUILayout.Label("What happens to replaced objects:", EditorStyles.boldLabel);
        ignoreScale = (bool)EditorGUILayout.Toggle("Don't copy scale", ignoreScale);
        GUILayout.Space(10);

        if (GUILayout.Button("Replace Selected GameObjects"))
        {
            if (UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage() != null)
            {
                EditorUtility.SetDirty(UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage().prefabContentsRoot);
            }
            GameObject[] selection = Selection.gameObjects;
            foreach (GameObject item in selection)
            {
                if (item.activeInHierarchy)
                {
                    // TODO: Refactor so we can avoid this nested chaos.
                    // TODO: Solve path to renamed GameObjects

                    // string[] guids = AssetDatabase.FindAssets(GetObjectName(item.name));


                    // string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                    GameObject asset = (GameObject)PrefabUtility.InstantiatePrefab(pref);
                    Replace(item, asset, false);

                }
            }
        }

        if (GUILayout.Button("Replace Selected w/ Random Y rotation"))
        {
            if (UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage() != null)
            {
                EditorUtility.SetDirty(UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage().prefabContentsRoot);
            }
            GameObject[] selection = Selection.gameObjects;
            foreach (GameObject item in selection)
            {
                if (item.activeInHierarchy)
                {
                    // TODO: Refactor so we can avoid this nested chaos.
                    // TODO: Solve path to renamed GameObjects

                    // string[] guids = AssetDatabase.FindAssets(GetObjectName(item.name));


                    // string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                    GameObject asset = (GameObject)PrefabUtility.InstantiatePrefab(pref);
                    Replace(item, asset, true);

                }
            }
        }
    }

    /// <summary>
    /// Splits a string on spaces and return first string in resulting string array.
    /// </summary>
    /// <param name="NameInHierarchy"></param>
    /// <returns></returns>
    private string GetObjectName(string NameInHierarchy)
    {
        return NameInHierarchy.Split(' ')[0];
    }

    /// <summary>
    /// Replace oldGameObject with newGameObject, copying over transform information
    /// and name.
    /// </summary>
    /// <param name="oldGameObject"></param>
    /// <param name="newGameObject"></param>
    private void Replace(GameObject oldGameObject, GameObject newGameObject, bool randomRotation = false)
    {
        newGameObject.transform.parent = oldGameObject.transform.parent;

        // newGameObject.transform.SetPositionAndRotation(
        //     oldGameObject.transform.position,
        //     oldGameObject.transform.rotation
        // );

        newGameObject.transform.position = oldGameObject.transform.position;
        if (!ignoreScale)
        {
            newGameObject.transform.localScale = oldGameObject.transform.localScale;
        }
        if (randomRotation)
        {
            // Quaternion rRotation = Random.rotation;
            // rRotation.x = oldGameObject.transform.rotation.x;
            // rRotation.z = oldGameObject.transform.rotation.z;
            // newGameObject.transform.rotation = rRotation;

            Vector3 euler = oldGameObject.transform.eulerAngles;
            euler.y = Random.Range(0.0f, 360.0f);
            newGameObject.transform.eulerAngles = euler;

            Debug.Log("Replacing Done With Y = " + euler.y);
        }
        else
        {
            newGameObject.transform.rotation = oldGameObject.transform.rotation;
            Debug.Log("Replacing Done");
        }

        string name = oldGameObject.name;

        DestroyImmediate(oldGameObject);

        newGameObject.name = name;
    }
}
#endif