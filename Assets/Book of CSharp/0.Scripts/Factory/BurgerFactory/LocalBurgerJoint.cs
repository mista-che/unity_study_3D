using UnityEngine;

public class LocalBurgerJoint : BurgerGenerator
{
    protected override Burger MakeBurger(string type)
    {
        if (type.Equals("Cheese")) return new CheeseBurger();
        if (type.Equals("Chicken")) return new ChickenBurger();

        return null;
    }
}
