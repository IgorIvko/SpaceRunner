using UnityEngine;

public class Bullet: MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;    
    private Wall _bulletDestroyer;   
    private AidKit _aidKit;
    private SkullBox _skullBox;    

    private void Update() => transform.position += new Vector3(_bulletSpeed * Time.deltaTime, 0, 0);        
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Wall>(out _bulletDestroyer))        
            gameObject.SetActive(false);          

        if (collision.TryGetComponent<AidKit>(out _aidKit))
            gameObject.SetActive(false);

        if (collision.TryGetComponent<SkullBox>(out _skullBox))
            gameObject.SetActive(false);
    }    
   
}
