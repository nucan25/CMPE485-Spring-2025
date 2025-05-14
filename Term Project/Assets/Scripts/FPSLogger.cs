using UnityEngine;

public class FPSLogger : MonoBehaviour
{
    public float testDuration = 5f;
    private float totalTime = 0f;
    private int frameCount = 0;
    private bool isTesting = false;

    void Update()
    {
        // Press SPACE to start the test
        if (Input.GetKeyDown(KeyCode.Space) && !isTesting)
        {
            Debug.Log("🎯 FPS test started...");
            StartTest();
        }

        if (!isTesting) return;

        totalTime += Time.unscaledDeltaTime;
        frameCount++;

        if (totalTime >= testDuration)
        {
            float averageFPS = frameCount / totalTime;
            Debug.Log("💡 Average FPS: " + averageFPS.ToString("F2"));
            isTesting = false;
        }
    }

    void StartTest()
    {
        totalTime = 0f;
        frameCount = 0;
        isTesting = true;
    }
}
