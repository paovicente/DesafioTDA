using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    [SerializeField] Transform playerHand;
    [SerializeField] List<GameObject> foodList;
    public List<GameObject> FoodList { get => foodList; set => foodList = value; }

    private float delay = 1f;

    private float repeatTime = 10f;

    private void Start(){

        foodList = new List<GameObject>();
        InvokeRepeating("MakeFood", delay, repeatTime); //después de 10 segundos vuelven a aparecer las comidas
    }

    private void MakeFood(){

        foreach (GameObject food in foodList)
            food.SetActive(true);
   
    }

    public void KillFood(){
        foreach (GameObject food in foodList)
            food.SetActive(false);
    }

    public void EatsFood(GameObject food){
        
        DetachFoods();
        food.SetActive(true);
        food.transform.parent = playerHand;
        food.transform.localPosition = Vector3.zero;
    }

    private void DetachFoods(){

        GameObject foods  = GameObject.Find("---FOODS---");
        
        foreach (Transform child in playerHand){
            child.parent = foods.transform;
            child.transform.position = new Vector3(Random.Range(0f,5f), 0f,Random.Range(0f,5f));
            child.gameObject.SetActive(true); 
        }
    }
}
