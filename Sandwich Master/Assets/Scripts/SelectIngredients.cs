using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIngredients : MonoBehaviour
{

    [SerializeField] private GameObject ingredient;
    [SerializeField] private Transform ingredientPos;

    [SerializeField] private SandwichManager sandwichManagerScript;
    [SerializeField] private GameObject sandwichManager;

    [SerializeField] private Vector3 scale;
    [SerializeField] private Timer timerScript;

    private float delay;


    private bool canClick;

    private void Start()
    {
        timerScript = GameObject.FindObjectOfType<Timer>();
       
        delay = 3;
        canClick = true;
        sandwichManagerScript = sandwichManager.GetComponent<SandwichManager>();
    }

    private void Update()
    {
        transform.localScale = scale;
        

        if (sandwichManagerScript.sandwichIsDone == true)
        {
            DestroyInstances();
            canClick = true;
        }

        if (delay >= 0)
        {
            delay = delay -= Time.deltaTime;
        }



    }
    private Vector3 MouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (canClick == true && delay <= 0 && timerScript.timer >=0)
        {
           
            var ingredientInstance = GameObject.Instantiate(ingredient, ingredientPos.position, Quaternion.Euler(new Vector3(0, 0, 49)));
            sandwichManagerScript.selectedIngredients.Add(ingredient);
            canClick = false;
           
        }
    }

    private void OnMouseEnter()
    {

        scale.x += 0.035f;
        scale.y += 0.035f;
        scale.z += 0.035f;

    }

    private void OnMouseExit()
    {
        scale.x -= 0.035f;
        scale.y -= 0.035f;
        scale.z -= 0.035f;
    }

    private void DestroyInstances()
    {
        GameObject[] ingredientInstances = GameObject.FindGameObjectsWithTag("Ingredients");
        foreach(GameObject instance in ingredientInstances)
        {
            GameObject.Destroy(instance, 1.43f);
        }
    }
}
