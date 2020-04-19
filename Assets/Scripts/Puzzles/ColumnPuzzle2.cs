using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColumnPuzzle2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    Transform _column;

    [SerializeField]
    UIManager _uiManager;

    [SerializeField]
    float rotationZ;

    [SerializeField]
    Puzzle2Manager _puzzle2Manager;
    
    public enum NumberColumn{ Column1,Column2,Column3};
    public NumberColumn numberColumn;
    bool _playerInside;
    bool canRotate = true;
    private void Start()
    {
        canRotate = true;
        _playerInside = false;
    }
  

    private void OnTriggerStay(Collider other)
    {
        _playerInside = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _playerInside = false;
    }
   
    public void Rotate_L(InputAction.CallbackContext ctx)
    {
        //Esta en started porque si es en performed, detecta el started(una vez) y despues si se esta presionando(dos veces), asi que se ejecuta dos veces y suma el angulo de rotacion{
        if (ctx.started && _playerInside)
        {
            if (canRotate) //Variable que controla que si pulsas en mitad de la rotacion, no se sume el angulo por pulsar varias veces
            {
                _column.transform.DOLocalRotate(new Vector3(0, 0, 90), 1f, RotateMode.LocalAxisAdd).OnComplete(() => OnCompleteRotation()).OnStart(() => canRotate = false);
            }
        }
    }
    public void Rotate_R(InputAction.CallbackContext ctx)
    {
        //Esta en started porque si es en performed, detecta el started(una vez) y despues si se esta presionando(dos veces), asi que se ejecuta dos veces y suma el angulo de rotacion{
        if (ctx.started && _playerInside)
        {
            if (canRotate) //Variable que controla que si pulsas en mitad de la rotacion, no se sume el angulo por pulsar varias veces
            {
                _column.transform.DOLocalRotate(new Vector3(0, 0, -90), 1f, RotateMode.LocalAxisAdd).OnComplete(() => OnCompleteRotation()).OnStart(() => canRotate = false);
            }
        }
    }

    void OnCompleteRotation()
    {
        canRotate = true;
        if(_column.transform.rotation.eulerAngles.z == rotationZ)
        {
            switch (numberColumn)
            {
                case NumberColumn.Column1:
                    _puzzle2Manager.Column1(true);
                    break; 
                case NumberColumn.Column2:
                    _puzzle2Manager.Column2(true);
                    break; 
                case NumberColumn.Column3:
                    _puzzle2Manager.Column3(true);
                    break;
            }
        }
    }

    
    


}
