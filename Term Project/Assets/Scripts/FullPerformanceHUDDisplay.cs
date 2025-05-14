using UnityEngine;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FullPerformanceHUDDisplay : MonoBehaviour
{
    public TMP_Text fpsText;
    public TMP_Text frameTimeText;
    public TMP_Text drawCallText;
    public TMP_Text setPassText;
    public TMP_Text gcText;
    public TMP_Text memoryText;

    private int frameCount = 0;
    private float totalFrameTime = 0f;
    private float updateInterval = 1f;
    private float timer = 0f;

    void Update()
    {
        float deltaTime = Time.unscaledDeltaTime;
        frameCount++;
        totalFrameTime += deltaTime;
        timer += deltaTime;

        if (timer >= updateInterval)
        {
            float avgFPS = frameCount / timer;
            float avgFrameTime = (totalFrameTime / frameCount) * 1000f;

            fpsText.text = $"FPS: {avgFPS:F1}";

            if (avgFPS > 50f)
                fpsText.color = Color.green;
            else if (avgFPS > 30f)
                fpsText.color = new Color(1f, 0.75f, 0f); // orange-yellow
            else
                fpsText.color = Color.red;

            frameTimeText.text = $"Frame Time: {avgFrameTime:F1} ms";

            if (avgFrameTime < 16.7f)
                frameTimeText.color = Color.green;
            else if (avgFrameTime < 33f)
                frameTimeText.color = new Color(1f, 0.75f, 0f); // orange-yellow
            else
                frameTimeText.color = Color.red;

#if UNITY_EDITOR
            drawCallText.text = $"Draw Calls: {UnityStats.drawCalls}";
            setPassText.text = $"SetPass Calls: {UnityStats.setPassCalls}";
#else
            drawCallText.text = "Draw Calls: N/A";
            setPassText.text = "SetPass Calls: N/A";
#endif

            long gcAlloc = System.GC.GetTotalMemory(false) / 1024;
            gcText.text = $"GC Alloc: {gcAlloc} KB";

            long totalMemory = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() / 1024;
            memoryText.text = $"Used Memory: {totalMemory} KB";

            // Reset counters
            frameCount = 0;
            totalFrameTime = 0f;
            timer = 0f;
        }
    }
}
