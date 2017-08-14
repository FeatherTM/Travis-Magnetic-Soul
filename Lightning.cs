using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    //Variables
    public GameObject ray;
    public GameObject ray2;
    public Camera fpscam;
    public bool csr = true;
    public bool[] cup = new bool[4] {true,true,true,true};
    void Start () {
        ray.SetActive(false);
        ray2.SetActive(false);
    }
	void FixedUpdate () {
        if (csr == true) { 
        if (Input.GetKey(KeyCode.Q)) {
           ray.SetActive(true);
           csr = false;
           SC5();    
            }
        }
        if (cup[0] == true) { 
        if (Input.GetKey(KeyCode.P)) {
            ray2.SetActive(true);
            cup[0] = false;
            StartCoroutine(CD2());
            }
        }
        }
    void SC5() {
        StartCoroutine(CD());
    }
    IEnumerator CD() {
        yield return new WaitForSeconds(5);
        ray.SetActive(false);
        csr = true;
    }
    IEnumerator CD2() {
        yield return new WaitForSeconds(12);
        ray2.SetActive(false);
        cup[0] = true;
    }
	}
