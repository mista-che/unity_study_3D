using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Vector3 current_direction;
    public float movement_speed = 0.15f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        current_direction = new Vector3(h, v, 0);
    }

    private void FixedUpdate()
    {
        transform.position += current_direction * movement_speed;
    }
}
