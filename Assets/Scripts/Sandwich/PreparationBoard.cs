using System.Collections.Generic;
using UnityEngine;

namespace Sandwich
{
public class PreparationBoard : MonoBehaviour
{
    // TODO: serialization not required
    [SerializeField] private List<Ingredient> currentSandwich = new List<Ingredient>();

    public void AddIngredient(Ingredient toAdd)
    {
        // TODO: show ingredients on board
        currentSandwich.Add(toAdd);
    }
}
}