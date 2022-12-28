using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HeroInput))]
public class HeroMover : MonoBehaviour
{
    [SerializeField] private Button _targetButton;
    [SerializeField] private float _verticalBorder;
    [SerializeField] private float _speed;
    private Animator _anim;
    private float _endY;

    public float VerticalBorder => _verticalBorder;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void MoveUp()
    {
        if (transform.position.y == _verticalBorder || _endY >= _verticalBorder)
           return;
        _anim.SetBool("IsMovingUp", true);
        _endY = transform.position.y + _verticalBorder;        
    }

    public void MoveDown()
    {
        if (transform.position.y == -_verticalBorder || _endY <= -_verticalBorder)
            return;
        _anim.SetBool("IsMovingDown", true);
        _endY = transform.position.y - _verticalBorder;        
    }

    private void Update()
    {
        if (transform.position.y < _endY)
        {
            transform.position += new Vector3(0, _speed * Time.deltaTime, 0);
            if (transform.position.y > _endY)
            {
                transform.position = new Vector3(transform.position.x, _endY, transform.position.z);
                _anim.SetBool("IsMovingUp", false);                
            }
        }

        if (transform.position.y > _endY)
        {
            transform.position -= new Vector3(0, _speed * Time.deltaTime, 0);
            if (transform.position.y < _endY)
            {
                transform.position = new Vector3(transform.position.x, _endY, transform.position.z);
                _anim.SetBool("IsMovingDown", false);
            }
        }

        if (transform.position.y > VerticalBorder)
        {
            _endY = VerticalBorder;
            transform.position = new Vector3(transform.position.x, _endY, transform.position.z);            
        }

        if (transform.position.y < -VerticalBorder)
        {
            _endY = -VerticalBorder;
            transform.position = new Vector3(transform.position.x, _endY, transform.position.z);            
        }       
    }
    private void StopAnimationMoving()
    {
        _anim.SetBool("IsMovingUp", false);
    }

}
