namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents LogInCredential
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.DTOs.TableRow" />
    public class LogInCredential : TableRow
    {
        /// <summary>
        /// Gets or sets the member identifier of this LogInCredential.
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of this LogInCredential.
        /// </summary>
        public string HashedPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [requires password].
        /// </summary>
        public bool RequiresPassword { get; set; }

        /// <summary>
        /// Gets or sets the member of this LogInCredential.
        /// </summary>
        public virtual UserAccount Member { get; set; }
    }
}