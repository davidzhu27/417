using UnityEngine;
using System.Collections;

public class DiscoLight : MonoBehaviour
{
    [Header("Disco Settings")]
    [SerializeField] private float colorChangeInterval = 1f;
    [SerializeField] private float intensity = 10f;

    private Light _light;
    private bool _isActive;
    private Coroutine _colorRoutine;

    // Neon disco colors (RGB 0-1)
    private static readonly Color[] NeonColors = new Color[]
    {
        new Color(1f, 0f, 1f),     // Magenta
        new Color(0f, 1f, 1f),     // Cyan
        new Color(1f, 0f, 0.5f),   // Hot pink
        new Color(0f, 1f, 0.5f),   // Neon green
        new Color(1f, 0.5f, 0f),   // Orange
        new Color(0.5f, 0f, 1f),   // Purple
        new Color(1f, 1f, 0f),     // Yellow
        new Color(0f, 0.5f, 1f),   // Blue
    };

    void Awake()
    {
        _light = GetComponent<Light>();
        if (_light == null)
            _light = gameObject.AddComponent<Light>();

        _light.enabled = false;
        _light.intensity = intensity;
        _light.type = LightType.Point;
        _isActive = false;
    }

    /// <summary>
    /// Call this from your key/socket logic when the player places the key in the socket (e.g. via UnityEvent or script reference).
    /// Starts the neon disco celebration.
    /// </summary>
    public void OnKeyPlacedInSocket()
    {
        if (_isActive) return;

        _isActive = true;
        _light.enabled = true;
        _light.intensity = intensity;

        if (_colorRoutine != null)
            StopCoroutine(_colorRoutine);

        _colorRoutine = StartCoroutine(CycleNeonColors());
    }

    private IEnumerator CycleNeonColors()
    {
        int index = 0;
        while (_isActive && _light != null)
        {
            _light.color = NeonColors[index];
            index = (index + 1) % NeonColors.Length;
            yield return new WaitForSeconds(colorChangeInterval);
        }
    }

    void OnDisable()
    {
        _isActive = false;
        if (_colorRoutine != null)
        {
            StopCoroutine(_colorRoutine);
            _colorRoutine = null;
        }
    }
}
