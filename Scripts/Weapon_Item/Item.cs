using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type { Heart , Weapon, Grenade};
    public Type type;
    public int value;
}
