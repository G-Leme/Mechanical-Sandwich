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
    [SerializeField] private PlayableDirector breadAnimation;

    public List<GameObject> selectedIngredients = new List<GameObject>();
    public List<GameObject> correctIngredients = new List<GameObject>();

    
    public TextMeshProUGUI scoreboard;

    public TextMeshProUGUI sandwichName;
    public Image sandwichIconDisplay;
    public Image sandwichRecipeDisplay;

    public bool sandwichIsDone;


    // Start is called before the first frame update
    void Start()
    {
        currentSandwich = sandwiches[Random.Range(0, sandwiches.Length)];   
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = ("Score: " + Score.Instance.score.ToString()); 

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


            var hasWrongIngredient = false;
            for (int i = 0; i < selectedIngredients.Count; i++)
            {
                if (correctIngredients[i] != selectedIngredients[i])
                    hasWrongIngredient = true;
            }

            if (hasWrongIngredient)
            {
                minus50.SetActive(true);
                wrongRecipy.SetActive(true);

                animator.SetBool("WrongOrder", true);
                sandwichIsDone = true;

                selectedIngredients.Clear();

                if (Score.Instance.score > 0)
                    Score.Instance.score -= 50;
            }
            else
            {
                plus50.SetActive(true);
                rightRecipy.SetActive(true);

                sandwichIsDone = true;
                selectedIngredients.Clear();

                Score.Instance.score += 50;

            }

        }
    }


}
