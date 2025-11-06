using UnityEngine;
using UnityEditor;

public class RemoveMissingScripts : MonoBehaviour
{
    [MenuItem("Tools/Remove Missing Scripts in Scene")]
    public static void RemoveMissingScriptsFromScene()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject go in allObjects)
        {
            count += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
        }

        Debug.Log($"Removed {count} missing scripts from the current scene.");
    }

    [MenuItem("Tools/Remove Missing Scripts in Selected GameObject")]
    public static void RemoveMissingScriptsFromSelected()
    {
        if (Selection.gameObjects.Length == 0)
        {
            Debug.Log("No GameObjects selected!");
            return;
        }

        int count = 0;
        foreach (GameObject go in Selection.gameObjects)
        {
            count += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
        }

        Debug.Log($"Removed {count} missing scripts from selected GameObjects.");
    }
}