using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int texTelhado;
        int texPorta;
        int texPorta2;
        int texGrama;
        int texColuna;
        int lateral = 0;
        Vector3d dir = new Vector3d(0, -450, 120);        //direção da câmera
        Vector3d pos = new Vector3d(0, -550, 800);     //posição da câmera
        float camera_rotation = 0;                     //rotação no eixo Z


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //limpa os buffers
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity(); //zera a matriz de projeção com a matriz identidade


            //                 Matrix4 lookat = Matrix4.LookAt(lateral, -500.0f, 1.5f,    
            //                                              1.5f, 5.0f, 1.5f,
            //                                           0.0f, 0.0f, 1.0f);
            Matrix4d lookat = Matrix4d.LookAt(pos.X, pos.Y, pos.Z, dir.X, dir.Y, dir.Z, 0, 0, 1);

            //aplica a transformacao na matriz de rotacao
            GL.LoadMatrix(ref lookat);
            //GL.Rotate(camera_rotation, 0, 0, 1);

            GL.Enable(EnableCap.DepthTest);

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(500, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 500, 0);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 500);
            GL.End();

            GL.Enable(EnableCap.Texture2D); //habilita o uso de texturas
            GL.BindTexture(TextureTarget.Texture2D, texGrama);
            //GRAMADO
            //GL.Color3(Color.Transparent);
           // GL.Begin(PrimitiveType.Quads);
          //  GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(-150, -50, 0);
          //  GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-150, 500, 0);
          //  GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(800, 500, 0);
          //  GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(800, -50, 0);
          //  GL.End();
          //  GL.Disable(EnableCap.Texture2D);

            GL.Color3(Color.Yellow);
            
            /*GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(500, 0.0, 200);
            GL.Vertex3(500, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 200);

            //GL.Vertex3(100, 0.0, 60.0);
            GL.Vertex3(100, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 0.0);
            //GL.Vertex3(250, 0.0, 60.0);
            GL.Vertex3(100, 0.0, 200.0);
            GL.Vertex3(100, 0.0, 140.0);
            GL.Vertex3(250, 0.0, 140.0);
            GL.Vertex3(250, 0.0, 200.0);

            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0, 200);
            GL.Vertex3(100.0, 0.0, 200.0);
            GL.Vertex3(100.0, 0.0, 0.0);

            GL.End(); */
            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(20, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(90, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(90, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(20, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(400, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(470, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(470, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(400, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            //FRENTE
            GL.Color3(Color.DarkGoldenrod);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(500, 0, 0);
            GL.Vertex3(500, 0, 200);
            GL.Vertex3(250, 0, 200);
            GL.Vertex3(0, 0, 200);
            GL.End();
            
            //PAREDE FUNDO
            GL.Color3(Color.DarkOrange);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 350, 0);
            GL.Vertex3(500, 350, 0);
            GL.Vertex3(500, 350, 200);
            GL.Vertex3(400, 350, 200);
            GL.Vertex3(0, 350, 200);
            GL.End();

            //LATERAL esquerda
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(0, 350, 200); //A      //define as primitivas
            GL.Vertex3(0, 350, 0.0); //B     
            GL.Vertex3(0, 250, 0.0); //C
            GL.Vertex3(0, 250, 200); //D

            GL.Vertex3(0, 100, 0.0);
            GL.Vertex3(0, 100, 0.0);
            GL.Vertex3(0, 250, 0.0);
            GL.Vertex3(0, 250, 0.0);
            GL.Vertex3(0, 100, 200.0);
            GL.Vertex3(0, 100, 0.0);
            GL.Vertex3(0, 250, 0.0);
            GL.Vertex3(0, 250, 200.0);

            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0, 200);
            GL.Vertex3(0, 100, 200.0);
            GL.Vertex3(0, 100, 0.0);

            GL.End();
            
            //LATERAL Direita
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(500, 350, 200); //A      //define as primitivas
            GL.Vertex3(500, 350, 0.0); //B     
            GL.Vertex3(500, 350, 0.0); //C
            GL.Vertex3(500, 0, 200); //D

            GL.Vertex3(500, 100, 0.0);
            GL.Vertex3(500, 100, 0.0);
            GL.Vertex3(500, 350, 0.0);
            GL.Vertex3(500, 350, 0.0);
            GL.Vertex3(500, 100, 200.0);
            GL.Vertex3(500, 100, 0.0);
            GL.Vertex3(500, 350, 0.0);
            GL.Vertex3(500, 350, 200.0);

            GL.Vertex3(500, 0.0, 0.0);
            GL.Vertex3(500, 0.0, 200);
            GL.Vertex3(500, 200, 200.0);
            GL.Vertex3(500, 200, 0.0);

            GL.End();
            
            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(520, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(590, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(590, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(520, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(900, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(970, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(970, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(900, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            //FRENTE
            GL.Color3(Color.DarkGoldenrod);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1000, 0, 0);
            GL.Vertex3(1000, 0, 200);
            GL.Vertex3(500, 0, 200);
            GL.Vertex3(0, 0, 200);
            GL.End();
            
            //PAREDE FUNDO
            GL.Color3(Color.DarkOrange);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 350, 0);
            GL.Vertex3(1000, 350, 0);
            GL.Vertex3(1000, 350, 200);
            GL.Vertex3(800, 350, 200);
            GL.Vertex3(0, 350, 200);
            GL.End();

            //LATERAL ESQUERDA
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(1000, 350, 200); //A      //define as primitivas
            GL.Vertex3(1000, 350, 0.0); //B     
            GL.Vertex3(1000, 350, 0.0); //C
            GL.Vertex3(1000, 0, 200); //D

            GL.Vertex3(1000, 100, 0.0);
            GL.Vertex3(1000, 100, 0.0);
            GL.Vertex3(1000, 350, 0.0);
            GL.Vertex3(1000, 350, 0.0);
            GL.Vertex3(1000, 100, 200.0);
            GL.Vertex3(1000, 100, 0.0);
            GL.Vertex3(1000, 350, 0.0);
            GL.Vertex3(1000, 350, 200.0);

            GL.Vertex3(1000, 0.0, 0.0);
            GL.Vertex3(1000, 0.0, 200);
            GL.Vertex3(1000, 200, 200.0);
            GL.Vertex3(1000, 200, 0.0);

            GL.End();

            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(1020, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(1090, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(1090, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(1020, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(1400, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(1470, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(1470, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(1400, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            //FRENTE
            GL.Color3(Color.DarkGoldenrod);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1500, 0, 0);
            GL.Vertex3(1500, 0, 200);
            GL.Vertex3(1000, 0, 200);
            GL.Vertex3(0, 0, 200);
            GL.End();

            //PAREDE FUNDO
            GL.Color3(Color.DarkOrange);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 350, 0);
            GL.Vertex3(1500, 350, 0);
            GL.Vertex3(1500, 350, 200);
            GL.Vertex3(1300, 350, 200);
            GL.Vertex3(0, 350, 200);
            GL.End();

            //LATERAL ESQUERDA
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(1500, 350, 200); //A      //define as primitivas
            GL.Vertex3(1500, 350, 0.0); //B     
            GL.Vertex3(1500, 350, 0.0); //C
            GL.Vertex3(1500, 0, 200); //D

            GL.Vertex3(1500, 100, 0.0);
            GL.Vertex3(1500, 100, 0.0);
            GL.Vertex3(1500, 350, 0.0);
            GL.Vertex3(1500, 350, 0.0);
            GL.Vertex3(1500, 100, 200.0);
            GL.Vertex3(1500, 100, 0.0);
            GL.Vertex3(1500, 350, 0.0);
            GL.Vertex3(1500, 350, 200.0);

            GL.Vertex3(1500, 0.0, 0.0);
            GL.Vertex3(1500, 0.0, 200);
            GL.Vertex3(1500, 200, 200.0);
            GL.Vertex3(1500, 200, 0.0);

            GL.End();

            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(1520, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(1590, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(1590, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(1520, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //FRENTE
            GL.Color3(Color.DarkGoldenrod);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1700, 0, 0);
            GL.Vertex3(1700, 0, 200);
            GL.Vertex3(1500, 0, 200);
            GL.Vertex3(0, 0, 200);
            GL.End();

            //PAREDE FUNDO
            GL.Color3(Color.DarkOrange);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 350, 0);
            GL.Vertex3(1700, 350, 0);
            GL.Vertex3(1700, 350, 200);
            GL.Vertex3(1500, 350, 200);
            GL.Vertex3(0, 350, 200);
            GL.End();

            //LATERAL ESQUERDA
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(1700, 350, 200); //A      //define as primitivas
            GL.Vertex3(1700, 350, 0.0); //B     
            GL.Vertex3(1700, 350, 0.0); //C
            GL.Vertex3(1700, 0, 200); //D

            GL.Vertex3(1700, 100, 0.0);
            GL.Vertex3(1700, 100, 0.0);
            GL.Vertex3(1700, 350, 0.0);
            GL.Vertex3(1700, 350, 0.0);
            GL.Vertex3(1700, 100, 200.0);
            GL.Vertex3(1700, 100, 0.0);
            GL.Vertex3(1700, 350, 0.0);
            GL.Vertex3(1700, 350, 200.0);

            GL.Vertex3(1700, 0.0, 0.0);
            GL.Vertex3(1700, 0.0, 200);
            GL.Vertex3(1700, 200, 200.0);
            GL.Vertex3(1700, 200, 0.0);

            GL.End();

            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(1720, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(1790, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(1790, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(1720, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta2); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(617f / 1330f, 1330f / 1330f);
            GL.Vertex3(2100, -5, 0);
            GL.TexCoord2(31f / 1330f, 1330f / 1330f);
            GL.Vertex3(2170, -5, 0);
            GL.TexCoord2(31f / 1330f, 31f / 1330f);
            GL.Vertex3(2170, -5, 180);
            GL.TexCoord2(617f / 1330f, 31f / 1330f);
            GL.Vertex3(2100, -5, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //FRENTE
            GL.Color3(Color.DarkGoldenrod);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(2200, 0, 0);
            GL.Vertex3(2200, 0, 200);
            GL.Vertex3(2000, 0, 200);
            GL.Vertex3(0, 0, 200);
            GL.End();

            //PAREDE FUNDO
            GL.Color3(Color.DarkOrange);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 350, 0);
            GL.Vertex3(2200, 350, 0);
            GL.Vertex3(2200, 350, 200);
            GL.Vertex3(2000, 350, 200);
            GL.Vertex3(0, 350, 200);
            GL.End();

            //LATERAL ESQUERDA
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(2200, 350, 200); //A      //define as primitivas
            GL.Vertex3(2200, 350, 0.0); //B     
            GL.Vertex3(2200, 350, 0.0); //C
            GL.Vertex3(2200, 0, 200); //D

            GL.Vertex3(2200, 100, 0.0);
            GL.Vertex3(2200, 100, 0.0);
            GL.Vertex3(2200, 350, 0.0);
            GL.Vertex3(2200, 350, 0.0);
            GL.Vertex3(2200, 100, 200.0);
            GL.Vertex3(2200, 100, 0.0);
            GL.Vertex3(2200, 350, 0.0);
            GL.Vertex3(2200, 350, 200.0);

            GL.Vertex3(2200, 0.0, 0.0);
            GL.Vertex3(2200, 0.0, 200);
            GL.Vertex3(2200, 200, 200.0);
            GL.Vertex3(2200, 200, 0.0);

            GL.End();

            /*
            //TELHADO DIREITA
           // GL.Enable(EnableCap.Texture2D);
            //GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            //GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(-80, -25, 200);
           // GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(-80, 250, 200);
            //GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(400, 250, 200);
           // GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(400, -25, 200);
            GL.End();

            //TELHADO ESQUERDA
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
           // GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(-80, 500, 200);
          //  GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(-80, 250, 200);
           // GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(400, 250, 200);
           // GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(400, 500, 200);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            */
            //BEIRAL
            /* GL.Color3(Color.SaddleBrown);
             GL.Begin(PrimitiveType.Quads);
             GL.Vertex3(-40, -40, 174);
             GL.Vertex3(-40, 125, 240);
             GL.Vertex3(-40, 125, 250);
             GL.Vertex3(-40, -40, 184);

             GL.Vertex3(-40, 290, 174);
             GL.Vertex3(-40, 290, 184);
             GL.Vertex3(-40, 125, 250);
             GL.Vertex3(-40, 125, 240);

             GL.Vertex3(390, -40, 174);
             GL.Vertex3(390, 125, 240);
             GL.Vertex3(390, 125, 250);
             GL.Vertex3(390, -40, 184);

             GL.Vertex3(390, 290, 174);
             GL.Vertex3(390, 290, 184);
             GL.Vertex3(390, 125, 250);
             GL.Vertex3(390, 125, 240);

             GL.Vertex3(390, -40, 174);
             GL.Vertex3(390, -40, 184);
             GL.Vertex3(-40, -40, 184);
             GL.Vertex3(-40, -40, 174);

             GL.Vertex3(390, 290, 174);
             GL.Vertex3(390, 290, 184);
             GL.Vertex3(-40, 290, 184);
             GL.Vertex3(-40, 290, 174);

             GL.End(); */

            //EXEMPLO DE OBJETO TRANSPARENTE
            /* GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
             GL.Enable(EnableCap.Blend);
             GL.Color4(0.1f, 0.5f, 0.6f, 0.5f); //Último parâmetro é a porcentagem de trasparência

             GL.Begin(PrimitiveType.Quads);
             GL.Vertex3(-80, 50, 0);
             GL.Vertex3(-80, 100, 0);
             GL.Vertex3(-80, 100, 50);
             GL.Vertex3(-80, 50, 50);
             GL.End();
             GL.Disable(EnableCap.Blend); */
            // GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, Color.Transparent);

            //JANELA
            /*GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha  , BlendingFactorDest.OneMinusSrcAlpha  );
            
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(100, 0, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(250, 0, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(250, 0, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(100, 0, 60);
            GL.End();

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D); */

            //PILAR
            /*
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-50, 0, 0);
            GL.Vertex3(-50, 0, 240);
            GL.Vertex3(-45, 0, 240);
            GL.Vertex3(-45, 0, 0);
            GL.Vertex3(-50, 20, 0);
            GL.Vertex3(-50, 20, 240);
            GL.Vertex3(-45, 20, 240);
            GL.Vertex3(-45, 20, 0);
            GL.End();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texColuna);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0); GL.Vertex3(-50, 0, 240);
            GL.TexCoord2(7, 0); GL.Vertex3(-50, 0, 0);
            GL.TexCoord2(7, 1); GL.Vertex3(-50, 20, 0);
            GL.TexCoord2(0, 1); GL.Vertex3(-50, 20, 240);
            GL.TexCoord2(0, 0); GL.Vertex3(-45, 0, 240);
            GL.TexCoord2(7, 0); GL.Vertex3(-45, 0, 0);
            GL.TexCoord2(7, 1); GL.Vertex3(-45, 20, 0);
            GL.TexCoord2(0, 1); GL.Vertex3(-45, 20, 240);
            
            GL.End(); */

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);

            glControl1.SwapBuffers(); //troca os buffers de frente e de fundo 

        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);         // definindo a cor de limpeza do fundo da tela
            GL.Enable(EnableCap.Light0);

            texTelhado = LoadTexture("../../textura/telhado.jpg");
            texPorta2 = LoadTexture("../../textura/door_texture___41_by_agf81-d5ezjr2.jpg");
            texPorta = LoadTexture("../../textura/portajanela.png");
            texGrama = LoadTexture("../../textura/grama.jpg");
            texColuna = LoadTexture("../../textura/coluna.png");
            SetupViewport();                      //configura a janela de pintura
        }

        private void SetupViewport() //configura a janela de projeção 
        {
            int w = glControl1.Width; //largura da janela
            int h = glControl1.Height; //altura da janela

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(1f, w / (float)h, 0.1f, 2000.0f);
            GL.LoadIdentity(); //zera a matriz de projeção com a matriz identidade

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Viewport(0, 0, w, h); // usa toda area de pintura da glcontrol
            lateral = w / 2;

        }

        static int LoadTexture(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id;//= GL.GenTexture(); 

            GL.GenTextures(1, out id);
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(filename);

            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return id;
        }
        private void calcula_direcao()
        {
            dir.X = pos.X + (Math.Sin(camera_rotation * Math.PI / 180) * 1000);
            dir.Y = pos.Y + (Math.Cos(camera_rotation * Math.PI / 180) * 1000);
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > lateral)
            {
                camera_rotation += 2;
            }
            if (e.X < lateral)
            {
                camera_rotation -= 2;
            }
            lateral = e.X;
            calcula_direcao();
            glControl1.Invalidate();
        }

        private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            float a = camera_rotation;
            int tipoTecla = 0;
            if (e.KeyCode == Keys.Left)
            {
                a -= 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                a += 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.Up)
            { tipoTecla = 1; }
            if (e.KeyCode == Keys.Down)
            {
                a += 180;
                tipoTecla = 1;
            }

            if (e.KeyCode == Keys.D)
            {
                a += 1;
                tipoTecla = 2;
            }
            if (e.KeyCode == Keys.A)
            {
                a -= 1;
                tipoTecla = 2;
            }
            if (tipoTecla == 1)
            {
                if (a < 0) a += 360;
                if (a > 360) a -= 360;
                label2.Text = a.ToString();
                pos.X += (Math.Sin(a * Math.PI / 180) * 10);
                pos.Y += (Math.Cos(a * Math.PI / 180) * 10);
                calcula_direcao();
                glControl1.Invalidate();
            }

            if (tipoTecla == 2)
            {
                camera_rotation = a;
                calcula_direcao();
                glControl1.Invalidate();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            glControl1.Width = Form1.ActiveForm.Width - 10;
            glControl1.Height = Form1.ActiveForm.Height - 10;
            SetupViewport();
            glControl1.Invalidate();
        }

    }
}
