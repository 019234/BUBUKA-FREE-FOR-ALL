using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerRandom : MonoBehaviour
{
    public float _minIntensity = 1f;
    public float _maxIntensity = 5f;
    public float _flickerSpeed = 2f;

    private Light _flickeringLight;
    private float _originalIntensity;

    void Start()
    {
        _flickeringLight = GetComponent<Light>();

        if (_flickeringLight == null)
        {
            enabled = false;
            return;
        }

        _originalIntensity = _flickeringLight.intensity;
        StartCoroutine(Flicker());
    }

    System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            float _randomIntensity = Random.Range(_minIntensity, _maxIntensity);
            _flickeringLight.intensity = Mathf.Lerp(_flickeringLight.intensity, _randomIntensity, Time.deltaTime * _flickerSpeed);
            yield return null;
        }
    }
}