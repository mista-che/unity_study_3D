using UnityEngine;

namespace Pattern.Factory
{
    public abstract class Mob : MonoBehaviour
    {
        public string Name { get; set; }
        public double HP { get; set; }
        public double AttackDamage { get; set; }

        protected virtual void Initialize(string name, double hp, double attackdamage)
        {
            Name = name;
            HP = hp;
            AttackDamage = attackdamage;
            Debug.Log($"{Name} initialized; HP: {HP} / Attack: {AttackDamage}.");
        }
    }

}
