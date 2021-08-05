using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductsShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalSumToBuy;

    [SerializeField] private ProductsUI[] productsUIs;
    [SerializeField] private GameObject[] products;


    [SerializeField] private ComputerController computerController;

    private List<GameObject> tempProducts = new List<GameObject>();
    private int tempSum;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        //FridgeController.productsInFridge.Add(products[0].name);
       //FindObjectOfType<FridgeController>().RefreshProducts();
    } 

    public void BuyAllChoicedProducts()
    {
        if (!BusinessData.MakePurchase(tempSum)) return;

        foreach(GameObject product in tempProducts) FridgeController.productsInFridge.Add(product.name);
        tempProducts.Clear();

        tempSum = 0;
        finalSumToBuy.text = tempSum.ToString() + "ð.";

        foreach (ProductsUI product in productsUIs)
        {
            product.productsInBasketNumber = 0;
            product.productsNumber.text = 0.ToString();
        }


        FindObjectOfType<FridgeController>().RefreshProducts();

        computerController.UpdateMoneyDisplay();

    }

    public void AddProduct(string code) 
    {
        /* code - xxy
         * xx = index in array products ( 04, 34 )
         * y = + or -
         */
        int index = System.Convert.ToInt32(code.Substring(0, 2));
        if (code[2] == '+')
        {
            if (tempProducts.Count >= FridgeController.remainingFridgeCapacity) return;

            productsUIs[index].productsInBasketNumber++;
            tempProducts.Add(products[index]);
            //Debug.Log(productsUIs[index].productsInBasketNumber);
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

    [System.Serializable]
    private class ProductsUI
    {
        public TextMeshProUGUI priceWithName;
        public TextMeshProUGUI productsNumber;
        [HideInInspector] public int productsInBasketNumber;

        public int price 
        { 
            get
            { 
                string price = priceWithName.text; 
                price = price.Substring(price.IndexOf("(") + 1, price.IndexOf("ð.)") - price.IndexOf("(") - 1);
                return System.Convert.ToInt32(price);
            } 
        }


    }
}
