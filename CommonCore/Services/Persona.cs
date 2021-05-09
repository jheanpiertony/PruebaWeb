using CommonCore.Interfaces;

namespace CommonCore.Services
{
    public class Persona : IPersona
    {
        #region Campos
        private readonly bool mudo;
        private readonly bool sordo;
        #endregion

        #region Propiedades
        public int Edad { get; set; }
        #endregion

        #region Constructores
        public Persona()
        {
            Edad = 0;
            this.mudo = false;
            this.sordo = false;
        }
        public Persona(bool mudo, bool sordo)
        {
            Edad = 0;
            this.mudo = mudo;
            this.sordo = sordo;
        } 
        #endregion

        #region Metodos Publicos
        public string Caminar()
        {
            throw new System.NotImplementedException();
        }

        public string Hablar()
        {

            string mensage = string.Empty;
            
            if (mudo)
            {
                mensage = "Se comunica con señas";
            }
            else
            {
                mensage = "Todo bien";
            }
            return mensage;
        }

        public string Oir()
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}
