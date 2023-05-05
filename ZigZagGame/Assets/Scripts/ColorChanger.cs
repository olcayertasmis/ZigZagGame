using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] colors;

    private Color _secondColor;

    private int _firstColorIndex, _secondColorIndex;
    
    [SerializeField] private Material _groundMaterial;

    private void Start()
    {
        _firstColorIndex = Random.Range(0, colors.Length);
        _secondColor = colors[ChangeSecondColor()];
        _groundMaterial.color = colors[_firstColorIndex];
    }

    private void Update()
    {
        Color fark = _groundMaterial.color - _secondColor;   
    }

    private int ChangeSecondColor()
    {
        _secondColorIndex = Random.Range(0, colors.Length);

        while (_secondColorIndex != _firstColorIndex)
        {
            _secondColorIndex = Random.Range(0, colors.Length);
        }

        return _secondColorIndex;
    }
}
