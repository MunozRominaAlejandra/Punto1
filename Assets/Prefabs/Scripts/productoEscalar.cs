using UnityEngine;

public class productoEscalar : MonoBehaviour
{
    public Transform player;
    [Range(-1f, 1f)]
    /* - - - - - - - - - - PUNTO 1 - - - - - - - - - -
    
    Implementar y probar con distintos valores de umbralCoseno.

    - - - - - - - - - DESARROLLO - - - - - - - - -
    Desde el Inspector de Unity, en enemigo, se puede modificar el valor de umbralCoseno para ver cómo afecta la
    detección del jugador.
    Un valor más alto (cercano a 1) significa que el jugador debe estar más alineado con la dirección del objeto
    para ser detectado.
    A medida que el valor disminuye, el campo de visión se amplía, permitiendo detectar al jugador incluso cuando
    se encuentra más hacia los costados.
    */
    public float umbralCoseno = 0.7f;

    void Update()
    {
        Vector3 direccion = (player.position - transform.position).normalized;

        float dot = Vector3.Dot(transform.forward, direccion);

        if (dot > umbralCoseno)
        {
            Debug.Log("¡Jugador detectado!");
        }
        else
        {
            Debug.Log("Jugador fuera del campo de visión.");
        }
    }

    #region Dibujar Vectores
    void OnDrawGizmos()
    {
        if (player == null)
            return;

        Vector3 direccion = (player.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, direccion);

        //Representa el vector que va desde el enemigo hacia el jugador
        //El color verde es cuando el jugador entra en el campo de visión del enemigo, y rojo cuando no.
        Gizmos.color = dot > umbralCoseno ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, player.position);

        //Representa el vector de dirección del enemigo
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 3);
    }
    #endregion
}
