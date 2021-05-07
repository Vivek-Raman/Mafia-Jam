using System;
using System.Collections;
using System.Collections.Generic;
using Ingredients;
using Sandwich;
using UnityEngine;

public class SandwichBuilder : MonoBehaviour
{
    [SerializeField] private List<Ingredient> currentSandwich = new List<Ingredient>();

    private void OnEnable()
    {
        Module.playerInteractOnModuleAction += OnInteractionWithModule;
    }

    private void OnDisable()
    {
        Module.playerInteractOnModuleAction += OnInteractionWithModule;
    }

    private void OnInteractionWithModule(Ingredient ingredient)
    {
        // TODO: check if interaction was sufficiently on beat

        // TODO: check if interaction is valid

        currentSandwich.Add(ingredient);
    }
}
