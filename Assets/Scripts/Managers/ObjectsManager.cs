using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT DONDE SE MANEJAN LOS OBJETOS DEL CEMENTERIO -- ACÁ USO ARRAY
public class ObjectsManager : MonoBehaviour {
    
    [SerializeField] GameObject[] cementeryObjects;

    private float timer = 0f;
    
    private bool appear = true;

    // Update is called once per frame
    void Update(){
        
        timer += Time.deltaTime;
        IsTimeToAppear();
    }

    private void IsTimeToAppear(){

        if (timer >= 5f){
            if (appear == true){
                DisableObjects();
                timer = 0f;
                appear = false;
            }else{
                EnableObjects();
                timer = 0f;
                appear = true;
            }          
        }
    }
    void DisableObjects(){

        for (int i = 0 ; i < cementeryObjects.Length ; i++)
            cementeryObjects[i].SetActive(false);       
    }

    void EnableObjects(){

        foreach (GameObject cementeryObject in cementeryObjects)
            cementeryObject.SetActive(true);
    }
}
