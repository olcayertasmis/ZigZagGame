using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] colors;

    private Color _secondColor;

    private int _firstColorIndex, _secondColorIndex;

    [SerializeField] private Material groundMaterial;

    private Color diff;

    private void Start()
    {
        _firstColorIndex = Random.Range(0, colors.Length);
        _secondColorIndex = ChangeSecondColor();
        _secondColor = colors[_secondColorIndex];
        groundMaterial.color = colors[_firstColorIndex];
    }

    private void Update()
    {
        diff = groundMaterial.color - _secondColor;

        if (Math.Abs(diff.r) + Math.Abs(diff.g) + Math.Abs(diff.b) < 0.1f)
        {
            _secondColor = colors[ChangeSecondColor()];
        }

        groundMaterial.color = Color.Lerp(groundMaterial.color, _secondColor, 0.003f);
    }

    private int ChangeSecondColor()
    {
        _secondColorIndex = Random.Range(0, colors.Length);

        while (_secondColorIndex == _firstColorIndex)
        {
            _secondColorIndex = Random.Range(0, colors.Length);
        }

        return _secondColorIndex;
    }
}