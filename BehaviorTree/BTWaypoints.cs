using System;
using UnityEngine;

/* Essa é a primeira classe de Nodes que vão executar algo in-game, nesse caso a partir de pontos definidos dentro do Unity,  
vão definir o comportamento idle dos inimigos, enquanto o player está longe.*/
public class BTWaypoints : BTNode 
{   
     public Transform transform; 
    public Transform [] waypoints;
    public int currentWaypoint = 0;

    public float waitTime = 0.5f;
    public float waitCounter = 0;
    public bool waiting = false;
    public BTWaypoints(BehaviorTree bT, Transform t, Transform [] w) : base(bT) {
        transform = t; 
        waypoints = w; 
    }
 
   
    /* Esse execute primeiramente usa a variável waiting para checar se está no intervalo de espera. 
    Após o intervalo de espera; checa a posição do Transform a mover-se em relação ao Waypoint, 
    Se essa distância for pequena o suficiente, reseta o tempo de espera e muda o CurrentWaypoint para o próximo, Retornando Sucess.
    Se a distância for maior, move o Transform até o Waypoint desejado e retoruna Running.
    */
    public override Result Execute() {
        if (waiting) {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime) {
                waiting = false;
            }
        }
        else {
            Transform wp = waypoints[currentWaypoint];
            if (Vector3.Distance(transform.position, wp.position) < 0.01f   ) {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                return Result.Success;
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, Tree.speed * Time.deltaTime);
                return Result.Running;
            }
        }
    }
}