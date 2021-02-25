using UnityEngine;

public class PointInTime
{
    //classe de retorno no tempo

    public Vector3 position;
    public Quaternion rotation;

    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
