using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIngredients : MonoBehaviour
{

    [SerializeField] private GameObject ingredient;
    [SerializeField] private Transform ingredientPos;
    [SerializeField] private SandwichManager sandwichManagerScript;
    [SerializeField] private GameObject sandwichManager;
  


    private bool canClick;

    private void Start()
    {
        canClick = true;
        sandwichManagerScript = sandwichManager.GetComponent<SandwichManager>();
    }

    private void Update()
    {
        if (sandwichManagerScript.sandwichIsDone == true)
        {
            DestroyInstances();
            canClick = true;
        }

      
        

    }
    private Vector3 MouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (canClick == true)
        {
           
            var ingredientInstance = GameObject.Instantiate(ingredient, ingredientPos.position, Quaternion.Euler(new Vector3(0, 0, 49)));
            sandwichManagerScript.selectedIngredients.Add(ingredient);
            canClick = false;
           
        }
    }

    private void DestroyInstances()
    {
        GameObject[] ingredientInstances = GameObject.FindGameObjectsWithTag("Ingredients");
        foreach(GameObject instance in ingredientInstances)
        {
            GameObject.Destroy(instance, 1f);
        }
    }
}
