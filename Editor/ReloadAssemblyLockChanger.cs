using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

namespace ReloadAssemblyLock.Core
{
    [InitializeOnLoad]
    public static class ReloadAssemblyLockChanger
    {
        private static bool _isReloadAssemblyLocked;

        static ReloadAssemblyLockChanger()
        {
            ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
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