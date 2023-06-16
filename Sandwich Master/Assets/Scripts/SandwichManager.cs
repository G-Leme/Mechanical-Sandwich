using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Playables;

public class SandwichManager : MonoBehaviour
{
    [SerializeField] private Sandwich currentSandwich;
    [SerializeField] private Sandwich[] sandwiches;

    public List<GameObject> selectedIngredients = new List<GameObject>();
    public List<GameObject> correctIngredients = new List<GameObject>();

    public int score;
    public TextMeshProUGUI scoreboard;

    public TextMeshProUGUI sandwichName;
    public Image sandwichIconDisplay;
    public Image sandwichRecipeDisplay;

    public bool sandwichIsDone;

    [SerializeField] private PlayableDirector breadAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentSandwich = sandwiches[Random.Range(0, sandwiches.Length)];   
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = ("Score: " + score.ToString()); 

        sandwichName.text = currentSandwich.sandwichName;

        correctIngredients = currentSandwich.ingredients;

        sandwichIconDisplay.sprite = currentSandwich.sandwichIcon;

        sandwichRecipeDisplay.sprite = currentSandwich.sandwichRecipe;

        if (sandwichIsDone == true)
        {
            breadAnimation.Play();
            currentSandwich = sandwiches[Random.Range(0, sandwiches.Length)];
            sandwichIsDone = false;
        }

      CompareLists();
      
    }

    private void CompareLists()
    {
        if (selectedIngredients.Count != correctIngredients.Count)
        {
            return;
        }
        else
        {
                if (correctIngredients[0] == selectedIngredients[0] && correctIngredients[1] == selectedIngredients[1]
                   && correctIngredients[2] == selectedIngredients[2])
                {
                    sandwichIsDone = true;
                    selectedIngredients.Clear();
                    score += 50;
                }
                else
                {
                    sandwichIsDone = true;
                    selectedIngredients.Clear();
                if(score > 0)
                    score -= 50;
                }
            

        }
    }


}
