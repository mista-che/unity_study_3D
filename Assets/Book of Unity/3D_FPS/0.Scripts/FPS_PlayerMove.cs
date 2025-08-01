using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPS_PlayerMove : MonoBehaviour
{
    // object references
    private CharacterController character_controller;
    private Animator animator;

    // movement/pathfinding stats
    public float movement_speed = 7f;
    public float jump_power = 10f;
    public bool is_jumping = false;

    private float gravity = -20f;
    private float y_velocity = 0f;

    // durability stats
    public Slider hp_slider;
    public int hp = 20;
    private int max_hp = 20;


    

    public GameObject hit_effect;

    private void Start()
    {
        character_controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // grabs input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // passes input to blend tree; normalizes input for direction. note: pass un-normalized input to blend tree.
        Vector3 direction = new Vector3(h, 0, v);
        animator.SetFloat("Momentum", direction.magnitude);
        direction = direction.normalized;

        // makes direction vector go towards camera
        direction = Camera.main.transform.TransformDirection(direction);
    }

    public void DamageAction(int damage)
    {
        hp -= damage;

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        // set hit effect to active, wait, then remove
        hit_effect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hit_effect.SetActive(false);
    }
}
