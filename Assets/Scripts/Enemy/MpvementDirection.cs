using UnityEngine;

public class MovementDirection : MonoBehaviour
{
    private float _speed = 5;

    public void ProcessMoveTo(Transform reactor,Vector3 direction)
    {
        Vector3 normalizedDirection = direction.normalized;
        normalizedDirection.y = 0f;
        reactor.Translate(normalizedDirection * _speed * Time.deltaTime);
    }
}
