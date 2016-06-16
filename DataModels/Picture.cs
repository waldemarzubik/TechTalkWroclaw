using System;

namespace TechTalk.DataModels
{
    /// <summary>
    /// Picture.
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// Must have
        /// </summary>
        /// <value>The URI.</value>
        public string Uri { get; set; }

        /// <summary>
        /// Optional 
        /// </summary>
        /// <value>The thumbnail URI.</value>
        public string ThumbnailUri { get; set; }

<<<<<<< HEAD
		/// <summary>
		/// Optional
		/// </summary>
		/// <value>The thumbnail handler.</value>
		public IntPtr ThumbnailHandle { get; set; }
=======
        /// <summary>
        /// Optional
        /// </summary>
        /// <value>The thumbnail handler.</value>
        public IntPtr ThumbnailHandler { get; set; }
>>>>>>> origin/master
    }
}