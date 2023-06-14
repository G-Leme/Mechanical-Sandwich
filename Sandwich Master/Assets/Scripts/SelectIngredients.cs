using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIngredients : MonoBehaviour
{

    [SerializeField] private GameObject ingredient;
    [SerializeField] private Transform ingredientPos;
    

    private Vector3 MouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        var ingredientInstance = GameObject.Instantiate(ingredient, ingredientPos.position, Quaternion.Euler(new Vector3(0,0, 49)));
    }
}
