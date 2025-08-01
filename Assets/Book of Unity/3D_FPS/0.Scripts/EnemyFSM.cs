using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    // state
    public enum EnemyState { IDLE, MOVE, ATTACK, RETURN, DAMAGED, DIE }
    private EnemyState enemy_state;

    // component references
    private Transform player;
    private CharacterController character_controller;
    private Animator animator;

    // movement/pathfinding stats
    public float search_range = 8f;
    public float attack_range = 3f;
    public float movement_speed = 5f;
    private Vector3 origin_position;
    private Quaternion origin_rotation;
    public float tether_distance = 20f;

    // attack stats
    private float current_time = 0f;
    private float attack_delay = 2f;
    public int attack_power = 3;

    // durability stats
    public Slider hp_slider;
    public int hp = 15;
    private int max_hp = 15;

    private void Start()
    {
        enemy_state = EnemyState.IDLE;
        player = GameObject.Find("Player").transform;
        character_controller = GetComponent<CharacterController>();
        origin_position = transform.position;
        origin_rotation = transform.rotation;
        animator = GetComponentInChildren<Animator>();

        // gets rid of cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        switch (enemy_state)
        {
            case EnemyState.IDLE:
                Idle();
                break;
            case EnemyState.MOVE:
                Move();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
            case EnemyState.RETURN:
                Return();
                break;
            case EnemyState.DAMAGED:
                // Damaged();
                break;
            case EnemyState.DIE:
                // Die();
                break;
        }
    }

    private void Idle()
    {
        animator.SetTrigger("MoveToIdle");
    }

    private void Move()
    {
        animator.SetTrigger("IdleToMove");
    }

    private void Attack()
    {
        animator.SetTrigger("MoveToAttackDelay");
        animator.SetTrigger("StartAttack");
        animator.SetTrigger("AttackToMove");
    }

    private void Return()
    {

    }

    public void AttackAction()
    {

    }
}
