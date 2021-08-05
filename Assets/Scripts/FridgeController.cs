using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class FridgeController : MonoBehaviour
{  
    [SerializeField] private ProductPosition[] productsPositions; 

    public static List<string> productsInFridge = new List<string>();
    private static int fridgeCapacity { get; set; }

    public static int remainingFridgeCapacity { get; private set; }

    void Start()
    { 

        fridgeCapacity = productsPositions.Length;
        remainingFridgeCapacity = fridgeCapacity - productsInFridge.Count; 
        Invoke(nameof(RefreshProducts), 0.2f); 


    } 

    public void RefreshProducts()
    { 
        for (int i = 0; i < productsInFridge.Count; i++)
        {
            GameObject product = Resources.Load<GameObject>($"ProductsPrefabs/{productsInFridge[i]}"); 
            if (product.GetComponent<Product>().indexInFridge == -1)
            {
                int posIndex = GetFreePositionIndex();
                if (posIndex == -1) break;
                GameObject tempObj = Instantiate(product, productsPositions[posIndex].productPosition, product.transform.rotation); 
                tempObj.GetComponent<Product>().SetParams(posIndex, this); 
            }

        }

        remainingFridgeCapacity = fridgeCapacity - productsInFridge.Count;

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

    public void RemoveProduct(int indexInPositions, GameObject product)
    {
        productsPositions[indexInPositions].isBusy = false;
        productsInFridge.Remove(product.name.Replace("(Clone)", ""));
        Destroy(product);
        remainingFridgeCapacity = fridgeCapacity - productsInFridge.Count;
    }

    [System.Serializable]
    private class ProductPosition
    {
        public Vector3 productPosition;
        [HideInInspector] public bool isBusy;
    }

}
