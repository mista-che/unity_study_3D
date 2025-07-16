using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_velocity = 0.35f;

    private void FixedUpdate()
    {
        transform.position += Vector3.up * bullet_velocity;
    }
}
