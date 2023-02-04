using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlant", menuName = "Plants")]

public class PlantPrefab : ScriptableObject
{
    public List<GameObject> image;
    public List<Vector2> pos;
    public List<int> target;
}
