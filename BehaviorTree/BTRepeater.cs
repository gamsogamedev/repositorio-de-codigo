using System; 
using UnityEngine;

/* Herda da Classe Decorator que Herda de BTNode.
Possui um único filho e seu Execute() retorna Running infinitamente, serve para loopar um comportamento */

public class BTRepeater : Decorator 
{
    public BTRepeater(BehaviorTree t, BTNode c) : base(t, c) {
    }

    public override Result Execute() {
        Debug.Log("Filho retornou:" + Child.Execute());
        return Result.Running;
    }
}