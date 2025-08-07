using UnityEngine;

public class BigBurgerJoint : BurgerGenerator
{
    protected override Burger MakeBurger(string type)
    {
        if (type.Equals("Cheese")) return new CheeseBurger();
        if (type.Equals("Chicken")) return new ChickenBurger();
        if (type.Equals("Fish")) return new FishBurger();

        return null;
    }
}
