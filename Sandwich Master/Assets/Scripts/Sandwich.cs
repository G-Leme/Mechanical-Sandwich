using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sandwich", menuName ="Sandwich")]
public class Sandwich : ScriptableObject
{
    public string sandwichName;
    public List<GameObject> ingredients = new List<GameObject>();

    public Sprite sandwichIcon;
    public Sprite sandwichRecipe;
}
