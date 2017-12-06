using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {
    public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }

    [Range(1, 100)] public int frameRange = 60;

    private int[] fpsBuffer;
    private int fpsBufferIndex;

    void Awake() {
        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;

        // HighestFPS = 0;
        // LowestFPS = int.MaxValue;
    }

    // Update is called once per frame
    void Update () {
        UpdateBuffer();
        CalculateFPS();
	}

    private void UpdateBuffer() {
        fpsBuffer[fpsBufferIndex] = (int)(1f / Time.unscaledDeltaTime);
        fpsBufferIndex++;

        if (fpsBufferIndex == frameRange) {
            fpsBufferIndex = 0;
        }
    }

    private void CalculateFPS() {
        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;

        foreach (int num in fpsBuffer) {
            sum += num;

            if (num > highest) {
                highest = num;
            }

            if (num < lowest) {
                lowest = num;
            }
        }

        AverageFPS = sum / frameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }
}
