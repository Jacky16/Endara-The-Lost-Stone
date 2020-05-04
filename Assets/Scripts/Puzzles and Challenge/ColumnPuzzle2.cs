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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Solution"))
        {
            Invoke("OnCompleteRotation", .5f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInside = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInside = false;

        }
    }
   
    public void Rotate_L(InputAction.CallbackContext ctx)
    {
        //Esta en started porque si es en performed, detecta el started(una vez) y despues si se esta presionando(dos veces), asi que se ejecuta dos veces y suma el angulo de rotacion{
        if (ctx.started && _playerInside)
        {
            if (canRotate) //Variable que controla que si pulsas en mitad de la rotacion, no se sume el angulo por pulsar varias veces
            {
                _column.transform.DOLocalRotate(new Vector3(0, 0, 90), 1f, RotateMode.LocalAxisAdd).OnStart(() => canRotate = false).OnComplete(() => canRotate = true);
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
                _column.transform.DOLocalRotate(new Vector3(0, 0, -90), 1f, RotateMode.LocalAxisAdd).OnStart(() => canRotate = false).OnComplete(() => canRotate = true);
                Vector3 currentRotation = _column.transform.localRotation.eulerAngles;
                print(currentRotation);
            }
        }
    }

    void OnCompleteRotation()
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
