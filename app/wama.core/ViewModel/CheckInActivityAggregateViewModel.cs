using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.Contracts;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents CheckInActivityAggregateViewModel
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.Contracts.ISerializableToCSV" />
    public class CheckInActivityAggregateViewModel : ISerializableToCSV
    {
        /// <summary>
        /// Gets or sets the report granularity of this CheckInActivityAggregateViewModel.
        /// </summary>
        public ReportGranularity ReportGranularity { get; set; }

        /// <summary>
        /// Gets or sets the count of this CheckInActivityAggregateViewModel.
        /// </summary>
        [Display(Name = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the time of this CheckInActivityAggregateViewModel.
        /// </summary>
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// Gets the formated time.
        /// </summary>
        [Display(Name = "Time")]
        public string FormatedTime
        {
            get
            {
                switch (ReportGranularity)
                {
                    case ReportGranularity.Hourly:
                        return $"{Time:t}";

                    case ReportGranularity.Daily:
                        return $"{Time:D}";

                    case ReportGranularity.Weekly:
                        return $"{Time:d}";

                    case ReportGranularity.Monthly:
                        return $"{Time:y}";

                    case ReportGranularity.Yearly:
                        return $"{Time:yyyy}";
                }

                return $"{Time}";
            }
        }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        public IEnumerable<string> Headers
        {
            get
            {
                if (ReportGranularity == ReportGranularity.Individual)
                {
                    return null;
                }

                var headers = new List<string> { "count", "year" };

                if (ReportGranularity < ReportGranularity.Yearly)
                {
                    headers.Add("month");
                }

                if (ReportGranularity < ReportGranularity.Monthly)
                {
                    headers.Add("date");
                }

                if (ReportGranularity < ReportGranularity.Weekly)
                {
                    headers.Add("day");
                }

                if (ReportGranularity < ReportGranularity.Daily)
                {
                    headers.Add("time");
                }

                return headers;
            }
        }

        /// <summary>
        /// Gets the CSV string.
        /// </summary>
        public IEnumerable<string> CSVString
        {
            get
            {
                if (ReportGranularity == ReportGranularity.Individual)
                {
                    return null;
                }

                var values = new List<string> { $"{Count}", $"{Time:yyyy}" };

                if (ReportGranularity < ReportGranularity.Yearly)
                {
                    values.Add($"{Time:MMMM}");
                }

                if (ReportGranularity < ReportGranularity.Monthly)
                {
                    values.Add($"{Time:MM-dd-yyyy}");
                }

                if (ReportGranularity < ReportGranularity.Weekly)
                {
                    values.Add($"{Time:dddd}");
                }

                if (ReportGranularity < ReportGranularity.Daily)
                {
                    values.Add($"{Time:t}");
                }

                return values;
            }
        }
    }
}