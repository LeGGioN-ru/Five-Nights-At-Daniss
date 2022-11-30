using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private float _pollingTime = 1f;
    private float _time;
    private float _frameCount;

    private void Update()
    {
        _time += Time.deltaTime;

        _frameCount++;

        if (_time >= _pollingTime)
        {
            int frameRate = Mathf.RoundToInt(_frameCount / _time);
            Debug.Log(frameRate);
            _time -= _pollingTime;
            _frameCount = 0;
        }
    }
}
