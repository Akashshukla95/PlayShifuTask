using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public float timeforCollectables;

    void Start()
 {
     StartCoroutine(SelfDestruct());
 }
 IEnumerator SelfDestruct()
 {
     yield return new WaitForSeconds(timeforCollectables);
     Destroy(gameObject);
 }
}
