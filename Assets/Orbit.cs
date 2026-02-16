using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 67f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
