using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpot1;
    public Transform[] moveSpot2;
    private int randonSpot;

    public Transform[] spawnSpot;
    private int randonSpawn;

    //No inicio do jogo...
    void Start()
    {
        // Define um ponto aleátorio entre os pontos de spawn como o ponto escolhido para spawnar
        randonSpawn = Random.Range(0, spawnSpot.Length);
        // Printa na tela de debug do jogo o ponto escolhido de spawn
        Debug.Log(randonSpawn);
        // O animal tem modificado os valores de sua posição para a mesma posição do ponto de spwan
        // escolhido. Dessa forma, ele spawna no ponto de spwan escolhido. 
        transform.position = spawnSpot[randonSpawn].position;
        // Modifica o valor do tempo de espera para o valor que o programador definiu no consolhe
        waitTime = startWaitTime;
        //Se o ponto de spawn for igual ao primeiro ponto na lista de spwan(Ou seja o ponto de spawn 0)...
        if (randonSpawn == 0)
        {
            //Então,Faça com que o destino que o animal irá se movimentar para seja um ponto aleatório de
            // uma lista 1 ( Lista que define os pontos de movimento que ele pode se movimentar para 
            // de acordo com o spawn que spawnou).
            randonSpot = Random.Range(0, moveSpot1.Length);
        }
        else
        {
            // Se o ponto de spawn for igual ao segundo ponto na lista de spwan
            //( Ou seja o ponto de spawn 1)...
            if (randonSpawn == 1)
            {
                //Então,Faça com que o destino que o animal irá se movimentar para seja um ponto aleatório 
                // de uma lista 2 ( Lista que define os pontos de movimento que ele pode se movimentar  
                // para de acordo com o spawn que spawnou).
                randonSpot = Random.Range(0, moveSpot2.Length);
            }
        }
        
    }
    //A cada freme que se passa no jogo... 
    void Update()
    {
        //Se o ponto de spawn for igual ao primeiro ponto na lista de spwan
        //(Ou seja o ponto de spawn 0)...
        if (randonSpawn == 0){
            //Então, O animal se movimenta do ponto onde está atualmente para o ponto de movimento defi-
            //nido em uma tal velocidade. 
            transform.position = Vector3.MoveTowards(transform.position, moveSpot1[randonSpot].position, speed * Time.deltaTime);
            // Se a posição do animal for igual a posição definida...
            if (Vector3.Distance(transform.position, moveSpot1[randonSpot].position) < 0.2f) {
                //E também se o tempo de espera tenha chegado a zero...
                if (waitTime <= 0) {
                    // Então, Escolha outro pronto para se movimentar para.
                    randonSpot = Random.Range(0, moveSpot1.Length);
                    // E redefina o tempo de espera. 
                    waitTime = startWaitTime;
                }
                else {
                    //Senão, subitraia o frame passado do tempo de espera. 
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            // Se o ponto de spawn for igual ao segundo ponto na lista de spwan
            //( Ou seja o ponto de spawn 1)...
            if (randonSpawn == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveSpot2[randonSpot].position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, moveSpot2[randonSpot].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        randonSpot = Random.Range(0, moveSpot2.Length);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
            
        }
    }
}
