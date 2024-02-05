using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
    private BTNode mRoot;
    private bool startedBehavior;
    private Coroutine behavior;

    public BTNode Root { get { return mRoot; } }

    // Processo de patrulha do inimigo
    public Transform[] waypoints;
    public Transform trans;
    public Transform player;
    public float speed = 0.1f; 

    public GameController gameController;

    // Ao início do jogo, instancializa a estrutura da árvore com os nodes selecionados.
    void Start()
    {

        // comportamento inicial = parado;
        startedBehavior = false;
        mRoot =  new BTRepeater(this, new BTSelector(this, new BTNode[] 
                 {new BTSequencer(this, new BTNode[] 
                 {new BTPlayerCheck(this, player, trans), 
                  new BTMoveTo(this, player, trans), 
                  new BTAttack(this, player, trans, gameController)}), new BTAndar(this, trans, waypoints)}));
        
    }
    // Se o comportamento da árvore não tiver iniciado, inicia-o.
    void Update()
    {
        if(!startedBehavior) {
            behavior = StartCoroutine(RunBehavior());
            startedBehavior = true;
        }
    }
    
    /* IEnumerator é usado para podermos criar uma Coroutine, que é meio que "linha do tempo alternativa" 
    Isso serve para que a função possa executar durante multíplos frames e não durante um só.
    Na utilização original servia para que pudesse checar a movimentação dos inimigos durante vários frames */

    /* Usa o valor result para retornar a função Execute da raiz da subÁrvore atual, 
    função execute de cada classe será melhor explicada na sua classe  */
    private IEnumerator RunBehavior() {
        BTNode.Result result = Root.Execute();
        while (result == BTNode.Result.Running) {
            Debug.Log("resultado do Root: " + result);
            yield return null;
            result = Root.Execute();

        }
        Debug.Log("Comportamento terminou com: " + result);

    }
}
