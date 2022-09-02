using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    [SerializeField] Transform playerHand;
    [SerializeField] List<GameObject> foodList;
    public List<GameObject> FoodListList { get => foodList; set => foodList = value; }

    [SerializeField] GameObject[] foods;

    private void Start(){

        foodList = new List<GameObject>();
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.E)) EatsFood();
        if (Input.GetKeyDown(KeyCode.M)) MakeFood();
        
    }
    
    private void EatsFood(){

        for (int i = 0 ; i < foods.Length ; i++)
            foods[i].SetActive(false);
        
    }

    private void MakeFood(){

        foreach (GameObject food in foods)
            food.SetActive(true);      
    }

    private void GrabFood(GameObject food){

        DetachFoods();
        food.SetActive(true);
        food.transform.parent = playerHand;
        food.transform.localPosition = Vector3.zero;
    }

    private void DetachFoods(){

        foreach (Transform child in playerHand){
            child.parent = null;
            child.transform.position = new Vector3(Random.Range(0f,3f), 1f,Random.Range(0f,3f));
            child.gameObject.SetActive(true);
        }
    }
}
