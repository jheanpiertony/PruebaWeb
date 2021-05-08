namespace CommonCore.Services
{
    public class Hombre : Persona
    {

        #region Campos
        private CommonCore.Enums.Genero genero = CommonCore.Enums.Genero.Hombre; 
        #endregion
        #region Constructor
        public Hombre()
        {

        }
        public Hombre(bool mudo, bool sordo)
            : base(mudo, sordo)
        {
        } 
        #endregion
    }
}
