using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    public Vector3 openLocalOffset = new Vector3(0, 0, 3);
    public float speed = 2f;

    private Vector3 closedLocalPosition;
    private Vector3 openLocalPosition;
    private bool opening = false;

    void Start()
    {
        closedLocalPosition = transform.localPosition;
        openLocalPosition = closedLocalPosition + openLocalOffset;
    }

    void Update()
    {
        if (opening)
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition,
                openLocalPosition,
                speed * Time.deltaTime
            );
        }
    }

    public void OpenDoor()
    {
        Debug.Log("Door opening!");
        opening = true;
    }
}