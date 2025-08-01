using UnityEngine;

public class Movement : MonoBehaviour
{
    private float movement_speed = 0.5f;
    private Vector3 dir;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = new Vector3(h, 0, v);
    }

    private void FixedUpdate()
    {
        transform.position += dir * movement_speed;
    }
}
