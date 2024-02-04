using System;
using System.Numerics;
using UnityEngine;
/* Node que faz o inimigo perseguir o player. Herda de BTNode (node folha)*/
public class BTMoveTo : BTNode 
{   

    public Transform player;
    public Transform enemy;
    public BTMoveTo(BehaviorTree bT, Transform p, Transform e) : base(bT) {
        player = p;
        enemy = e;
    }
    /* Esse execute retorna Success caso o Inimigo chegue perto o suficiente do Player
    Retorna Running ao identificar o Player a uma distância razoável do Inimigo 
    e Retorna Failure ao não encontrar o Player. */
    public override Result Execute() {
        if (UnityEngine.Vector3.Distance(player.position, enemy.position) <= 0.1f) {
            return Result.Success;
        }
        else if(UnityEngine.Vector3.Distance(player.position, enemy.position) <= 0.8f) {
            enemy.position = UnityEngine.Vector3.MoveTowards(enemy.position, player.position, Tree.speed * Time.deltaTime);
            return Result.Running;
        }
        return Result.Failure;
    }
}