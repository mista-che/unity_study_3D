using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bomb_rigidbody;

    public LayerMask layer_mask;

    private float fuse_timer = 4f;
    private float explosion_radius = 10f;


    private void Awake()
    {
        bomb_rigidbody = GetComponent<Rigidbody>();
    }

    // we need a bomb that blow up on the correct timer
    IEnumerator Start()
    {
        yield return new WaitForSeconds(fuse_timer);

        BombApplyForce();
    }

    void BombApplyForce()
    {
        // gets all colliders within a sphere of radius explosion_radius, but only colliders in layer_mask
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosion_radius, layer_mask);

        foreach (var collider in colliders)
        {
            // grabs each collider's rigidbody
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            // sends capsules flying
            rb.AddExplosionForce(500f, transform.position, explosion_radius, 1f);
        }

        // destroys the bomb
        Destroy(gameObject);
    }
}
