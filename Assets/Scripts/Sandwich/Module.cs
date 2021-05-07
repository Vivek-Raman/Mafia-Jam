using Ingredients;
using UnityEngine;
using UnityEngine.Events;

namespace Sandwich
{
public class Module : MonoBehaviour
{
    public static UnityAction<Ingredient> playerInteractOnModuleAction;

    [Header("Common")]
    [SerializeField] protected LayerMask playerMask = 1 << 6;

    [Header("Module")]
    [SerializeField] private Ingredient ingredient = null;

    protected void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        // check if player is on tile
        if (!Physics2D.OverlapCircle(this.transform.position, .5f, playerMask)) return;


        Debug.Log($"module {ingredient.IngredientName} activated");

        playerInteractOnModuleAction?.Invoke(ingredient);
    }
}
}