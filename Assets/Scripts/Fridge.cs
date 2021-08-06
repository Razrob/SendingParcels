using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Fridge : MonoBehaviour
{  
    [SerializeField] private ProductPosition[] productsPositions; 

    private static List<ProductData> requiredProducts = new List<ProductData>();
    private List<Product> instantiatedProducts = new List<Product>(); 

    public int remainingFridgeCapacity { get; private set; }

    void Start()
    {  
        remainingFridgeCapacity = productsPositions.Length - instantiatedProducts.Count; 
        Invoke(nameof(RefreshProducts), 0.2f);
    } 

    private void RefreshProducts()
    {
        for (int i = 0; i < requiredProducts.Count; i++)
        {
            Product product = Resources.Load<Product>($"ProductsPrefabs/{requiredProducts[i].productName}");

            int positionIndex = requiredProducts[i].positionIndex;
            instantiatedProducts.Add(Instantiate(product, productsPositions[positionIndex].productPosition, product.transform.rotation));
            instantiatedProducts[instantiatedProducts.Count - 1].SetParams(positionIndex, this);
        }

        remainingFridgeCapacity = productsPositions.Length - instantiatedProducts.Count;
    }

    private int GetFreePositionIndex()
    {
        for (int i = 0; i < productsPositions.Length; i++) 
        {
            if (!productsPositions[i].isBusy)
            {
                productsPositions[i].isBusy = true;
                return i;
            }
        }
        return -1;
    }
    public void AddProduct(Product product)
    {
        int positionIndex = GetFreePositionIndex();
        instantiatedProducts.Add(Instantiate(product, productsPositions[positionIndex].productPosition, product.transform.rotation));
        instantiatedProducts[instantiatedProducts.Count - 1].SetParams(positionIndex, this);

        requiredProducts.Add(new ProductData(product.ProductName, positionIndex));

        remainingFridgeCapacity = productsPositions.Length - instantiatedProducts.Count;
    }

    public void RemoveProduct(Product product)
    {
        productsPositions[product.indexInFridge].isBusy = false;

        requiredProducts.Remove(new ProductData(product.ProductName, product.indexInFridge));

        instantiatedProducts.Remove(product);
        Destroy(product.gameObject);
        remainingFridgeCapacity = productsPositions.Length - instantiatedProducts.Count;
    }

}
