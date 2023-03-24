using UnityEngine;
//Abstract class for the objects bot/item.Used abstract class because these objects have some common properties(distance) as well as individual properties(Color)
public abstract class ObjectClass : MonoBehaviour
{
    public float DistanceToPlayer;
    public abstract void ApplyHiglightColor(bool Val);
    //this will calculate the distance to Player 
    public void CalculateDistance()
    {
        DistanceToPlayer = (Controller.instance.PlayerTransform.position - transform.position).magnitude;
    }
}

