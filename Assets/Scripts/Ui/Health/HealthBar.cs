using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _heartTemplate;

    private List<Health> _hearts = new List<Health>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int heartCount = value - _hearts.Count;

            for (int i = 0; i < heartCount; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            int deleteHeart = _hearts.Count - value;

            for (int i = 0; i < deleteHeart; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Health health)
    {
        _hearts.Remove(health);
        health.ToEmpty();
    }

    private void CreateHeart()
    {
        Health newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Health>());
        newHeart.ToFill();
    }
}
