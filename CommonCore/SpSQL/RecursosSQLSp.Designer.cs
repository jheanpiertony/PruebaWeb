﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommonCore.SpSQL {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class RecursosSQLSp {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RecursosSQLSp() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CommonCore.SpSQL.RecursosSQLSp", typeof(RecursosSQLSp).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP.
        /// </summary>
        public static string BorrarSPProductoPorId {
            get {
                return ResourceManager.GetString("BorrarSPProductoPorId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SET ANSI_NULLS ON
        ///GO
        ///SET QUOTED_IDENTIFIER ON
        ///GO
        ///-- =============================================
        ///-- Author:		&lt;ANTONIO,DAVID,RESTREPO C.&gt;
        ///-- Create date: &lt;18,03,2020&gt;
        ///-- Description:	&lt;Lista de productos&gt;
        ///-- =============================================
        ///DROP PROCEDURE CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP
        ///                                         GO.
        /// </summary>
        public static string BorrarSpProductoPorIdDesdeNetCore_PruebaWeb_SP {
            get {
                return ResourceManager.GetString("BorrarSpProductoPorIdDesdeNetCore_PruebaWeb_SP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP.
        /// </summary>
        public static string CrearSPProductoPorId {
            get {
                return ResourceManager.GetString("CrearSPProductoPorId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SET ANSI_NULLS ON
        ///GO
        ///SET QUOTED_IDENTIFIER ON
        ///GO
        ///-- =============================================
        ///-- Author:		&lt;ANTONIO,DAVID,RESTREPO C.&gt;
        ///-- Create date: &lt;18,03,2020&gt;
        ///-- Description:	&lt;Lista de productos&gt;
        ///-- =============================================
        ///CREATE PROCEDURE CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP
        ///		@Id int
        ///AS
        ///BEGIN
        ///	SET NOCOUNT ON;
        ///	SELECT *
        ///	FROM [dbo].Producto
        ///	WHERE [dbo].Producto.Id = @Id
        ///END
        ///GO.
        /// </summary>
        public static string CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP {
            get {
                return ResourceManager.GetString("CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP", resourceCulture);
            }
        }
    }
}
