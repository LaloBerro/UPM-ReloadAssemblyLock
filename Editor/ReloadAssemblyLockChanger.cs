using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

namespace DefaultNamespace
{
    [InitializeOnLoad]
    public static class ReloadAssemblyLockChanger
    {
        private static bool _isReloadAssemblyLocked;

        static ReloadAssemblyLockChanger()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            //GUILayout.FlexibleSpace();

            if (!_isReloadAssemblyLocked)
                Lock();
            else
                Unlock();
        }

        private static void Unlock()
        {
            if (GUILayout.Button(new GUIContent(EditorGUIUtility.IconContent("IN LockButton on act@2x").image, "Lock Reload Assembly"), EditorStyles.toolbarButton))
            {
                Debug.Log("Unlock Assemblies");

                EditorApplication.UnlockReloadAssemblies();
                AssetDatabase.Refresh();

                _isReloadAssemblyLocked = false;
            }
        }

        private static void Lock()
        {
            if (GUILayout.Button(new GUIContent(EditorGUIUtility.IconContent("IN LockButton act@2x").image, "Unlock Reload Assembly"), EditorStyles.toolbarButton))
            {
                Debug.Log("Lock Assemblies");

                EditorApplication.LockReloadAssemblies();

                _isReloadAssemblyLocked = true;
            }
        }
    }
}