using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollows : MonoBehaviour
{
    public Transform target; // On défini une variable publique pour la cible de la caméra
    public float smoothing = 5f; // On défini une variable publique avec un défaut pour le smoothing que l'on veut appliquer à la caméa
    Vector3 offset; // Propriété qui va contenir la différence à maintenir entre la position du personnage ainsi que la position de la caméra
    // Use this for initialization
    public float shakeTimer;
    public float shakeAmount;

void Start()
    {
        offset = transform.position - target.position; // Calcul de l'offset à garder entre le personnage et la caméra
        // transform est par défaut disponible dans les classes lié à un game objet
        // ce qui nous permet de le réupérer sans avoir besoin d'utiliser GetComponent
        // transform équivaut à la rubrique transforme au sein de l'inspecteur quand on clique sur un objet
        // L'offset correspondra toujours à la position du personnage et caméra dans la scène
    }
    void FixedUpdate()
    { // Fixed Update au lieu de Update pour avoir une interval régulier, au lieu de chaque frame
        if (target != null)
        {
            Vector3 targetCamPosition = target.position + offset; // on défini la position où la caméra doit se trouver
            transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime); // met à jour la position de la caméra
                                                                                                                  // Ici lerp nous permet de faire une transition linéaire entre deux point de façon fluide
                                                                                                                  // Je vous laisse aller voir sur la documentation unity si vous voulez en savoir plus sur cette fonction
                                                                                                                  // Ici on utlise Time.deltaTime pour calculer le temps de déplacement * le smoothing
                                                                                                                  // Cela nous permet d'avoir une petite latence entre le personnage qui s'arrête et la caméra qui s'arrete sur lui, ça donne de la geule
                                                                                                                  // Attention Time.deltaTime représente le temps entre chaque frame
                                                                                                                  // Ici on utilise sur fixed update qui intevient à interval régulier
                                                                                                                  // Cependant sur une fonction update normale, le deltaTime étant basé sur les frame, le temps varie selon les moment du jeu
                                                                                                                  // deltaTime est à privilégier dans fixedUpdate au lieu de update au mieux que possible pour éviter les surprises
        }
        else
            transform.position = this.transform.position;
        //GetComponent<PlayerHearth>().GetLifePoints() > 0 
    }

    void Update()
    {
        if (shakeTimer >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            ShakeCamera(0.1f, 1);
        }
    }
    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;

    }
}