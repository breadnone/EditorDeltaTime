using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorDelta
{
    public class EditorDelta
    {
        public static float deltaTime
        {
            get
            {
                return _deltaTime;
            }
        }
        public static long frameCount
        {
            get
            {
                return dummyFrame;
            }
        }

        public static void Start()
        {
            Stop();
            GetScreenRate();
            lastTime = 0;
            dummyFrame = 0;
            GetScreenRate();
            _deltaTime = 0;
            paused = false;

            EditorApplication.update += EditModeRunner;

        }
        public static void Stop()
        {
            EditorApplication.update -= EditModeRunner;
        }
        public static void Pause(bool state)
        {
            paused = state;
        }
        static long dummyFrame = 0;
        static float lastTime = 0;
        static float screenRate;
        static float _deltaTime;
        public static bool paused{get;private set;}
        static void GetScreenRate()
        {
            var refValue = Screen.currentResolution.refreshRateRatio.value;
            screenRate = (1f / (float)refValue);
        }

        public static void EditModeRunner()
        {
            if (paused || EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isCompiling || EditorApplication.isUpdating || EditorApplication.isPlaying)
            {
                return;
            }

            float time = (float)EditorApplication.timeSinceStartup;

            if (time < (lastTime + screenRate))
            {
                return;
            }

            var min = time - lastTime;
            
            _deltaTime = min;
            lastTime = time;
            dummyFrame++;

            if (dummyFrame == long.MaxValue - 1)
            {
                dummyFrame = 1;
            }
        }
    }
}