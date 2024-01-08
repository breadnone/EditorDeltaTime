using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorDelta
{
    [InitializeOnLoad]
    public static class EditorDeltaInit
    {
        static EditorDeltaInit()
        {
            EditorApplication.playModeStateChanged += PlayModeState;
            EditorDelta.Start();
        }

        static void PlayModeState(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
            {
                EditorDelta.Stop();
            }
            else if (state == PlayModeStateChange.ExitingPlayMode)
            {
                EditorDelta.Start();
            }
        }
    }
}