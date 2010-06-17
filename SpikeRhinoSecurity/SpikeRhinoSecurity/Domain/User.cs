namespace SpikeRhinoSecurity.Domain
{
    #region Usings

    using Rhino.Security;

    #endregion

    public class User : IUser
    {
        private long id;
        private string name;

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the security info for this user
        /// </summary>
        /// <value>The security info.</value>
        public virtual SecurityInfo SecurityInfo
        {
            get { return new SecurityInfo(name, id); }
        }
    }
}