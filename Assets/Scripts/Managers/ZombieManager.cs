using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {

    private Dictionary<string, GameObject> zombieDirectory;
    public Dictionary<string, GameObject> ZombieDirectory { get => zombieDirectory; set => zombieDirectory = value; }

    // Start is called before the first frame update
    void Start(){

        zombieDirectory = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update(){
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) zombieController(zombieDirectory["WeaponA"]);
        if (Input.GetKeyDown(KeyCode.Alpha2)) zombieController(zombieDirectory["WeaponB"]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) zombieController(zombieDirectory["WeaponD"]);*/
    
    }

    public void zombieController(){

    }
}
