using UnityEngine;
using System.Collections;
//Bibliotecas               Kenedy você alterou sem querer

public class PlayerController : MonoBehaviour {  //Declaração da Classe
   //Declaração das variaveis
     public Transform spritePlayer; //Capa do player
   public float speed = 5.0f;
   public float jumpForce = 9.0f;
   private Rigidbody2D rb2d;
   public bool isGrounded; 
   public AudioSource jumpSound; 
   private bool ataque;
   public Animator animator;


   // Inincio
   void Start () {

     rb2d = GetComponent<Rigidbody2D>();
     isGrounded=true;
     animator = spritePlayer.GetComponent<Animator>();
   }
   // Atualização
   void Update () {
     
      ataque=false;
      move ();
      Jump ();
      Ataque();
   }
 

 // Essa função tem finalidade de atualizar a posição do jogador
   void move(){
      float horizontalForceButton = Input.GetAxis ("Horizontal");
      rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
      float inputAxis = Input.GetAxis("Horizontal");
      if(inputAxis > 0)
      {
         transform.eulerAngles = new Vector2(0f,0f);
      }
        if(inputAxis < 0)
      {
         transform.eulerAngles = new Vector2(0f,180f);
      }
  
    
    }
// Essa função tem finalidade de informar que o jogador pulou
    void Jump()
    {
       if(Input.GetButtonDown("Jump") && isGrounded)
       {
          rb2d.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
          jumpSound.Play();
       }
    }
  void Ataque()
    {
       if(Input.GetKeyDown("s") && isGrounded)
       {
         ataque=true;
         animator.SetBool ("ataque", ataque);
       }
    }

}