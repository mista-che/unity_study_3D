using System.Collections;
using UnityEngine;

public class BurgerController : MonoBehaviour
{
    IEnumerator Start()
    {
        BurgerGenerator burger_store = null;
        Burger burger = null;

        burger_store = new LocalBurgerJoint();

        burger = burger_store.OrderUp("Cheese");
        Debug.Log($"Your {burger} from {burger_store} is here!");
        yield return new WaitForSeconds(1f);
        burger = burger_store.OrderUp("Chicken");
        Debug.Log($"Your {burger} from {burger_store} is here!");
        yield return new WaitForSeconds(1f);

        burger_store = new BigBurgerJoint();

        burger = burger_store.OrderUp("Cheese");
        Debug.Log($"Your {burger} from {burger_store} is here!");
        yield return new WaitForSeconds(1f);
        burger = burger_store.OrderUp("Chicken");
        Debug.Log($"Your {burger} from {burger_store} is here!");
        yield return new WaitForSeconds(1f);
        burger = burger_store.OrderUp("Fish");
        Debug.Log($"Your {burger} from {burger_store} is here!");
    }
}
