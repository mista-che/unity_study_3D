using UnityEngine;

public abstract class BurgerGenerator : MonoBehaviour 
{
    public Burger OrderUp(string type)
    {
        Burger burger = MakeBurger(type);

        return burger;
    }

    protected abstract Burger MakeBurger(string type);
}
