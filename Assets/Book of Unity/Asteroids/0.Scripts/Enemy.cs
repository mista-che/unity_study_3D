using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 facing_direction;
    public float movement_speed = 0.05f;

    public GameObject explosion_prefab;

    private int score_value = 1;

    private enum CollisionLayer { DEADZONE = 6, PLAYER = 7, BULLET = 8}

    private void OnEnable()
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
        switch ((int)collision.gameObject.layer)
        {
            case (int)CollisionLayer.DEADZONE:
                break;

            case (int)CollisionLayer.PLAYER:
                Debug.Log($"You were hit by {gameObject.name}!");
                Destroy(gameObject);
                break;

            case (int)CollisionLayer.BULLET:
                // current score plus enemy point value
                ScoreManager score_manager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
                score_manager.SetScore(score_manager.GetScore() + score_value);

                // create explosion
                Instantiate(explosion_prefab, transform.position, Quaternion.identity);

                // destroys bullet and self
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
        }

       
    }
}
