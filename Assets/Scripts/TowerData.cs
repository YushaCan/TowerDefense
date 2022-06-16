using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower" , menuName = "Tower")]
public class TowerData : ScriptableObject
{
    public string name;
    public int shootPower;
    public float range;
    public GameObject towerObject;
}
