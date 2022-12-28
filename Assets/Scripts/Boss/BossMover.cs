using UnityEngine;

public class BossMover : MonoBehaviour
{
    [SerializeField] private float _bossSpeed;
    private const float _bossX = 9;  
    
    void Update()
    {
        if (transform.position.x > _bossX)
            transform.position -= new Vector3(2 * Time.deltaTime, 0, 0);
        else
            transform.position -= new Vector3(_bossSpeed * Time.deltaTime, 0, 0);
        
    }
}
