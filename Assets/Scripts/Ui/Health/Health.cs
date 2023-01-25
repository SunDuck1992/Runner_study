using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class Health : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Image _image;

    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, _duration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _duration, Destroy));
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerping)
    {
        float elapsedTime = 0;
        float nextValue;

        while(elapsedTime < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _image.fillAmount = nextValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lerping?.Invoke(endValue);
    }
}
