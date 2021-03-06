/// Movimento Básico

public class Jogador : MonoBehaviour
{

    public float velocidade; //=variável publica (qualquer um pode mudar, ela aparece no unity p ser alteravel) do tipo float (n decimal)
    public float cameraSensibilidade;
    public float velocidadeGiro; //criei p poder usar velocidade diferente da cameraSensibilidade
    // Update is called once per frame
    void Update()
    {
       MovimentoMouse(); //criar função só para organizar melhor documento, ela esta lá embaixo

        //Para frente 
        if (Input.GetKey(KeyCode.W)) // ele observa se essa condição é verdadeira o tempo todo, mas um jogo cheio de "if" exige mais processamento, por isso usamos "else if"
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocidade); //Time.deltaTime = desrelaciona o tempo em jogo com a capacidade de processamento da máquina, assim pode jogar o mesmo jogo em máquinas diferentes
        
        }
        //Esquerda
        else if (Input.GetKey(KeyCode.A)) //só se a outra não for verdadeira ele muda p essa opção, só se tirar os "else" é possível apertar 2 botões ao mesmo tempo e criar movimento diagonal
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidade); 
            transform.Rotate(0, -1 * velocidadeGiro, 0); // ir pra esquerdaa=ir sentido negativo do eixo x -> rotacionamos o eixo y
           }
  
        //Direita
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidade);
            transform.Rotate(0, 1 * velocidadeGiro, 0);
        }
        //Para trás
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * velocidade);

        //Para cima
         else if (Input.GetKey(KeyCode.Space))
            transform.Translate(Vector3.up * Time.deltaTime * velocidade);

        // Para baixo
         else if (Input.GetKey(KeyCode.V))
            transform.Translate(Vector3.down * Time.deltaTime * velocidade);
    }
// Para mover em joystick:
       float paraOsLados =  Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;
        float paraFrenteTras = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;
        transform.Translate(-paraOsLados, 0, paraFrenteTras); 

// exemplo função:
    void MovimentoMouse()
    {  //poderia tirar essa parte das {} e deixar lá emcima no lugar na função
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 lookhere = new Vector3(-mouseY * cameraSensibilidade, 0, 0); // vetor3 = 0,0,0 = x,y,z (se add mudança em 2 eixos ele desloca na diagonal)
        transform.Rotate(lookhere); //nesse caso foi usado o eixo y do mouse (vertical) que esta sendo rotacionado pelo eixo x 
        //para permitir que a camera rode p cima e pra baixo qnd movemos o mouse
       
    }
}

////// COM HABILIDADE DE VOO ////////////////////////////////////////////////////////////////////////////
public class Jogador : MonoBehaviour
{

    public float velocidade;
    public float cameraSensibilidade;
    public float velocidadeGiro;
    private Rigidbody rb;
    public float forcaPulo;
    public float anularGrav = 8.12F;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Voo();
        MovimentoMouse();
        MovimentoJogador();
        
    }
    void Voo()
    {

        rb.AddForce(Vector3.up * anularGrav); //com gravidade ligada precisas d força pra cima contraria suficiente p anular
       //rb.useGravity = false;

    }
    void MovimentoJogador()
        {
            //Para frente 
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * velocidade);
                //rb.AddForce(transform.forward * velocidade);

            }
            //Esquerda
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.right * Time.deltaTime * velocidade);
                //rb.AddForce(Vector3.left * velocidade);
                transform.Rotate(0, -1 * velocidadeGiro, 0, Space.World);
            }

            //Direita
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * velocidade);
                //rb.AddForce(Vector3.left * velocidade);
                transform.Rotate(0, 1 * velocidadeGiro, 0, Space.World);
            }
            //Para trás
            else if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.back * Time.deltaTime * velocidade);

            //Para cima
            else if (Input.GetKey(KeyCode.Space))
                //rb.AddForce(Vector3.up * forcaPulo);
            transform.Translate(Vector3.up * Time.deltaTime * velocidade);

            // Para baixo
            else if (Input.GetKey(KeyCode.V))
                transform.Translate(Vector3.down * Time.deltaTime * velocidade);

        }
    

    void MovimentoMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 lookhere = new Vector3(-mouseY * cameraSensibilidade, 0, 0);
        transform.Rotate(lookhere);
    }
}
