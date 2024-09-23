using UnityEngine;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
#if UNITY_5
using UnityEngine.Profiling;
#endif
using UnityEngine.UI;
//-----------------------------------------------------------------------------------------------------
public class StatsMan : MonoBehaviour
{

    public Color tx_Color = Color.white;
    StringBuilder tx;
    public Text gui;

    float updateInterval = 1.0f;
    float lastInterval; // Last interval end time
    float frames = 0; // Frames over current interval

    float framesavtick = 0;
    float framesav = 0.0f;

    public Font epicfont;

    // Use this for initialization
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        framesav = 0;
        tx = new StringBuilder();
        tx.Capacity = 200;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void OnDisable()
    {
        if (gui)
            DestroyImmediate(gui.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ++frames;

        var timeNow = Time.realtimeSinceStartup;

        if (timeNow > lastInterval + updateInterval)
        {
            if (!gui)
            {
                GameObject go = new GameObject("FPS Display", typeof(Text));
                go.hideFlags = HideFlags.HideAndDontSave;
                go.transform.position = new Vector3(0, 0, 0);
                gui = go.GetComponent<Text>();
                gui.color = tx_Color;
                gui.font = epicfont;
            }

            float fps = frames / (timeNow - lastInterval);
            float ms = 1000.0f / Mathf.Max(fps, 0.00001f);

            ++framesavtick;
            framesav += fps;
            float fpsav = framesav / framesavtick;

            tx.Length = 0;

            tx.AppendFormat("Time : {0} ms     Current FPS: {1}     AvgFPS: {2}\nGPU memory : {3}    Sys Memory : {4}\n", ms, fps, fpsav, SystemInfo.graphicsMemorySize, SystemInfo.systemMemorySize)

            .AppendFormat("TotalAllocatedMemory : {0}mb\nTotalReservedMemory : {1}mb\nTotalUnusedReservedMemory : {2}mb",
            Profiler.GetTotalAllocatedMemory() / 1048576,
            Profiler.GetTotalReservedMemory() / 1048576,
            Profiler.GetTotalUnusedReservedMemory() / 1048576
            );

#if UNITY_EDITOR
            tx.AppendFormat("\nDrawCalls : {0}\nUsed Texture Memory : {1}\nrenderedTextureCount : {2}", UnityStats.drawCalls, UnityStats.usedTextureMemorySize / 1048576, UnityStats.usedTextureCount);
#endif

            gui.text = tx.ToString();
            frames = 0;
            lastInterval = timeNow;
        }

    }
}