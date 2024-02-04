using System;
using UnityEngine;

// Essa classe é o node que checa se o Player está próximo, simplesmente.
public class BTPlayerCheck : BTNode 
{   

    public Transform player;
    public Transform enemy;
    public BTPlayerCheck(BehaviorTree bT, Transform p, Transform e) : base(bT) {
        player = p;
        enemy = e;
    }
 
  //Retorna Success se o player está proximo, retorna Failure se está distante.
    public override Result Execute() {
        if(Vector3.Distance(player.position, enemy.position) < 0.8f) {
            return Result.Success;
        }
        return Result.Failure;
    }
}   