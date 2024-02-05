using System;
using UnityEngine;

// Node para o ataque do Player, nesse caso o dano ocorre no momento de colisão do Player e do Inimigo (executado pelo GameController).
public class BTAttack : BTNode 
{   
    public GameController gc;
    public Transform player;
    public Transform enemy;
    public BTAttack(BehaviorTree bT, Transform p, Transform e, GameController gamecontroller) : base(bT) {
        player = p;
        enemy = e;
        gc = gamecontroller;
    }
/* Esse execute retorna Success se a vida do Player for igual ou menor a 0
se isso não ocorrer e a distância entre o player e o inimigo for pequena o suficiente, continua Running
se a distancia for maior, retorna Failure*/ 
    public override Result Execute() {
        if (gc.playerHealth <= 0) {
            return Result.Success;
        }
        else if(Vector3.Distance(player.position, enemy.position) <= 0.2f) {
            return Result.Running;
        }
        return Result.Failure;
    }
}