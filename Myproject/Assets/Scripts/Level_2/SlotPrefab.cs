using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSlot", menuName = "Slots")]

public class SlotPrefab : ScriptableObject
{
    public GameObject image;
    public List<Vector2> pos;
}
