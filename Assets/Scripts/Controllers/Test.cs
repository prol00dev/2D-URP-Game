using UnityEngine;

public class Test : MonoBehaviour
{
    public bool stop = true;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stop = !stop; // Инвертируем значение переменной stop
            Debug.Log(stop);
        }

    }
     

}