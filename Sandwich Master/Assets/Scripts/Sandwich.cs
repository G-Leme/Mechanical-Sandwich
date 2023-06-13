using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sandwich", menuName ="Sandwich")]
public class Sandwich : ScriptableObject
{
    [SerializeField] private string sandwichName;
    [SerializeField] private List<GameObject> ingredients;

    [SerializeField] private Sprite sandwichIcon;
}
