/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPBase
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'           Clase base. Todas clases definidas en el proyecto [BusinessProcess.Object] heredarán de esta clase.
'
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referencias manuales
using System.Configuration;

namespace BHM.BusinessProcess
{
    public class BPBase
    {

        private Int16   _SessionTimeout;
        private String  _ApplicationURL;
        private String  _ConnectionApplication;
        private String  _QuizURL;

        // Constructor
        public BPBase()
        {
            _SessionTimeout = Int16.Parse(ConfigurationManager.AppSettings["Application.SessionTimeout"].ToString());
            _ApplicationURL =  ConfigurationManager.AppSettings["Application.URL"].ToString();
            _ConnectionApplication = ConfigurationManager.ConnectionStrings["Application.DBCnn"].ToString();
            _QuizURL = ConfigurationManager.AppSettings["Application.Quiz"].ToString();
        }


        // Propiedades

       
        ///<remarks>
        ///   <name>BPBase.ApplicationURL</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene la URL de la publicación aplicación</summary>
        public String ApplicationURL
        {
            get { return _ApplicationURL; }
        }

        ///<remarks>
        ///   <name>BPBase.ConnectionApplication</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene la cadena de conexión a la base de datos de la aplicación</summary>
        public String ConnectionApplication
        {
            get { return _ConnectionApplication; }
        }

        ///<remarks>
        ///   <name>BPBase.SessionTimeout</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene el periodo en minutos que durará la sesión de un usuario</summary>
        public Int16 SessionTimeout
        {
            get { return _SessionTimeout; }
        }

        ///<remarks>
        ///   <name>BPBase.QuizURL</name>
        ///   <create>20-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene la URL de inicio de la encuesta</summary>
        public String QuizURL
        {
            get { return _QuizURL; }
        }


    }
}
