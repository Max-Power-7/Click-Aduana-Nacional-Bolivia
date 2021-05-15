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


//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Opera;

namespace Aduana_Nacional
{
    public partial class FrmAduanaNacional : Form
    {
        public FrmAduanaNacional()
        {
            InitializeComponent();
        }

        WebBrowser nav = new WebBrowser();
        
        ClsMetodos met = new ClsMetodos();

        //IWebDriver driver = new ChromeDriver();        
        //IWebDriver driver = new OperaDriver();
        //IWebDriver driver = new EdgeDriver();        

        private void FrmAduanaNacional_Load(object sender, EventArgs e)
        {
            met.Conectar();            
            //Para no tener errores de script
            //nav.ScriptErrorsSuppressed = true;
        }

        private void datos_cargados(object sender, EventArgs e)
        {
            try
            {
                //Obteniendo la fecha del último registro de la semana
                foreach (HtmlElement etiqueta in nav.Document.All)
                {
                    if (etiqueta.GetAttribute("classname").Contains("xxx"))
                    {
                        labFecha.Text = etiqueta.InnerText;
                        labFecha.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            try
            {
                //Enviando los valores de cada comboBox y TextBox al portal web de Aduana
                met.driver.FindElement(By.Name("gestion")).SendKeys(cbxGestion.Text);

                //Seleccionando un "select" con múltiple opciones en HTML (Una tipo lista)
                IWebElement selectElement = met.driver.FindElement(By.Id("aduana"));
                var selectObject = new SelectElement(selectElement);

                // Selecciona una <option> basándose en el indice interno del elemento <select>
                selectObject.SelectByValue("301");                

                met.driver.FindElement(By.Name("serie")).SendKeys(txtSerie.Text);
                met.driver.FindElement(By.Name("numero")).SendKeys(cbxNum.Text);



                /*
                //---------------------------------------------------------------------------
                --Utilizando el WebBrowser
                nav.Navigate("http://anbsw01.aduana.gob.bo:7601/click/login.do");

                //Si terminó de cargar el sitio entonces se agrega el valor a nav
                nav.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.datos_cargados);*/

                //--------------------------------------------------------------------------
                //Abriendo el navegador con una URL de entrada
                //driver.Navigate().GoToUrl("http://anbsw01.aduana.gob.bo:7601/click/login.do");            

                //Cerrar el navegador
                //driver.Close();
            }
            catch (Exception ex)
            {
                throw;
            }                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Mostrando los datos robados
            MessageBox.Show((met.driver.FindElement(By.Name("gestion"))).ToString());            

        }
    }
}
