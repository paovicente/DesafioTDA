using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    
    [SerializeField] GameObject[] cameras;

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyUp(KeyCode.C))
            changeCamera();
    }

    private void changeCamera(){

        if (cameras[0].activeSelf == true){
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
            cameras[2].SetActive(false);
        }else if (cameras[1].activeSelf == true){
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            cameras[2].SetActive(true);
        }else if (cameras[2].activeSelf == true){
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
        }
    }

}

