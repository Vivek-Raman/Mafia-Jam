using System;
using UnityEngine;

namespace Ingredients
{
[CreateAssetMenu]
public class Ingredient : ScriptableObject
{
    [Header("Ingredient Properties")]
    [SerializeField] protected string ingredientName = "Ingredient";
    [SerializeField] protected int minQuantity = 1;
    [SerializeField] protected int maxQuantity = 1;

    #region Properties

    public string IngredientName => ingredientName;
    public int MinQuantity => minQuantity;
    public int MaxQuantity => maxQuantity;

    #endregion
}
}