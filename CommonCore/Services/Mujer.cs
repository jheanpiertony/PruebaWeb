namespace CommonCore.Services
{
    public class Mujer : Persona
    {
        #region Campos
        private string mensage;
        #endregion

        #region Constructor
        public Mujer()
        {
        }
        public Mujer(bool mudo, bool sordo)
            : base(mudo, sordo)
        {
        }
        #endregion

        #region Metodos publico
        public void TenerBebes() 
        {
            mensage = "Puede tener bebes";
        } 
        #endregion
    }
}
