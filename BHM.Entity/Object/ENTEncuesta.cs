/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTEncuesta
' Autor: Ruben.Cobos
' Fecha: 19-Noviembre-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referencias manuales
using System.Data;

namespace BHM.Entity.Object
{
    public class ENTEncuesta : ENTBase
    {

        private Int32       _EncuestaId;
        private Int32       _EncuestaDetalleId;
        private Int32       _ResultadoEncuestaId;
        private Int32       _UsuarioId;
        private Int32       _UsuarioId_Creacion;
        private Int32       _UsuarioId_Modificacion;
        private String      _FechaCreacion;
        private String      _FechaModificacion;
        private String      _MensajeRecuperacion;
        private String      _Nombre;
        private String      _Descripcion;
        private String      _Entrada;
        private String      _RespuestaDetalle;
        private Int16       _Aceptada;
        private Int16       _Activo;
        private Int16       _Finalizada;
        private Int16       _PreguntasPorPagina;
        private Int16       _SoloAvanzar;
        private Int32       _Paginas;
        private Int32       _PaginaActual;
        private DataTable   _DataTableResultadoEncuesta;


        //Constructor

        public ENTEncuesta(){
            _EncuestaId = 0;
            _EncuestaDetalleId = 0;
            _ResultadoEncuestaId = 0;
            _UsuarioId = 0;
            _UsuarioId_Creacion = 0;
            _UsuarioId_Modificacion = 0;
            _FechaCreacion = "";
            _FechaModificacion = "";
            _MensajeRecuperacion = "";
            _Nombre = "";
            _Descripcion = "";
            _Entrada = "";
            _RespuestaDetalle = "";
            _Aceptada = -1;
            _Activo = -1;
            _Finalizada = -1;
            _PreguntasPorPagina = -1;
            _SoloAvanzar = -1;
            _Paginas = -1;
            _PaginaActual = -1;
            _DataTableResultadoEncuesta = null;
        }



        // Propiedades

        ///<remarks>
        ///   <name>ENTEncuesta.EncuestaId</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único de Encuesta</summary>
        public Int32 EncuestaId
        {
            get { return _EncuestaId; }
            set { _EncuestaId = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.EncuestaDetalleId</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único del detalle de una Encuesta</summary>
        public Int32 EncuestaDetalleId
        {
            get { return _EncuestaDetalleId; }
            set { _EncuestaDetalleId = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.ResultadoEncuestaId</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único del registro de resultado de encuesta asociado a un usuario</summary>
        public Int32 ResultadoEncuestaId
        {
            get { return _ResultadoEncuestaId; }
            set { _ResultadoEncuestaId = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.UsuarioId</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único del usuario</summary>
        public Int32 UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.UsuarioId_Creacion</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único del usuario que crea la encuesta</summary>
        public Int32 UsuarioId_Creacion
        {
            get { return _UsuarioId_Creacion; }
            set { _UsuarioId_Creacion = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.UsuarioId_Modificacion</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único del usuario que actualiza la encuesta</summary>
        public Int32 UsuarioId_Modificacion
        {
            get { return _UsuarioId_Modificacion; }
            set { _UsuarioId_Modificacion = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.FechaCreacion</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna la fecha de creación del registro</summary>
        public String FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }   

        ///<remarks>
        ///   <name>ENTEncuesta.FechaModificacion</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna la fecha de modificación del registro</summary>
        public String FechaModificacion
        {
            get { return _FechaModificacion; }
            set { _FechaModificacion = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.MensajeRecuperacion</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna un mensaje en el proceso de recuperación de encuesta</summary>
        public String MensajeRecuperacion
        {
            get { return _MensajeRecuperacion; }
            set { _MensajeRecuperacion = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.Nombre</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el nombre de la Encuesta</summary>
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.Descripcion</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna la descripción/notas del registro</summary>
        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.Entrada</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna la entrada de la encuesta</summary>
        public String Entrada
        {
            get { return _Entrada; }
            set { _Entrada = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.RespuestaDetalle</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el detalle de la opción</summary>
        public String RespuestaDetalle
        {
            get { return _RespuestaDetalle; }
            set { _RespuestaDetalle = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.Aceptada</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna un valor que determina si los terminos y condiciones de la encuesta en cuestion ya fue aceptada o no</summary>
        public Int16 Aceptada
        {
            get { return _Aceptada; }
            set { _Aceptada = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.Activo</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el control de baja lógica de registro</summary>
        public Int16 Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.Finalizada</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna un valor que determina si la encuesta ya fue finalizada</summary>
        public Int16 Finalizada
        {
            get { return _Finalizada; }
            set { _Finalizada = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.PreguntasPorPagina</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el total de preguntas por pagina de la Encuesta</summary>
        public Int16 PreguntasPorPagina
        {
            get { return _PreguntasPorPagina; }
            set { _PreguntasPorPagina = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.SoloAvanzar</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna un valor que determina si la encuesta sera navegable solo hacia adelante o no</summary>
        public Int16 SoloAvanzar
        {
            get { return _SoloAvanzar; }
            set { _SoloAvanzar = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.Paginas</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna la cantidad de páginas de una encuesta</summary>
        public Int32 Paginas
        {
            get { return _Paginas; }
            set { _Paginas = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.PaginaActual</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna la pagina actual de una encuesta</summary>
        public Int32 PaginaActual
        {
            get { return _PaginaActual; }
            set { _PaginaActual = value; }
        }

        ///<remarks>
        ///   <name>ENTEncuesta.DataTableResultadoEncuesta</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna un set de datos que representan las respuesta de una encuesta</summary>
        public DataTable DataTableResultadoEncuesta
        {
            get { return _DataTableResultadoEncuesta; }
            set { _DataTableResultadoEncuesta = value; }
        }

    }
}
