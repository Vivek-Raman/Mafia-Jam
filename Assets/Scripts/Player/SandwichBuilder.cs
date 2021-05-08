using Sandwich;
using UnityEngine;

namespace Player
{
public class SandwichBuilder : MonoBehaviour
{
    [SerializeField] private PreparationBoard prepBoard = null;

    private void OnEnable()
    {
        Module.playerInteractOnModuleAction += OnInteractionWithModule;
    }

    private void OnDisable()
    {
        Module.playerInteractOnModuleAction -= OnInteractionWithModule;
    }

    private void OnInteractionWithModule(Ingredient ingredient)
    {
        // TODO: check if interaction was sufficiently on beat

        // TODO: check if interaction is valid

        prepBoard.AddIngredient(ingredient);
    }
}
}