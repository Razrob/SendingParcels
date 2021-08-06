using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalSumToBuy;

    [SerializeField] private ProductUI[] productsUIs;
    [SerializeField] private Product[] products;

    [SerializeField] private Fridge fridge;
    [SerializeField] private ComputerWindowDisplay computerController;

    private List<Product> tempProducts = new List<Product>();
    private int tempSum;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        //FridgeController.productsInFridge.Add(products[0].name);
       //FindObjectOfType<FridgeController>().RefreshProducts();
    } 

    public void BuyAllChoicedProducts()
    {
        if (!BusinessData.MakePurchase(tempSum)) return;

        foreach (Product product in tempProducts) fridge.AddProduct(product);
        tempProducts.Clear();

        tempSum = 0;
        finalSumToBuy.text = tempSum.ToString() + "ð.";

        foreach (ProductUI product in productsUIs)
        {
            product.productsInBasketNumber = 0;
            product.productsNumber.text = 0.ToString();
        } 

        computerController.UpdateMoneyDisplay();

    }

    public void AddProduct(string code) 
    { 
        int index = System.Convert.ToInt32(code.Substring(0, 2));
        if (code[2] == '+')
        {
            if (tempProducts.Count >= fridge.remainingFridgeCapacity) return;

            productsUIs[index].productsInBasketNumber++;
            tempProducts.Add(products[index]); 
            ChangeFinalSumAndProductNumber(productsUIs[index].price, index);
        }
        else if (productsUIs[index].productsInBasketNumber > 0)
        {
            productsUIs[index].productsInBasketNumber--;
            tempProducts.Remove(products[index]);
            ChangeFinalSumAndProductNumber(-productsUIs[index].price, index);
        }

    }

    private void ChangeFinalSumAndProductNumber(int sum, int productIndex)
    {
        tempSum += sum;
        finalSumToBuy.text = tempSum.ToString() + "ð.";
        productsUIs[productIndex].productsNumber.text = productsUIs[productIndex].productsInBasketNumber.ToString();
    }
}
