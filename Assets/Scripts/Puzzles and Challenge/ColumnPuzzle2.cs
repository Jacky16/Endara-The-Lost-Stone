using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColumnPuzzle2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    Transform _column;
    UIManager uIManager;
    [SerializeField]
    Puzzle2Manager _puzzle2Manager;
    [SerializeField]
    ParticleSystem smokeColumn;
    AudioSource audioColumnRotating;
    
    public enum NumberColumn{ Column1,Column2,Column3};
    public NumberColumn numberColumn;
    bool _playerInside;
    bool canRotate = true;
    private void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        audioColumnRotating = GetComponent<AudioSource>();
    }
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
        if (other.CompareTag("Player"))
        {
            uIManager.AnimationMoveUpButtonsRotate();

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canRotate)
        {
            _playerInside = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInside = false;
            uIManager.AnimationMoveDownButtonsRotate();
        }
    }
   
    public void Rotate_L(InputAction.CallbackContext ctx)
    {
        //Esta en started porque si es en performed, detecta el started(una vez) y despues si se esta presionando(dos veces), asi que se ejecuta dos veces y suma el angulo de rotacion{
        if (ctx.started && _playerInside)
        {
            if (canRotate) //Variable que controla que si pulsas en mitad de la rotacion, no se sume el angulo por pulsar varias veces
            {
                smokeColumn.Play();
                _column.transform.DOLocalRotate(new Vector3(0, 0, 90), audioColumnRotating.clip.length, RotateMode.LocalAxisAdd).OnStart(() => canRotate = false).OnComplete(() => canRotate = true);
                if(!audioColumnRotating.isPlaying)
                    audioColumnRotating.Play();
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
                smokeColumn.Play();
                _column.transform.DOLocalRotate(new Vector3(0, 0, -90), audioColumnRotating.clip.length, RotateMode.LocalAxisAdd).OnStart(() => canRotate = false).OnComplete(() => canRotate = true);
                Vector3 currentRotation = _column.transform.localRotation.eulerAngles;
                if (!audioColumnRotating.isPlaying)
                    audioColumnRotating.Play();
            }
        }
    }

    void OnCompleteRotation()
    {
        switch (numberColumn)
        {
            case NumberColumn.Column1:
                _puzzle2Manager.Column1(true);
                smokeColumn.Stop();
                break;
            case NumberColumn.Column2:
                _puzzle2Manager.Column2(true);
                smokeColumn.Stop();
                break;
            case NumberColumn.Column3:
                _puzzle2Manager.Column3(true);
                smokeColumn.Stop();
                break;
        }
    }
    private void OnDisable()
    {
        uIManager.AnimationMoveDownButtonsRotate();
    }

}
