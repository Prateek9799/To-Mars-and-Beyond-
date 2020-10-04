using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class GitVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    CarUserControl vehicleScript;
    public GameObject guiObj;
    GameObject player;
    public Camera campla, camcar;


    void Start()
    {
        campla.enabled = true;
        camcar.enabled = false;
        vehicleScript = GetComponent<CarUserControl>();
        player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey("E"))
            {
                guiObj.SetActive(false);
                campla.enabled = false;
                camcar.enabled = true;
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                player.SetActive(false);
                inVehicle = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
            campla.enabled = true;
            camcar.enabled = false;
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey("E"))
        {
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}
