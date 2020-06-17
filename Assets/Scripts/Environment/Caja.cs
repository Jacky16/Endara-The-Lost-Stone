using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Caja : MonoBehaviour
{
    [SerializeField] 
    GameObject prefabBoxDestroyed;

    [SerializeField]
    float _explosionForce;

    [SerializeField]
    AudioClip[] _audiosDestroyBox;

    [SerializeField]
    float _explosionRadius;

    AudioSource _audioSource;
    public UnityEvent OnDestroy;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cola"))
        {
            Explosion();
            OnDestroy.Invoke();
        }
    }
    void Explosion()
    {
        GameObject go = Instantiate(prefabBoxDestroyed, transform.position, Quaternion.identity);
        Rigidbody[] rb = go.GetComponentsInChildren<Rigidbody>();

        AudioClip currentAudio = AudioClipRandom();
        _audioSource.PlayOneShot(currentAudio);
        print(currentAudio.name);
        _audioSource.DOFade(0, currentAudio.length);
        foreach (Rigidbody r in rb)
        {
            r.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;

        Destroy(gameObject, currentAudio.length);
        //Destruyo la caja en pedazos
        Destroy(go, 4);

    }
    AudioClip AudioClipRandom()
    {
        return _audiosDestroyBox[Random.Range(0, _audiosDestroyBox.Length)];
    }
}
