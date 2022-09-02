using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    [SerializeField] Transform playerHand;
    [SerializeField] List<GameObject> foodList;
    public List<GameObject> FoodList { get => foodList; set => foodList = value; }

    private float delay = 1f;

    private float repeatTime = 30f;

    private void Start(){

        foodList = new List<GameObject>();
        InvokeRepeating("MakeFood", delay, repeatTime); //después de 30 segundos vuelven a aparecer las comidas
    }

    private void Update() {
        
    }
    
    public void EatsFood(GameObject food){

        //desactivo una sola comida
        food.SetActive(false);        
    }

    private void MakeFood(){

        foreach (GameObject food in foodList)
            food.SetActive(true);
   
    }

    public void GrabFood(GameObject food){
        
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
