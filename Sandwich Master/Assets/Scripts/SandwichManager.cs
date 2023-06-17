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
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject rightRecipy;
    [SerializeField] private GameObject wrongRecipy;
    [SerializeField] private GameObject plus50;
    [SerializeField] private GameObject minus50;

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
           
            animator.SetBool("WrongOrder", false);
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
           plus50.SetActive(false);
           minus50.SetActive(false);
           rightRecipy.SetActive(false);
           wrongRecipy.SetActive(false);

            if (correctIngredients[0] == selectedIngredients[0] && correctIngredients[1] == selectedIngredients[1]
                   && correctIngredients[2] == selectedIngredients[2])
              {
                plus50.SetActive(true);
                rightRecipy.SetActive(true);

                sandwichIsDone = true;
                selectedIngredients.Clear();

                score += 50;
              }
            else
              {
                minus50.SetActive(true);
                wrongRecipy.SetActive(true);

                animator.SetBool("WrongOrder", true);
                sandwichIsDone = true;

                selectedIngredients.Clear();

                if(score > 0)
                    score -= 50;
                }
            

        }
    }


}
