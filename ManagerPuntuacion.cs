using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPuntuacion : MonoBehaviour
{
    int inputs, fails, success;
    string nombrePlayer;
    // Start is called before the first frame update
    void Start()
    {
        inputs = 0;
        fails = 0;
        success = 0;
        nombrePlayer = "John Doe";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sumarInputs()
    {
        inputs += 1;
    }
    public void registrarFallos(int x)
    {
        fails += x;
    }
    public void registrarSuccess(int x)
    {
        success += x;
    }
}
