using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Aduana_Nacional
{
    public partial class FrmAduanaNacional : Form
    {
        public FrmAduanaNacional()
        {
            InitializeComponent();
        }
        
        ClsMetodos met = new ClsMetodos();

        private void FrmAduanaNacional_Load(object sender, EventArgs e)
        {
            met.Conectar();
        }
        
        private void btnConsult_Click(object sender, EventArgs e)
        {
            /*try
            {*/


            //Tiempo de espera
            /*var timeout = 10000; // en milisegundos
            var wait = new WebDriverWait(met.driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("consulta")));*/

            //No funciona en el actual proyecto
            //met.driver.implicity_wait(5);

            //Un tiempo de espera
            //System.Threading.Thread.Sleep(5000);


            /*}
            catch (Exception ex)
            {

               throw;
            }  */
        }

        private void btnEnviarDatos_Click(object sender, EventArgs e)
        {
            //Enviando los valores de cada comboBox y TextBox al portal web de Aduana
            met.driver.FindElement(By.Name("gestion")).SendKeys(cbxGestion.Text);

            //Seleccionando un "select" con múltiple opciones en HTML (Una tipo lista)
            IWebElement selectElement = met.driver.FindElement(By.Id("aduana"));
            var selectObject = new SelectElement(selectElement);

            // Selecciona una <option> basándose en el indice interno del elemento <select>
            selectObject.SelectByValue("301");

            //Enviando los valores de cada comboBox y TextBox al portal web de Aduana
            met.driver.FindElement(By.Name("serie")).SendKeys(txtSerie.Text);
            met.driver.FindElement(By.Name("numero")).SendKeys(cbxNum.Text);

            //Mostrando URL actual
            MessageBox.Show(met.driver.Url);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cerrar la sesión del navegador totalmente
            met.driver.Quit();
                       
            //Mostrando URL actual
            MessageBox.Show("Se ha cerrado la conexión");

            //Cerrando el formulario
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Dando clic al botón de consultar
            IWebElement aux = met.driver.FindElement(By.Id("consulta"));
            aux.Click();

            //Mostrando URL actual
            MessageBox.Show("Nos encontramos en la siguiente dirección: " + met.driver.Url);

            //Robando el último registro de aduanas en los label creados
            labFecha.Text = "holo, funcionó";
            labFecha.Visible = true;

            labID.Text = "";
            labID.Visible = true;

            labDato.Text = "";
            labDato.Visible = true;
        }
    }
}
