using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public EnemyFSM enemy_fsm;

    public void PlayerHit()
    {
        enemy_fsm.AttackAction();
    }
}
