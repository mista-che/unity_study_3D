using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 facing_direction;
    public float movement_speed = 0.05f;

    private void Start()
    {
        int random_value = UnityEngine.Random.Range(0, 100);

        if (random_value < 30) // 30%
        {
            GameObject target = GameObject.Find("Player");
            facing_direction = target.transform.position - transform.position;
            // if subtraction order were reversed, it would get player->enemy instead
            facing_direction.Normalize();

        }
        else // 70%
        {
            facing_direction = Vector3.down;
        }
    }

    private void FixedUpdate()
    {
        transform.position += facing_direction * movement_speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject); // destroys bullet
        Destroy(gameObject); // destroys self
    }
}
