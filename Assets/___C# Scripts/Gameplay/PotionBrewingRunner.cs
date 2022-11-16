using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-7.0

public struct Ingredient
{
    public InventoryItemData Data;
    public int Amount;

    public Ingredient(InventoryItemData data, int amount)
    {
        Amount = amount;
        Data = data;
    }
}

public class PotionBrewingRunner : MonoBehaviour
{
    public StaticInventoryDisplay inventoryDisplay;
    public AudioSource brewingAudioSource;
    public TMP_Text ingredientText;

    public InventoryItemData fairyPowderData;
    public InventoryItemData cloverData;

    private List<Ingredient> _recipe;
    private bool currBrewing = false;

    private void CreateDemoRecipe()
    {
        _recipe = new List<Ingredient>();
        _recipe.Add(new Ingredient(fairyPowderData, 2));
        _recipe.Add(new Ingredient(cloverData, 3));
    }

    private void Start()
    {
        //inventoryDisplay.ItemUsed -= ConsumeItem; // initially disable
    }

    void OnEnable()
    {
        inventoryDisplay.ItemUsed += ConsumeItem;
        CreateDemoRecipe();
        UpdateRecipeText();
        currBrewing = true;
    }
    
    void OnDisable()
    {
        inventoryDisplay.ItemUsed -= ConsumeItem;
        currBrewing = false;
    }

    void ConsumeItem(InventoryItemData consumedItem)
    {
        if (this.isActiveAndEnabled)
        {
            Debug.Log("Put " + consumedItem.DisplayName + " into the Cauldron");
            RemoveIngredientFromRecipe(consumedItem);
        }
    }

    void SetRecipeText(string recipeText)
    {
        ingredientText.text = recipeText;
    }

    string GetRecipeAsString()
    {
        string recipeString = "";
        foreach (Ingredient ingredient in _recipe)
        {
            recipeString += "- ";
            recipeString += ingredient.Data.DisplayName;
            recipeString += " x";
            recipeString += ingredient.Amount;
            recipeString += "\n";
        }
        if (_recipe.Count < 1)
        {
            recipeString = "None";
        }
        return recipeString;
    }

    void UpdateRecipeText()
    {
        SetRecipeText(GetRecipeAsString());
    }

    void RemoveIngredientFromRecipe(InventoryItemData consumedItem)
    {
        for (int i = 0; i < _recipe.Count; ++i)
        {
            Ingredient ingredient = _recipe[i];
            if (ingredient.Data.DisplayName.Equals(consumedItem.DisplayName))
            {
                if (ingredient.Amount > 1)
                {
                    --ingredient.Amount;
                    _recipe[i] = ingredient;
                }
                else if (ingredient.Amount == 1)
                {
                    _recipe.RemoveAt(i); // remove ingredient from list
                }
                else // wrong ingredient
                {
                    // TODO - Do something here !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                }
                break;
            }
        }
        UpdateRecipeText();
        if ((_recipe.Count < 1) && currBrewing) // no more ingredients and we are brewing
        {
            // brewing complete
            // TODO - Do something here !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}
