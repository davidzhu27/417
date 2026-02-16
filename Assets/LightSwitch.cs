using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Light light;
    public InputActionReference action;

    void Start()
    {
        light = GetComponent<Light>();
        action.action.Enable();
    }

    void Update()
    {
        if (action.action.triggered)
        {
            light.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
