using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.Contracts;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents CheckInActivityViewModel
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.Contracts.ISerializableToCSV" />
    public class CheckInActivityViewModel : ISerializableToCSV
    {
        /// <summary>
        /// Gets or sets the member identifier of this CheckInActivityViewModel.
        /// </summary>
        [Display(Name = "Member ID")]
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the check in date time of this CheckInActivityViewModel.
        /// </summary>
        [Display(Name = "Check In Date/Time")]
        public DateTimeOffset CheckInDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked in.
        /// </summary>
        [Display(Name = "Is checked in")]
        public bool IsCheckedIn { get; set; }

        /// <summary>
        /// Gets the date.
        /// </summary>
        [Display(Name = "Check in Date")]
        public string Date => $"{CheckInDateTime:D}";

        /// <summary>
        /// Gets the time.
        /// </summary>
        [Display(Name = "Check in Time")]
        public string Time => $"{CheckInDateTime:T}";

        /// <summary>
        /// Gets or sets the member of this CheckInActivityViewModel.
        /// </summary>
        [Display(Name = "Member")]
        public virtual UserAccount Member { get; set; }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        public IEnumerable<string> Headers
        {
            get
            {
                return new string[] {
                    nameof(MemberId),
                    nameof(IsCheckedIn),
                    nameof(Date),
                    nameof(Time)
                };
            }
        }

        /// <summary>
        /// Gets the CSV string.
        /// </summary>
        public IEnumerable<string> CSVString
        {
            get
            {
                return new string[] {
                    MemberId,
                    IsCheckedIn.ToString(),
                    Date,
                    Time
                };
            }
        }
    }
}