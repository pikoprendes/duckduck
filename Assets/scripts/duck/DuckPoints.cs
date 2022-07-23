using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckPoints : MoveDuck
{

    //hereda de move duck y cambia la velocidad y los puntos
    public void Reset()
    {
        verSpeed = 7;
        verSpeedSave = 7;
        horSpeed = 10;
        horSpeedSave = 10;
        duckPoints = 500;
    }


}