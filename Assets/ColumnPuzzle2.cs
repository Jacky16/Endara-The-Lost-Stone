using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColumnPuzzle2 : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] 
    Transform _column;
    bool _playerInside;
    bool canRotate = true;
    private void Start()
    {
        canRotate = true;
    }

    private void OnTriggerStay(Collider other)
    {
        _playerInside = true;
        print(_playerInside);
    }
    private void OnTriggerExit(Collider other)
    {
        _playerInside = false;
        print(_playerInside);
    }
   
    public void Rotate_L(InputAction.CallbackContext ctx)
    {
        //Esta en started porque si es en performed, detecta el started(una vez) y despues si se esta presionando(dos veces), asi que se ejecuta dos veces y suma el angulo de rotacion{
        if (ctx.started && _playerInside)
        {
            if (canRotate) //Variable que controla que si pulsas en mitad de la rotacion, no se sume el angulo por pulsar varias veces
            {
                _column.transform.DOLocalRotate(new Vector3(0, 0, 90), 1f, RotateMode.LocalAxisAdd).OnComplete(() => canRotate = true).OnStart(() => canRotate = false);
            }
        }
    }
    public void Rotate_R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _playerInside)
        {
            _column.transform.DOLocalRotate(new Vector3(0, 0, 90), 1, RotateMode.LocalAxisAdd);
        }
    }


}
