// Importa las bibliotecas necesarias para Windows Forms y gráficos
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CView
{
    // Define la clase frmLogin que hereda de Form (ventana de Windows)
    public class frmLogin : Form
    {
        // Declaración de los controles de la interfaz
        private Label lblTitulo, lblUsuario, lblContrasena;
        private TextBox txtUsuario, txtContrasena;
        private Button btnIngresar;
        private Panel panelMain;

        // Constructor del formulario
        public frmLogin()
        {
            // Propiedades generales del formulario
            this.Text = "🔐 Proyecto Final - Login"; // Título de la ventana
            this.Size = new Size(420, 300); // Tamaño de la ventana
            this.StartPosition = FormStartPosition.CenterScreen; // Centrar en pantalla
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Sin redimensionar
            this.MaximizeBox = false; // Oculta el botón maximizar
            this.BackColor = Color.FromArgb(24, 26, 27); // Color de fondo

            // Panel principal para contener los controles con estilo
            panelMain = new Panel()
            {
                Size = new Size(380, 240),
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(34, 36, 40) // Fondo oscuro
            };
            this.Controls.Add(panelMain); // Añadir al formulario

            // Título en la parte superior
            lblTitulo = new Label()
            {
                Text = "Bienvenido al Proyecto Final",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Cyan, // Color del texto
                Location = new Point(40, 20),
                AutoSize = true
            };
            panelMain.Controls.Add(lblTitulo); // Añadir al panel

            // Etiqueta para el campo Usuario
            lblUsuario = new Label()
            {
                Text = "Usuario:",
                ForeColor = Color.White,
                Location = new Point(30, 70),
                AutoSize = true
            };
            panelMain.Controls.Add(lblUsuario);

            // Caja de texto para ingresar el usuario
            txtUsuario = new TextBox()
            {
                Location = new Point(120, 70),
                Width = 200,
                BackColor = Color.FromArgb(50, 50, 50), // Fondo oscuro
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panelMain.Controls.Add(txtUsuario);

            // Etiqueta para el campo Contraseña
            lblContrasena = new Label()
            {
                Text = "Contraseña:",//
                ForeColor = Color.White,
                Location = new Point(30, 110),
                AutoSize = true
            };
            panelMain.Controls.Add(lblContrasena);

            // Caja de texto para la contraseña (con ocultamiento)
            txtContrasena = new TextBox()
            {
                Location = new Point(120, 110),
                Width = 200,
                UseSystemPasswordChar = true, // Oculta el texto con '*'
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panelMain.Controls.Add(txtContrasena);

            // Botón para iniciar sesión
            btnIngresar = new Button()
            {
                Text = "Ingresar",
                Location = new Point(120, 160),
                Width = 100,
                BackColor = Color.MediumSlateBlue, // Color llamativo
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat // Sin borde 3D
            };
            btnIngresar.Click += BtnIngresar_Click; // Evento click
            panelMain.Controls.Add(btnIngresar);
        }

        // Método que se ejecuta cuando se hace clic en el botón "Ingresar"
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Obtiene los valores escritos por el usuario
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validación local sin base de datos
            if (usuario == "admin" && contrasena == "1234")
            {
                // Mensaje de éxito y apertura del menú principal
                MessageBox.Show("✅ Acceso concedido", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMenu menu = new frmMenu(); // Abre frmMenu
                menu.FormClosed += (s, args) => this.Close(); // Cierra login al cerrar frmMenu
                menu.Show(); // Muestra el menú
                this.Hide(); // Oculta el formulario de login
            }
            else
            {
                // Si las credenciales son incorrectas
                MessageBox.Show("❌ Usuario o contraseña incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
