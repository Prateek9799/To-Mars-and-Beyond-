using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;


public class EnterVehicle : MonoBehaviour
{
    public GameObject Vehicle, Player;
    private bool inVehicle = false;
    CarUserControl vehicleScript;
    public GameObject instruction;


    void Start()
    {
        vehicleScript = GetComponent<CarUserControl>();
        vehicleScript.enabled = false;
        Player = GameObject.FindWithTag("Player");
        instruction.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            instruction.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                instruction.SetActive(false);
                Player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                Player.SetActive(false);
                inVehicle = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == true)
        {
            instruction.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.E))
        {
            vehicleScript.enabled = false;
            Player.SetActive(true);
            Player.transform.parent = null;
            inVehicle = false;
        }
    }
}
