﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Saiao.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Saiao.Common.Resources.ErrorMessage", typeof(ErrorMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Falha ao buscar o registro..
        /// </summary>
        public static string BuscarRegistro {
            get {
                return ResourceManager.GetString("BuscarRegistro", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Falha ao buscar os registros..
        /// </summary>
        public static string BuscarRegistros {
            get {
                return ResourceManager.GetString("BuscarRegistros", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Falha ao tentar alterar o registro..
        /// </summary>
        public static string RegistroAlterado {
            get {
                return ResourceManager.GetString("RegistroAlterado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe um registro com essas informações..
        /// </summary>
        public static string RegistroDuplicado {
            get {
                return ResourceManager.GetString("RegistroDuplicado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Falha ao tentar excluir o registro..
        /// </summary>
        public static string RegistroExcluido {
            get {
                return ResourceManager.GetString("RegistroExcluido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Falha ao tentar incluir o registro..
        /// </summary>
        public static string RegistroIncluido {
            get {
                return ResourceManager.GetString("RegistroIncluido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário não encontrado..
        /// </summary>
        public static string UsuarioNaoEncontrado {
            get {
                return ResourceManager.GetString("UsuarioNaoEncontrado", resourceCulture);
            }
        }
    }
}
