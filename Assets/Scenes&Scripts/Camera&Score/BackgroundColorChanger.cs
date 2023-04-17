using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [System.Serializable]
    public struct GradientColor
    {
        public Color color;
        public float yPos;
    }

    public GameObject character;
    public List<GradientColor> gradientColors;

    private Camera _camera;
    private int _currentColorIndex;

    void Start()
    {
        _camera = Camera.main;
        _currentColorIndex = 0;
    }

    void Update()
    {
        ChangeBackgroundColor();
    }

    void ChangeBackgroundColor()
    {
        float characterY = character.transform.position.y;
        if (characterY >= gradientColors[_currentColorIndex + 1].yPos)
        {
            _currentColorIndex++;
        }
        else if (characterY < gradientColors[_currentColorIndex].yPos && _currentColorIndex > 0)
        {
            _currentColorIndex--;
        }

        float t = (characterY - gradientColors[_currentColorIndex].yPos) / (gradientColors[_currentColorIndex + 1].yPos - gradientColors[_currentColorIndex].yPos);
        Color interpolatedColor = Color.Lerp(gradientColors[_currentColorIndex].color, gradientColors[_currentColorIndex + 1].color, t);
        _camera.backgroundColor = interpolatedColor;
    }
}
