using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SandwichRequestDisplay : MonoBehaviour
{
    [SerializeField] private Sandwich currentSandwich;

    [SerializeField] private Sandwich[] sandwiches;

    public TextMeshProUGUI sandwichName;
    public List<GameObject> correctIngredients = new List<GameObject>();
    public Image sandwichIconDisplay;
    public Image sandwichRecipeDisplay;

    [SerializeField] private bool sandwichIsDone;

    // Start is called before the first frame update
    void Start()
    {
       

        currentSandwich = sandwiches[Random.Range(0, sandwiches.Length)];   

    }

    // Update is called once per frame
    void Update()
    {
        sandwichName.text = currentSandwich.sandwichName;

        correctIngredients = currentSandwich.ingredients;

        sandwichIconDisplay.sprite = currentSandwich.sandwichIcon;

        sandwichRecipeDisplay.sprite = currentSandwich.sandwichRecipe;

        if (sandwichIsDone == true)
        {
            currentSandwich = sandwiches[Random.Range(0, sandwiches.Length)];
            sandwichIsDone= false;
        }
    }
}
