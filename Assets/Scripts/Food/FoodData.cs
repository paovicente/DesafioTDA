using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodData : MonoBehaviour {

    [SerializeField][Range(1, 150)] private int healPoints = 30;
    public int HealPoints { get { return healPoints; } }
}
