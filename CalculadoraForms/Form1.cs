using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        int valor;
        string ultimoOp;
        bool apertouOP = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
            txbAux.Clear();
            valor = 0;
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento:
            var botao = (Button)sender;

            if (valor != 0 && apertouOP == false && txbTela.Text != "")
            {
                btnIgual.PerformClick();
                txbTela.Clear();
                txbAux.Text = valor.ToString() + botao.Text;
                ultimoOp = botao.Text;
                apertouOP = true;
            }
            else if (txbTela.Text != "")
            { 
                valor = int.Parse(txbTela.Text);
                txbTela.Clear();
                txbAux.Text = valor.ToString() + botao.Text;
                ultimoOp = botao.Text;
            }
            

        }
        private void Numero_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento:
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
            apertouOP = false;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txbTela.Text != "")
            {
                switch (ultimoOp)
                {
                    case "+":
                        txbAux.Clear();
                        txbTela.Text = (valor + int.Parse(txbTela.Text)).ToString();
                        break;
                    case "-":
                        txbAux.Clear();
                        txbTela.Text = (valor - int.Parse(txbTela.Text)).ToString();
                        break;
                    case "X":
                        txbAux.Clear();
                        txbTela.Text = (valor * int.Parse(txbTela.Text)).ToString();
                        break;
                    case "/":
                        if (int.Parse(txbTela.Text) != 0)
                        {
                            txbAux.Clear();
                            txbTela.Text = (valor / int.Parse(txbTela.Text)).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Não é possível dividir por Zero!");
                        }

                        break;
                }
                valor = int.Parse(txbTela.Text);
            }
        }
    }
}
