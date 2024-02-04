using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /* Classe Base dos nodes da árvore. construtor simples apenas instancializa o node na árvore.
    Não possui filhos (node folha) e seu Execute() sempre retorna Failure */
public class BTNode 
{
    public enum Result {Running, Failure, Success};

    public BehaviorTree Tree { get; set; }

    public BTNode(BehaviorTree t) {
        Tree = t;
    }
    
    public virtual Result Execute() {
        return Result.Failure;
    }

}