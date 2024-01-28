using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pantalla1;
    public GameObject pantalla2;
    
    public GameObject pantalla3;
    public GameObject pantalla4;
    

    // Start is called before the first frame update
    public void cambiarPantalla(string pantalla){

        switch(pantalla){

            case "1": 
                pantalla1.transform.gameObject.SetActive(true); 
                pantalla2.transform.gameObject.SetActive(false); 
                break;   
            case "2": 
                pantalla1.transform.gameObject.SetActive(false); 
                pantalla2.transform.gameObject.SetActive(true); 
                break;    
            case "3": 
                pantalla3.transform.gameObject.SetActive(true); 
                pantalla4.transform.gameObject.SetActive(false); 
                break;   
            case "4": 
                pantalla3.transform.gameObject.SetActive(false); 
                pantalla4.transform.gameObject.SetActive(true); 
                break;    
            
        }

    }



    
}
