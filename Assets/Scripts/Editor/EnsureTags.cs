#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

// Registers the "Enemy" and "Powerup" tags the first time the package is imported.
[InitializeOnLoad]
public static class EnsureTags
{
    static EnsureTags()
    {
        AddTag("Enemy");
        AddTag("Powerup");
    }

    static void AddTag(string tag)
    {
        var tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tags = tagManager.FindProperty("tags");
        for (int i = 0; i < tags.arraySize; i++)
            if (tags.GetArrayElementAtIndex(i).stringValue == tag) return;
        tags.InsertArrayElementAtIndex(tags.arraySize);
        tags.GetArrayElementAtIndex(tags.arraySize - 1).stringValue = tag;
        tagManager.ApplyModifiedProperties();
    }
}
#endif
